using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Com.Epam.Techtalk;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.DataModels;
using TechTalk.Interfaces;
using Android.App;
using TechTalk.Droid.ClientSpecific;
using Newtonsoft.Json;

namespace TechTalk.Droid
{
    [Service(Process = "com.epam.techtalk.background")]
    public class GalleryServiceService : Service
    {
        private IGalleryService _galleryService;
        private IGalleryServiceCallbackProxy _callbackProxy;

        public override void OnCreate()
        {
            base.OnCreate();
            _galleryService = new GalleryService();
        }

        public override IBinder OnBind(Intent intent)
        {
            return new GalleryServiceProxyBinder(this);
        }

        public void LoadImagesAsync()
        {
            _galleryService.LoadImagesAsync().ContinueWith(ImagesLoaded);
        }

        public void RegisterCallback(IGalleryServiceCallbackProxy callbackProxy)
        {
            _callbackProxy = callbackProxy;
        }

        private void ImagesLoaded(Task<IList<Picture>> task)
        {
            var items = task.Result;
            _callbackProxy.NotifyLoadImages(JsonConvert.SerializeObject(items));
        }
    }
}