using System;
using System.Collections.Generic;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk
{
	public abstract class NavigationBase : INavigation
	{
		public abstract void GoBack();

		public abstract void NavigateTo<T>() where T : IBaseViewModel;

		public abstract void NavigateTo<T, G>(G parameter) where T : IBaseViewModel;

		protected Dictionary<Type, Type> NavigationPages;

		protected abstract void InitPagesMappings();

	}
}

