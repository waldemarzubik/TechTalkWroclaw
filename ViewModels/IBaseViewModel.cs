using System;
using System.Threading.Tasks;
using TechTalk.Interfaces;
using System.ComponentModel;

namespace TechTalk.ViewModels
{
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        INavigation NavigationService { get; }

        Task OnInitialize(object parameter);

        void OnNavigatedTo();

        void OnNavigatingFrom();
    }
}