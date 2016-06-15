using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.Interfaces;
using TechTalk.ViewModel;

namespace TechTalk.ViewModels.Implementation
{
    public class MainMenuViewModel : BaseViewModel, IMainMenuViewModel
    {
        private List<string> _menu;
        private string _selectedItem;


        public MainMenuViewModel(INavigation navigationService) : base(navigationService)
        {
        }

        public List<string> Menu
        {
            get { return _menu; }
            set { SetProperty(ref _menu, value); }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public override Task OnInitialize(object parameter)
        {
            Menu = new List<string> { "Gallery", "Cool option", "For noobs", "Rush B", "About" };
            NavigationService.NavigateTo<IGalleryViewModel>();
            return base.OnInitialize(parameter);
        }
    }
}