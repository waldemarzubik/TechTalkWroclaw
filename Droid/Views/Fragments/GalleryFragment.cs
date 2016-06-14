using System;
using TechTalk.ViewModels;

namespace TechTalk.Droid.Views.Fragments
{
    public class GalleryFragment : FragmentBase<IGalleryViewModel>
    {
        public GalleryFragment() : base(Resource.Layout.GalleryView)
        {
        }
    }
}