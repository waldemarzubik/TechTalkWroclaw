using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.DataModels;
using TechTalk.Interfaces;
using TechTalk.Droid.Interfaces;
using Com.Epam.Techtalk;
using Newtonsoft.Json;
using System.Threading;

namespace TechTalk.Droid
{
    public class GalleryServiceProxy : IGalleryServiceCallbackProxyStub, IGalleryService
    {
        private IGalleryServiceProxy Service { get; set; }
        TaskCompletionSource<IList<Picture>> _taskCompletionSource;
        ManualResetEventSlim _reset = new ManualResetEventSlim();

        public GalleryServiceProxy(IServiceConnectionBinder connectionBinder)
        {
            connectionBinder.ConnectionChanged += ConnectionBinder_ConnectionChanged;
        }

        void ConnectionBinder_ConnectionChanged(object sender, Droid.ServiceEventArgs e)
        {
            Service = IGalleryServiceProxyStub.AsInterface(e.Service);
            Service.RegisterCallback(IGalleryServiceCallbackProxyStub.AsInterface(this));
            _reset.Set();
        }

        public Task<IList<Picture>> LoadImagesAsync()
        {
            _taskCompletionSource = new TaskCompletionSource<IList<Picture>>();
            Task.Run(() =>
            {
                _reset.Wait();
                Service.LoadImagesAsync();
            });
            return _taskCompletionSource.Task;
        }

        public override void NotifyResult(string jsonImages)
        {
            _taskCompletionSource.SetResult(JsonConvert.DeserializeObject<List<Picture>>(jsonImages));
        }
    }
}