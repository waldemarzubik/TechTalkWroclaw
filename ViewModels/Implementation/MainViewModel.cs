using System;
using GalaSoft.MvvmLight.Views;

namespace TechTalk.ViewModels.Implementation
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}