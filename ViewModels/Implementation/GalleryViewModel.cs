using System;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class GalleryViewModel : BaseViewModel
    {
        private IGalleryService _galleryService;

        private IGalleryService GalleryService => _galleryService;

        public GalleryViewModel(IGalleryService galleryService, INavigationService navigationService) : base(navigationService)
        {
            _galleryService = galleryService;
        }
    }
}