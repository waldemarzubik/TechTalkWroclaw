using Foundation;
using System;
using UIKit;
using JASidePanels;

namespace TechTalk.iOS
{
    public partial class MainMenuViewController : JASidePanelController
    {
        public MainMenuViewController (IntPtr handle) : base (handle)
        {
			
        }

		public override void AwakeFromNib() {
			LeftPanel = Storyboard.InstantiateViewController("SlideOutMenuViewController"); 
			CenterPanel = Storyboard.InstantiateViewController("PictureCollectionViewController");
			//ShowLeftPanelAnimated(false);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ShowLeftPanelAnimated(false);
		}


	}
}