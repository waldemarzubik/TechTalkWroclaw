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

        public RecyclerView ImagesList
        {
            get { return _imagesList ?? (_imagesList = View.FindViewById<RecyclerView>(Resource.Id.imagesList)); }
        }

        public GalleryFragment() : base(Resource.Layout.GalleryView)
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            _itemSize = Activity.WindowManager.DefaultDisplay.Width / COLUMNS_COUNT;
            base.OnCreate(savedInstanceState);
        }

        public override void OnDestroy()
        {
            _imagesList = null;
            base.OnDestroy();
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ImagesList.HasFixedSize = true;
            ImagesList.SetLayoutManager(new GridLayoutManager(Activity, COLUMNS_COUNT));
        }
    }
}