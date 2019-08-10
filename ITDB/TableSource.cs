using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace ITDB
{
    // this class implements the abstract class - UITableViewSource.
    // Here I have defind some basic functions for my TableView
    public class TableSource : UITableViewSource
    {
        private List<TableItem> tableView = new List<TableItem>();
        private List<TableItem> searchItems = new List<TableItem>();
        protected string cellIdentifier = "TableCell";

        public TableSource(List<TableItem> items)
        {
            this.tableView = items;
            this.searchItems = items;
        }

        // this method checks for the number of rows present in a section
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return searchItems.Count;
        }

        // this method defines the cell to be rendered for a particular row
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // saving memory by using recycled cell
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

            var cellStyle = UITableViewCellStyle.Default;
            

            // create new cell if no cell is available to use 
            if (cell == null)
            {
                cell = new UITableViewCell(cellStyle, cellIdentifier);
            }

            cell.TextLabel.Text = searchItems[indexPath.Row].Title;
            cell.ImageView.Image = UIImage.FromBundle("" + searchItems[indexPath.Row].ImageName);

            return cell;
        }

        // this method finds out the number of sections
        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        // this method converts the entered text in search bar to all lower case letters to implement a search
        public void PerformSearch(string searchText)
        {
            searchText = searchText.ToLower();
            this.searchItems = tableView.Where(x => x.Title.ToLower().Contains(searchText)).ToList();
        }

        /* This functions highlights the list item that user tapped. */
        
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
        }
    }
}
