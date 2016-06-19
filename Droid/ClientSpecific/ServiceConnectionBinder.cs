using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace TechTalk.Droid
{
    public class ServiceConnectionBinder : IServiceConnectionBinder
    {
        private readonly List<Tuple<Type, Type>> _registerLookup;
        private readonly Dictionary<int, List<IBoundedServiceConnection>> _connections;

        public ServiceConnectionBinder()
        {
            _registerLookup = new List<Tuple<Type, Type>>();
            _connections = new Dictionary<int, List<IBoundedServiceConnection>>();
        }

        #region IServiceConnectionRetriever implementation

        public event EventHandler<ServiceEventArgs> ConnectionChanged;

        public void Bind(Context context)
        {
            if (context == null)
            {
                return;
            }
            lock (_connections)
            {
                foreach (var registration in _registerLookup.Where(item => item.Item1 == context.GetType()))
                {
                    BindService(context, registration.Item2);
                }
            }
        }

        private void BindService(Context context, Type serviceType)
        {
            if (context == null)
            {
                return;
            }
            var connection = AddConnection(context.GetHashCode());
            using (var intent = new Intent())
            {
                intent.SetClass(context, Java.Lang.Class.FromType(serviceType));
                connection.ServiceConnected += ConnectionServiceConnected;
                context.BindService(intent, connection, Android.Content.Bind.AutoCreate);
            }
        }

        private void ConnectionServiceConnected(object sender, ServiceEventArgs e)
        {
            var connectionChanged = ConnectionChanged;
            if (connectionChanged != null)
            {
                connectionChanged(this, e);
            }
        }

        public void Undbind(Context context)
        {
            if (context == null)
            {
                return;
            }
            lock (_connections)
            {
                List<IBoundedServiceConnection> connections;
                if (_connections.TryGetValue(context.GetHashCode(), out connections))
                {
                    foreach (var connection in connections)
                    {
                        if (connection.IsConnected)
                        {
                            context.UnbindService(connection);
                            connection.ServiceConnected -= ConnectionServiceConnected;
                            connection.Dispose();
                        }
                    }
                    _connections.Remove(context.GetHashCode());
                }
            }
        }

        public void Register<T, TG>() where T : AppCompatActivity where TG : Service
        {
            if (!_registerLookup.Any(item => item.Item1 == typeof(T) && item.Item2 == typeof(TG)))
            {
                lock (_registerLookup)
                {
                    _registerLookup.Add(new Tuple<Type, Type>(typeof(T), typeof(TG)));
                }
            }
        }

        #endregion

        private IBoundedServiceConnection AddConnection(int key)
        {
            var connection = new ServiceConnection();
            List<IBoundedServiceConnection> connections;
            if (!_connections.TryGetValue(key, out connections))
            {
                _connections[key] = new List<IBoundedServiceConnection>();
            }
            _connections[key].Add(connection);
            return connection;
        }
    }
}