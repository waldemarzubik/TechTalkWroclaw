using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class GalleryViewModel : BaseViewModel, IGalleryViewModel
    {
        private IGalleryService _galleryService;

        private IGalleryService GalleryService => _galleryService;

        public GalleryViewModel(IGalleryService galleryService, INavigation navigationService) : base(navigationService)
        {
            _galleryService = galleryService;
        }
    }
}