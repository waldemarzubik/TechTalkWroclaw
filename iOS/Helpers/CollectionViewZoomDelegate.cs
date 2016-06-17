using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TechTalk.iOS
{
	public class CollectionViewZoomDelegate: UICollectionViewDelegateFlowLayout
	{
		PictureCollectionViewController parent;
		public CollectionViewZoomDelegate(PictureCollectionViewController parent) : base() {
			this.parent = parent;
		}

		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return new CGSize(50 * parent.CurrentScale, 50 * parent.CurrentScale);
		}
	}
}

