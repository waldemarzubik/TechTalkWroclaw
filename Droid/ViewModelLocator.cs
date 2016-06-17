using System;
using TechTalk.Interfaces;

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
    }
}