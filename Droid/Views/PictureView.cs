using Android.App;
using Com.Github.Clans.Fab;
using FFImageLoading.Transformations;
using GalaSoft.MvvmLight.Helpers;
using TechTalk.Droid.Controls;
using TechTalk.ViewModels;

namespace TechTalk.Droid.Views
{
    [Activity]
    public class PictureView : ActivityBase<IPictureViewModel>
    {
        private int _degrees;
        private CacheImageView _image;
        private FloatingActionButton _blurButton;
        private FloatingActionButton _grayscaleButton;
        private FloatingActionButton _rotateButton;
        private FloatingActionMenu _menu;
        private Binding<string, string> _binding;


        public CacheImageView Image
        {
            get { return _image ?? (_image = FindViewById<CacheImageView>(Resource.Id.picture)); }
        }

        public FloatingActionButton BlurButton
        {
            get { return _blurButton ?? (_blurButton = FindViewById<FloatingActionButton>(Resource.Id.blurButton)); }
        }

        public FloatingActionButton GrayscaleButton
        {
            get { return _grayscaleButton ?? (_grayscaleButton = FindViewById<FloatingActionButton>(Resource.Id.grayscaleButton)); }
        }

        public FloatingActionButton RotateButton
        {
            get { return _rotateButton ?? (_rotateButton = FindViewById<FloatingActionButton>(Resource.Id.rotateButton)); }
        }

        public FloatingActionMenu Menu
        {
            get { return _menu ?? (_menu = FindViewById<FloatingActionMenu>(Resource.Id.menu)); }
        }

        public PictureView() : base(Resource.Layout.PictureView, Resource.Layout.Toolbar)
        {
        }

        public override void SetContentView(int layoutResID)
        {
            base.SetContentView(layoutResID);
            _binding = this.SetBinding(() => ViewModel.Picture.ThumbnailUri, () => Image.ImageUrl);
        }

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            BlurButton.Click += (sender, e) => { Image.Transformation = new BlurredTransformation(5); Menu.Close(true); };
            GrayscaleButton.Click += (sender, e) => { Image.Transformation = new GrayscaleTransformation(); Menu.Close(true); };
            RotateButton.Click += (sender, e) =>
            {
                _degrees += 90;
                Image.Transformation = new RotateTransformation(_degrees % 360);
                Menu.Close(true);
            };
        }

        protected override void OnDestroy()
        {
            if (_binding != null)
            {
                _binding.Detach();
                _binding = null;
            }
            _image = null;
            _menu = null;
            _rotateButton = null;
            _grayscaleButton = null;
            _blurButton = null;
            base.OnDestroy();
        }
    }
}