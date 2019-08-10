using System;
using CoreGraphics;
using System.Collections.Generic;
using UIKit;

namespace ITDB
{
    public partial class ViewController : UIViewController
    {
        // creating objects for using the following
        UITableView table;
        TableSource tableSource;
        List<TableItem> tableItems;
        UISearchBar searchBar;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        // implementing this method for my search bar so it can perform search action
        private void searchTable()
        {
            //search action taking place 
            tableSource.PerformSearch(searchBar.Text);

            // refreshing my table
            table.ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // setting the title of the app
            Title = "Search A Place";

            // declaring my search bar and setting its properties
            searchBar = new UISearchBar();
            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            searchBar.TextChanged += (sender, e) =>
            {
                // calling the search method when user types on search bar.
                searchTable();
            };

            table = new UITableView(new CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20));
            tableItems = new List<TableItem>();

            // populating my table with some data containing images and title
            tableItems.Add(new TableItem("Adelaide, Australia") { ImageName = "adelaide.jpg" });
            tableItems.Add(new TableItem("Agra, India") { ImageName = "agra.jpg" });
            tableItems.Add(new TableItem("Brisbane, Australia") { ImageName = "brisbane.jpg" });
            tableItems.Add(new TableItem("Delhi, India") { ImageName = "delhi.jpg" });
            tableItems.Add(new TableItem("Hawaii, USA") { ImageName = "hawaii.jpg" });
            tableItems.Add(new TableItem("Las Vegas, USA") { ImageName = "vegas.jpg" });
            tableItems.Add(new TableItem("London, Europe") { ImageName = "london.jpg" });
            tableItems.Add(new TableItem("Los Angeles, USA") { ImageName = "angeles.jpg" });
            tableItems.Add(new TableItem("Melbourne, Australia") { ImageName = "melbourne.jpg" });
            tableItems.Add(new TableItem("Miami, USA") { ImageName = "miami.jpg" });
            tableItems.Add(new TableItem("Mumbai, India") { ImageName = "mumbai.jpg" });
            tableItems.Add(new TableItem("Paris, Europe") { ImageName = "paris.jpg" });
            tableItems.Add(new TableItem("Rome, Europe") { ImageName = "rome.jpg" });
            tableItems.Add(new TableItem("Shimla, India") { ImageName = "shimla.jpg" });
            tableItems.Add(new TableItem("Sydney, Australia") { ImageName = "sydney.jpg" });
            tableItems.Add(new TableItem("Venice, Europe") { ImageName = "venice.jpg" });

            tableSource = new TableSource(tableItems);
            table.Source = tableSource;

            // adding searchbar to header of the table
            table.TableHeaderView = searchBar;

            // adding table to the view
            Add(table);

            // removing all the extra borders OR empty cells from the table view
            table.TableFooterView = new UIView(CoreGraphics.CGRect.Empty);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        partial void UIBarButtonItem3800_Activated(UIBarButtonItem sender)
        {
            throw new NotImplementedException();
        }
    }
}