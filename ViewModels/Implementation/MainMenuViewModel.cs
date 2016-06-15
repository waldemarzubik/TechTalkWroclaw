using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.Interfaces;
using TechTalk.ViewModel;
using System.Linq;
using TechTalk.Localization;

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
            Menu = new List<string> { Resources.Gallery, Resources.CoolOption, Resources.ForNoobs, Resources.RushB, Resources.About };
            return base.OnInitialize(parameter);
        }

        public override void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            PropertyChanged += MainMenuViewModel_PropertyChanged;
            if (SelectedItem == null)
            {
                SelectedItem = Menu.First();
            }
        }

        public override void OnNavigatingFrom()
        {
            PropertyChanged -= MainMenuViewModel_PropertyChanged;
            base.OnNavigatingFrom();
        }

        private void MainMenuViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (nameof(SelectedItem).Equals(e.PropertyName) && SelectedItem != null)
            {
                switch (SelectedItem)
                {
                    case "Gallery":
                        NavigationService.NavigateTo<IGalleryViewModel>();
                        break;
                }
            }
        }
    }
}