using System;
using TechTalk.ViewModel;
namespace TechTalk.Droid
{
    public class MainMenuFragment : FragmentBase<IMainMenuViewModel>
    {
        public MainMenuFragment() : base(Resource.Layout.MainMenuView)
        {
        }
    }
}

