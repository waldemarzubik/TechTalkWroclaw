using Foundation;
using System;
using UIKit;
using AssetsLibrary;
using CoreGraphics;
using CoreAnimation;

namespace TechTalk.iOS
{
    public partial class PictureViewCell : UICollectionViewCell
    {

		public static readonly NSString Key = new NSString("PictureViewCell");

		public string Image
		{
			set
			{
				
				_assetLib.AssetForUrl(
					new NSUrl(value),
					delegate (ALAsset asset)
					{
						UIImage image = new UIImage(asset.DefaultRepresentation.GetFullScreenImage());

						_imageView.Image = image;
						
						
					},
					(NSError e) =>
					{
						Console.WriteLine("Where is my ass..et bro?: " + e.LocalizedDescription);
					}
					);

			}
		}

		private readonly UIImageView 		_imageView;
		private readonly ALAssetsLibrary 	_assetLib;

		public PictureViewCell (IntPtr handle) : base (handle)
        {
			

        }


		[Export("initWithFrame:")]
		public PictureViewCell(CGRect frame) : base (frame)
		{
			_assetLib = new ALAssetsLibrary();
			_imageView = new UIImageView(Bounds);
			_imageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			_imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			_imageView.ClipsToBounds = true;
			_imageView.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			ContentView.AddSubview(_imageView);
		}



	}
}