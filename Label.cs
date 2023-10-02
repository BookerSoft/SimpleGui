using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace SimpleGui.Controls
{
    public class Label : Text
    {
        Color hoverColor;
        public Color textColor
        {
            get
            {
                return FillColor;
            }
            set
            {
                FillColor = value;
            }
        }
        public Color MouseOverColor
        {
            get
            {
                return hoverColor;
            }
            set
            {
                hoverColor = value;
            }
        }
        public string Text
        {
            set { DisplayedString = value;
            }
        }
        public Label()
        {
            
        }
    }
}
