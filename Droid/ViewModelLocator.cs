using System;
using TechTalk.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace TechTalk.Droid
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        protected override Func<IGalleryService> GalleryServiceFunc
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override Func<INavigation> NavigationServiceFunc
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ViewModelLocator()
        {

        }
    }
}