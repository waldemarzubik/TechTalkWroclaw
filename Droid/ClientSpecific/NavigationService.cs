using System;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk.Droid
{
    public class NavigationService : NavigationBase
    {
        protected override void InitPagesMappings()
        {
            throw new NotImplementedException();
        }

        protected override void InternalNavigation<T, G>(G parameter)
        {
        }
    }
}

