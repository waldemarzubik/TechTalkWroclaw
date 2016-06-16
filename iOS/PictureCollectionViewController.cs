using Foundation;
using System;
using UIKit;
using TechTalk.ViewModels;

namespace TechTalk.iOS
{
    public partial class PictureCollectionViewController : BaseViewController<IGalleryViewModel>
    {
        public PictureCollectionViewController (IntPtr handle) : base (handle)
        {
        }
    }
}