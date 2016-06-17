using System;
using Foundation;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModel;
using TechTalk.ViewModels;
using UIKit;

namespace TechTalk.iOS
{
	public class NavigationService: NavigationBase
	{
		private UIStoryboard MainStoryboard
		{
			get
			{
				return UIStoryboard.FromName("MainView", NSBundle.MainBundle);
			}
		}

		public NavigationService()
		{
			InitPagesMappings();
		}
		
		protected override void InternalNavigation<T, G>(G parameter) 
		{
			AppDelegate appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;

			lock (NavigationPages)
			{
				var type = NavigationPages[typeof(T)];
	
				var viewController = (BaseViewController<T>)MainStoryboard.InstantiateViewController(type.Name);
				viewController.Params = parameter;
				var mainViewController = appDelegate.Window.RootViewController as MainMenuViewController;
				if (mainViewController != null && mainViewController.CenterPanel.GetType() != viewController.GetType())
				{
					mainViewController.CenterPanel = viewController;
				}

			}
		}

		protected override void InitPagesMappings()
		{
			NavigationPages.Add(typeof(IMainViewModel), typeof(MainMenuViewController));
			NavigationPages.Add(typeof(IMainMenuViewModel), typeof(SlideOutMenuViewController));
			NavigationPages.Add(typeof(IGalleryViewModel), typeof(PictureCollectionViewController));
			NavigationPages.Add(typeof(IPictureViewModel), typeof(PictureViewController));
		}
		
	}
}

