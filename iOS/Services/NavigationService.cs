using System;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk.iOS
{
	public class NavigationService: INavigation
	{
		private readonly INavigationService navigation;
		public NavigationService()
		{
			//Yep, same name. 
			navigation = new GalaSoft.MvvmLight.Views.NavigationService();
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

