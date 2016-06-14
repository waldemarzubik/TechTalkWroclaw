using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class MainMenuViewModel : BaseViewModel, IMainViewModel
    {
        public MainMenuViewModel(INavigation navigationService) : base(navigationService)
        {
        }
    }
}