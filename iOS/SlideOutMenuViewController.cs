using Foundation;
using System;
using UIKit;
using TechTalk.ViewModel;

namespace TechTalk.iOS
{
    public partial class SlideOutMenuViewController : BaseViewController<IMainMenuViewModel>
    {
        public SlideOutMenuViewController (IntPtr handle) : base (handle)
        {
        }
    }
}