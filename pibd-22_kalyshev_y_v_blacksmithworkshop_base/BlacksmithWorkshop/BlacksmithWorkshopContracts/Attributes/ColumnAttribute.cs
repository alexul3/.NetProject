using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Title { get; private set; }
        public bool Visible { get; private set; }
        public int Width { get; private set; }
        public GridViewAutoSize GridViewAutoSize { get; private set; }
        public bool IsUseAutoSize { get; private set; }
        public bool FormattedDate { get; private set; }
        public bool FormattedNumber { get; private set; }
        public ColumnAttribute(string title = "", bool visible = true, int width = 0, GridViewAutoSize gridViewAutoSize = GridViewAutoSize.None,
            bool isUseAutoSize = false, bool formattedDate = false, bool formattedNumber = false)
        {
            Title = title;
            Visible = visible;
            Width = width;
            GridViewAutoSize = gridViewAutoSize;
            IsUseAutoSize = isUseAutoSize;
            FormattedDate = formattedDate;
            FormattedNumber = formattedNumber;
        }
    }
}
