using Foundation;
using System;
using UIKit;
using TechTalk.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using TechTalk.DataModels;
using System.ComponentModel;

namespace TechTalk.iOS
{
    public partial class PictureCollectionViewController : BaseViewController<IGalleryViewModel>
    {
		nfloat scaleStart;
		public nfloat CurrentScale { get; set; }

		private ObservableCollectionViewSource<Picture, PictureViewCell> pictureSource;

		private Binding<Picture, Picture> currentItemBinding;

		public PictureCollectionViewController (IntPtr handle) : base (handle)
		{
			CurrentScale = 1.0f;
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var images = ViewModel.Images;
			ViewModel.PropertyChanged += ViewModel_PropertyChanged;

		
			CollectionView.RegisterClassForCell(typeof(PictureViewCell), PictureViewCell.Key);
			CollectionView.AllowsSelection = true;
			UIPinchGestureRecognizer pinch = new UIPinchGestureRecognizer(handlePinchGesture);
			CollectionView.AddGestureRecognizer(pinch);

			UIView.Animate(
			0.25,
			() =>
			{
				CollectionView.Alpha = 1;
			},
			() =>
			{
				CollectionView.Alpha = 1;
			});

		}


		public void handlePinchGesture(UIPinchGestureRecognizer gesture)
		{
			if (gesture.State == UIGestureRecognizerState.Began)
			{
				scaleStart = CurrentScale;
			}
			else if (gesture.State == UIGestureRecognizerState.Changed)
			{
				CurrentScale = scaleStart * gesture.Scale;
				CollectionView.CollectionViewLayout.InvalidateLayout();
			}
		}

		void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			//Yep, I am to lazy to create Prop enumerator
			if (ViewModel.Images != null && e.PropertyName.Equals("Images"))
			{
				pictureSource = ViewModel.Images.GetCollectionViewSource<Picture, PictureViewCell>(
					BindCell, null, null, 
					()=> new CollectionViewSourceEx());
				
				currentItemBinding = this.SetBinding(() => pictureSource.SelectedItem, () => ViewModel.SelectedItem, BindingMode.TwoWay);
				CollectionView.Source = pictureSource;
			}
		}

		private void BindCell(PictureViewCell cell, Picture item, NSIndexPath path)
		{
			cell.Image = item.Uri;
		}
    }
}