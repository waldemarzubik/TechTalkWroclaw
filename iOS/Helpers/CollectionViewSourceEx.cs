using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using TechTalk.DataModels;
using UIKit;

namespace TechTalk.iOS
{
	public class CollectionViewSourceEx : ObservableCollectionViewSource<Picture, PictureViewCell>
	{
		
		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SelectedItem = null;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var item = GetItem(indexPath);
			SelectedItem = item;
		}
	}
}

