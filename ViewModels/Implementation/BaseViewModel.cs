using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public abstract class BaseViewModel : ViewModelBase, IBaseViewModel
    {
        private INavigation _navigationService;

        public INavigation NavigationService => _navigationService;

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

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}