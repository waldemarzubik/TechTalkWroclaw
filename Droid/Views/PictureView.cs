using System;
using TechTalk.ViewModels;
namespace TechTalk.Droid.Views
{
    public class PictureView : ActivityBase<IPictureViewModel>
    {
        public PictureView() : base(Resource.Layout.PictureView, Resource.Layout.Toolbar)
        {
        }
    }
}