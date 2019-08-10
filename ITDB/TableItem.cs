using System;
using UIKit;

namespace ITDB
{
    // this class is used to define the custom style to be used for a cell
    public class TableItem
    {
        public string Title { get; set; }

        public string ImageName { get; set; }

        public UITableViewCellStyle CellStyle
        {
            get { return cellStyle; }
            set { cellStyle = value; }
        }
        protected UITableViewCellStyle cellStyle = UITableViewCellStyle.Default;

        public UITableViewCellAccessory CellAccessory
        {
            get { return cellAccessory; }
            set { cellAccessory = value; }
        }
        protected UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.DetailDisclosureButton;

        public TableItem() { }

        public TableItem(string title)
        { Title = title; }
    }
}

