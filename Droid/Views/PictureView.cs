using System;
using TechTalk.ViewModels;
namespace TechTalk.Droid
{
    public class PictureView : ActivityBase<IPictureViewModel>
    {
        public PictureView() : base(Resource.Layout.PictureView, 0)
        {
        }
    }
}

