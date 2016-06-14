using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk.Droid.ClientSpecific
{
    public class NavigationService : INavigation
    {
        private readonly Dictionary<Type, Type> _pages;

        public NavigationService(Dictionary<Type, Type> pages)
        {
            _pages = pages;
        }

        public string CurrentPageKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo<T>() where T : IBaseViewModel
        {
            throw new NotImplementedException();
        }

        public void NavigateTo<T, G>(G parameter) where T : IBaseViewModel
        {
            throw new NotImplementedException();
        }
    }
}