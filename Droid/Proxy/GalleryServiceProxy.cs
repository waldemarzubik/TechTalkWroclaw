using Com.Epam.Techtalk;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.DataModels;
using TechTalk.Interfaces;
using System.Threading;
using Newtonsoft.Json;

namespace TechTalk.Droid
{
    public class GalleryServiceProxy : IGalleryServiceCallbackProxyStub, IGalleryService
    {
        private readonly IServiceConnectionBinder _connectionBinder;
        private TaskCompletionSource<IList<Picture>> _taskCompletionSource;
        private ManualResetEventSlim _connectionWaiter = new ManualResetEventSlim(false);

        private IGalleryServiceProxy Service { get; set; }

        public GalleryServiceProxy(IServiceConnectionBinder connectionBinder)
        {
            _connectionBinder = connectionBinder;
            _connectionBinder.ConnectionChanged += ConnectionBinder_ConnectionChanged;
        }

        void ConnectionBinder_ConnectionChanged(object sender, ServiceEventArgs e)
        {
            if (e.Type != Java.Lang.Class.FromType(typeof(GalleryServiceService)))
            {
                return;
            }
            Service = IGalleryServiceProxyStub.AsInterface(e.Service);
            Service.RegisterCallback(IGalleryServiceCallbackProxyStub.AsInterface(this));
            _connectionWaiter.Set();
        }

        public Task<IList<Picture>> LoadImagesAsync()
        {
            _taskCompletionSource = new TaskCompletionSource<IList<Picture>>();
            Task.Run(() =>
            {
                _connectionWaiter.Wait();
                Service.LoadImagesAsync();
            });
            return _taskCompletionSource.Task;
        }

        public override void NotifyLoadImages(string jsonImages)
        {
            _taskCompletionSource.SetResult(JsonConvert.DeserializeObject<List<Picture>>(jsonImages));
        }
    }
}