using System;
using Android.App;
using Newtonsoft.Json;
using Com.Epam.Techtalk;

namespace TechTalk.Droid
{
    [Service()]
    public class GalleryServiceService : Service
    {
        IGalleryServiceCallbackProxy _callback;

        GalleryService _galleryService;

        public override void OnCreate()
        {
            base.OnCreate();
            _galleryService = new GalleryService();
        }

        public override Android.OS.IBinder OnBind(Android.Content.Intent intent)
        {
            return new GalleryServiceProxyBinder(this);
        }

        internal void LoadImagesAsync()
        {
            _galleryService.LoadImagesAsync().ContinueWith((tsk) =>
            {
                var result = tsk.Result;
                _callback.NotifyResult(JsonConvert.SerializeObject(result));
            });
        }

        internal void RegisterCallback(IGalleryServiceCallbackProxy callback)
        {
            _callback = callback;
        }
    }
}