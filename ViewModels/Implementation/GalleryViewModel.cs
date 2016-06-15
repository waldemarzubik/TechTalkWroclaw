using System.Threading.Tasks;
using TechTalk.Interfaces;
using TechTalk.DataModels;
using System.Collections.Generic;

namespace TechTalk.ViewModels.Implementation
{
    public class GalleryViewModel : BaseViewModel, IGalleryViewModel
    {
        private readonly IGalleryService _galleryService;
        private List<Picture> _images;
        private Picture _selectedItem;

        private IGalleryService GalleryService => _galleryService;

        public List<Picture> Images
        {
            get { return _images; }
            set { SetProperty(ref _images, value); }
        }

        public Picture SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public GalleryViewModel(IGalleryService galleryService, INavigation navigationService) : base(navigationService)
        {
            _galleryService = galleryService;
        }

        public override async void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            Images = await _galleryService.LoadImagesAsync();
        }
    }
}