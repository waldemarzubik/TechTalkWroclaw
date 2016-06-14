using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        public MainViewModel(INavigation navigationService) : base(navigationService)
        {
        }
    }
}