using System;
using GalaSoft.MvvmLight.Helpers;

namespace TechTalk.iOS
{
	public class TableViewSourceEx: ObservableTableViewSource<string>
	{
		public override void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var item = GetItem(indexPath);
			SelectedItem = item;
		}

		public override void RowDeselected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			SelectedItem = null;
		}
	}
}

