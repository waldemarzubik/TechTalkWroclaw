using Foundation;
using System;
using UIKit;
using TechTalk.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace TechTalk.iOS
{
    public partial class SlideOutMenuViewController : BaseViewController<IMainMenuViewModel>
    {
		private Binding<string, string> currentItemBinding;
		private ObservableTableViewSource<string> menuSource;

		public SlideOutMenuViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = EpamStyles.PrimaryColor1;
			menuSource = ViewModel.Menu.GetTableViewSource<string>(
				BindCell, null, () => new TableViewSourceEx());
		
			currentItemBinding = this.SetBinding(() => menuSource.SelectedItem, () => ViewModel.SelectedItem, BindingMode.TwoWay);

			MenuItemTable.Source = menuSource;
		}

		private void BindCell(UITableViewCell cell, string item, NSIndexPath path)
		{
			cell.TextLabel.Text = item;
			cell.BackgroundColor = EpamStyles.PrimaryColor1;
		}



    }
}