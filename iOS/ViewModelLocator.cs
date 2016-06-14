using System;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;

namespace TechTalk.iOS
{
    public sealed class ViewModelLocator : ViewModelLocatorBase
    {
        public ViewModelLocator()
        {
        }

        protected override IGalleryService GalleryService
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override INavigationService NavigationService
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}