using System;

namespace TechTalk.Interfaces
{
    public interface INavigation
    {
        string CurrentPageKey
        {
            get;
        }

        void GoBack();

        void NavigateTo(string pageKey);

        void NavigateTo<T>(string pageKey, T parameter);
    }
}