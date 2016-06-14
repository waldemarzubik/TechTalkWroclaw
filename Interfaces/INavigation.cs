using System;
using TechTalk.ViewModels;

namespace TechTalk.Interfaces
{
    public interface INavigation
    {
        void GoBack();

        void NavigateTo<T>() where T : IBaseViewModel;

        void NavigateTo<T, G>(G parameter) where T : IBaseViewModel;
    }
}