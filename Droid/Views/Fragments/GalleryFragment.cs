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

namespace TechTalk.Droid.Views.Fragments
{
    public class GalleryFragment : FragmentBase<IGalleryViewModel>
    {
        private const int COLUMNS_COUNT = 3;

        private readonly IServiceConnectionBinder _serviceBinder;
        private ObservableRecyclerAdapter<Picture, CachingViewHolder> _adapter;
        private RecyclerView _imagesList;
        private Binding<Picture, Picture> _selectedItemBinding;
        private int _itemSize;


        public RecyclerView ImagesList
        {
            get { return _imagesList ?? (_imagesList = View.FindViewById<RecyclerView>(Resource.Id.imagesList)); }
        }

        public GalleryFragment() : base(Resource.Layout.GalleryView)
        {
            _serviceBinder = SimpleIoc.Default.GetInstance<IServiceConnectionBinder>();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _itemSize = Activity.WindowManager.DefaultDisplay.Width / COLUMNS_COUNT;
            base.OnCreate(savedInstanceState);
        }

        public override void OnStart()
        {
            base.OnStart();
            _serviceBinder.Bind(Activity);
        }

        public override void OnStop()
        {
            base.OnStop();
            _serviceBinder.Undbind(Activity);
        }

        public override void OnDestroy()
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            if (_selectedItemBinding != null)
            {
                _selectedItemBinding.Detach();
                _selectedItemBinding = null;
            }
            if (_adapter != null)
            {
                _adapter.Dispose();
            }
            _imagesList = null;
            base.OnDestroy();
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(ViewModel.Images).Equals(e.PropertyName) && ViewModel.Images != null)
            {
                _adapter = ViewModel.Images.GetRecyclerAdapter(BindViewHolder, Resource.Layout.Item_Picture, ItemClick);
                _selectedItemBinding = this.SetBinding(() => _adapter.SelectedItem, () => ViewModel.SelectedItem, BindingMode.TwoWay);
                ImagesList.SetAdapter(_adapter);
            }
        }

        private void ItemClick(int arg1, View oldView, int arg3, View newView)
        {
            TransitionService.SetTransitionInfo(new Tuple<View, string>(newView.FindViewById<ImageView>(Resource.Id.image), Resources.GetString(Resource.String.Picture)));
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ImagesList.HasFixedSize = true;
            ImagesList.SetLayoutManager(new GridLayoutManager(Activity, COLUMNS_COUNT));
        }

        private void BindViewHolder(CachingViewHolder viewHolder, Picture item, int position)
        {
            var image = viewHolder.FindCachedViewById<ImageView>(Resource.Id.image);
            image.LayoutParameters = new ViewGroup.LayoutParams(_itemSize, _itemSize);
            Picasso.With(Activity).Load(new File(item.ThumbnailUri)).Into(image);
        }
    }
}