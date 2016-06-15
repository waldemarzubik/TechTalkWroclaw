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

namespace TechTalk.Droid.Views.Fragments
{
    public class GalleryFragment : FragmentBase<IGalleryViewModel>
    {
        private const int COLUMNS_COUNT = 4;

        private ObservableRecyclerAdapter<Picture, CachingViewHolder> _adapter;
        private RecyclerView _imagesList;
        private Binding<Picture, Picture> _selectedItemBinding;

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
            base.OnCreate(savedInstanceState);
        }

        public override void OnDestroy()
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            _selectedItemBinding.Detach();
            if (_adapter != null)
            {
                _adapter.Dispose();
            }
            _imagesList = null;
            base.OnDestroy();
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            const string ITEMS_PROPERTY = "Images";
            if (ITEMS_PROPERTY.Equals(e.PropertyName) && ViewModel.Images != null)
            {
                _adapter = ViewModel.Images.GetRecyclerAdapter(BindViewHolder, CreateViewHolder, null);
                _selectedItemBinding = this.SetBinding(() => _adapter.SelectedItem, () => ViewModel.SelectedItem, BindingMode.TwoWay);
                ImagesList.SetAdapter(_adapter);
            }
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ImagesList.HasFixedSize = true;
            ImagesList.SetLayoutManager(new GridLayoutManager(Activity, COLUMNS_COUNT));
        }

        private CachingViewHolder CreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = Activity.LayoutInflater.Inflate(Resource.Layout.Item_Picture, parent, false);
            int itemSize = Activity.WindowManager.DefaultDisplay.Width / COLUMNS_COUNT;
            view.LayoutParameters = new ViewGroup.LayoutParams(itemSize, itemSize);
            return new CachingViewHolder(view);
        }

        private void BindViewHolder(CachingViewHolder viewHolder, Picture item, int position)
        {
            var image = viewHolder.FindCachedViewById<ImageView>(Resource.Id.image);
            Picasso.With(Activity).Load(new File(item.ThumbnailUri)).Into(image);
        }
    }
}