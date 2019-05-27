using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewCells
{
    public class TeamViewCell : ViewCell
    {
        Label titleLabel, detailLabel;
        
        public TeamViewCell()
        {
            titleLabel = new Label { FontSize = 18 };
            detailLabel = new Label();
        }
    }
}
