using System;
using System.Threading.Tasks;

namespace TechTalk.ViewModels
{
    public interface IBaseViewModel
    {
        Task OnInitialize(object parameter);

        void OnNavigatedTo();

        void OnNavigatingFrom();
    }
}