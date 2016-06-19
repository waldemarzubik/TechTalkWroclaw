using System;
using Com.Epam.Techtalk;


namespace TechTalk.Droid
{
    public class GalleryServiceProxyBinder : IGalleryServiceProxyStub, IGalleryServiceProxy
    {
        private readonly WeakReference<GalleryServiceService> _reference;

        public GalleryServiceProxyBinder(GalleryServiceService service)
        {
            _reference = new WeakReference<GalleryServiceService>(service);
        }

        public override void LoadImagesAsync()
        {
            GalleryServiceService service = null;
            if (_reference.TryGetTarget(out service))
            {
                service.LoadImagesAsync();
            }
        }

        public override void RegisterCallback(IGalleryServiceCallbackProxy callbackProxy)
        {
            GalleryServiceService service = null;
            if (_reference.TryGetTarget(out service))
            {
                service.RegisterCallback(callbackProxy);
            }
        }
    }
}