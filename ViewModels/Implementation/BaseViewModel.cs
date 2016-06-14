using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public abstract class BaseViewModel : ViewModelBase, IBaseViewModel
    {
        private INavigation _navigationService;

        private INavigation NavigationService => _navigationService;

        public BaseViewModel(INavigation navigationService)
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