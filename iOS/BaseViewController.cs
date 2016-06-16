using System;
using TechTalk.ViewModels;
using UIKit;

namespace TechTalk.iOS
{
	
	public abstract class BaseViewController<T> : UIViewController where T : IBaseViewModel
	{

		protected T ViewModel { get; set; }
		public object Params { get; set; }

		protected virtual void OnCreateBindings()
		{

		}

		public BaseViewController()
		{

		}

		public BaseViewController(IntPtr handle)
		: base(handle)
		{
		}


		public BaseViewController(string nibName, Foundation.NSBundle bundle)
		: base(nibName, bundle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ViewModel = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstanceWithoutCaching<T>();
			OnCreateBindings();
			ViewModel.OnInitialize(Params);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			ViewModel.OnNavigatedTo();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			ViewModel.OnNavigatingFrom();
		}
	}
}

