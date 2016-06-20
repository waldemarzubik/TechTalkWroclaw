using System;
using System.ComponentModel;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Java.IO;
using Square.Picasso;
using TechTalk.DataModels;
using TechTalk.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid
{
    public class GalleryFragment : FragmentBase<IGalleryViewModel>
    {
        private const int COLUMNS_COUNT = 3;

        private RecyclerView _imagesList;
        private int _itemSize;

        ObservableRecyclerAdapter<Picture, CachingViewHolder> _adapter;

        Binding<Picture, Picture> _binding;



        public RecyclerView ImagesList
        {
            get { return _imagesList ?? (_imagesList = View.FindViewById<RecyclerView>(Resource.Id.imagesList)); }
        }

        public GalleryFragment() : base(Resource.Layout.GalleryView)
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _itemSize = Activity.WindowManager.DefaultDisplay.Width / COLUMNS_COUNT;
            base.OnCreate(savedInstanceState);
        }

        public override void OnDestroy()
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            if (_binding != null)
            {
                _binding.Detach();
                _binding = null;
            }
            _adapter.Dispose();
            _adapter = null;
            _imagesList = null;
            base.OnDestroy();
        }

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(ViewModel.Images).Equals(e.PropertyName) && ViewModel.Images != null)
            {
                _adapter = ViewModel.Images.GetRecyclerAdapter(BindViewHolder, Resource.Layout.Item_Picture, null);
                _binding = this.SetBinding(() => _adapter.SelectedItem, () => ViewModel.SelectedItem, BindingMode.TwoWay);
                ImagesList.SetAdapter(_adapter);
            }
        }

        void BindViewHolder(CachingViewHolder arg1, Picture arg2, int arg3)
        {
            var image = arg1.FindCachedViewById<ImageView>(Resource.Id.image);
            image.LayoutParameters = new ViewGroup.LayoutParams(_itemSize, _itemSize);
            Picasso.With(Activity).Load(new File(arg2.ThumbnailUri)).Into(image);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ImagesList.HasFixedSize = true;
            ImagesList.SetLayoutManager(new GridLayoutManager(Activity, COLUMNS_COUNT));
        }
    }
}