using System;
using TechTalk.ViewModels;
using Android.App;
namespace TechTalk.Droid
{
    [Activity]
    public class PictureView : ActivityBase<IPictureViewModel>
    {
        public PictureView() : base(Resource.Layout.PictureView, 0)
        {
        }
    }
}