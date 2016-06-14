using System;
using System.Threading.Tasks;
using TechTalk.Interfaces;

namespace TechTalk.ViewModels
{
    public interface IBaseViewModel
    {
        INavigation NavigationService { get; }

        Task OnInitialize(object parameter);

        void OnNavigatedTo();

        void OnNavigatingFrom();
    }
}