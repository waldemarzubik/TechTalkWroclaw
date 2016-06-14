using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace TechTalk.ViewModels.Implementation
{
    public abstract class BaseViewModel : ViewModelBase, IBaseViewModel
    {
        private INavigationService _navigationService;

        private INavigationService NavigationService => _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual async Task OnInitialize(object parameter)
        {
        }

        public virtual void OnNavigatedTo()
        {
        }

        public virtual void OnNavigatingFrom()
        {
        }
    }
}