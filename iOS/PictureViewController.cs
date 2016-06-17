using Foundation;
using System;
using UIKit;
using TechTalk.ViewModels;
using AssetsLibrary;
using TechTalk.DataModels;
using CoreGraphics;

namespace TechTalk.iOS
{
    public partial class PictureViewController : BaseViewController<IPictureViewModel>
    {
		
		private readonly ALAssetsLibrary _assetLib;

		public PictureViewController (IntPtr handle) : base (handle)
        {
			_assetLib = new ALAssetsLibrary();
        }

		public override void ViewDidLoad()
		{
			ImageView.Alpha = 0;
			var picture = Params as Picture;

			_assetLib.AssetForUrl(
				new NSUrl(picture.Uri),
					delegate (ALAsset asset)
					{
						UIImage image = new UIImage(asset.DefaultRepresentation.GetFullScreenImage());

						ImageView.Image = image;


					},
					(NSError e) =>
					{
						Console.WriteLine("Where is my ass..et bro?: " + e.LocalizedDescription);
					}
					);

			base.ViewDidLoad();

			Animate();
		}

		void Animate()
		{
			UIView.Animate(
			0.25,
			() =>
			{
				ImageView.Alpha = 1;
			},
			() =>
			{
				ImageView.Alpha = 1;
			});
		}
}
}