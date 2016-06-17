using System;
using System.Collections.Generic;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk
{
	public abstract class NavigationBase : INavigation
	{

		public virtual void GoBack()
		{
			throw new NotImplementedException();
		}

		public virtual void NavigateTo<T>() where T : IBaseViewModel
		{
			InternalNavigation<T, object>(null);
		}

		public virtual void NavigateTo<T, G>(G parameter) where T : IBaseViewModel
		{
			InternalNavigation<T, G>(parameter);
		}

		protected Dictionary<Type, Type> NavigationPages = new Dictionary<Type, Type>();
		protected abstract void InitPagesMappings();

		protected abstract void InternalNavigation<T, G>(G parameter) where T : IBaseViewModel;

	}
}
