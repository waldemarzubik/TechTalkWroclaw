using System;
using TechTalk.ViewModels;
using Android.App;
using Android.Widget;
using Square.Picasso;
using Java.IO;

namespace TechTalk.Droid.Views
{
    [Activity]
    public class PictureView : ActivityBase<IPictureViewModel>
    {
        private ImageView _image;

        public ImageView Image
        {
            get { return _image ?? (_image = FindViewById<ImageView>(Resource.Id.picture)); }
        }

        public PictureView() : base(Resource.Layout.PictureView, Resource.Layout.Toolbar)
        {
        }

        public override void SetContentView(int layoutResID)
        {
            base.SetContentView(layoutResID);
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected override void OnDestroy()
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            _image = null;
            base.OnDestroy();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (nameof(ViewModel.Picture).Equals(e.PropertyName) && ViewModel.Picture != null)
            {
                //Image.SetImageURI(Android.Net.Uri.Parse(ViewModel.ImageUri));
                Picasso.With(this).Load(new File(ViewModel.Picture.ThumbnailUri)).Into(Image);
            }
        }
    }
}