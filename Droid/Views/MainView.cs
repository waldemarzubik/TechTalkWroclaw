using System;
using TechTalk.ViewModels;
namespace TechTalk.Droid
{
    public class MainView : ActivityBase<IMainViewModel>
    {
        public MainView() : base(Resource.Layout.MainView, 0)
        {
        }
    }
}

