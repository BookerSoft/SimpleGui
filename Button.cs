using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SimpleGui.Controls
{
    public class Button :Drawable
    {
        RectangleShape controlBox;
        CircleShape controlOval;
        Text label;
        int type;
        bool clickable = true;
        public Button(int type)
        {
            switch (type)
            {
                case 0:
                    {
                        //RectButton 
                        controlBox = new RectangleShape();
                        label = new Text();
                        break;
                    }
                case 1:
                    {
                        controlOval = new CircleShape();
                        label = new Text();
                        break;
                    }
            }
        }
        public bool isclickable
        {
            get
            {
                return clickable;
            }
            
        }
        public Font fontface
        {
            get
            {
                return label.Font;
            }
            set
            {
                label.Font = value;
            }
        }
        public string Text
        {
            get
            {
                return label.DisplayedString;
            }
            set
            {
                label.DisplayedString = value;
            }
        }
        public Color TextColor
        {
            set
            {
                label.FillColor = value;
            }
        }
        public Color backColor
        {
            get
            {
                switch (type)
                {
                    case 0:
                        {
                            return controlBox.FillColor;
                            
                        }
                    case 1:
                        {
                            return controlOval.FillColor;
                        }
                    default:
                        {
                            return Color.Transparent;
                        }
                }
            }
            set
            {
                switch (type)
                {
                    case 0:
                        {
                            controlBox.FillColor = value;
                            break;
                        }
                    case 1:
                        {
                            controlOval.FillColor = value;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
       public Button(float r, uint pc, float x,float y,float w,float h ,string l): base()//rounButton initializer
        {
            controlOval = new CircleShape(r, pc);
            controlOval.Position = new SFML.System.Vector2f(x, y);
            controlOval.Scale = new SFML.System.Vector2f((w / controlOval.GetGlobalBounds().Width), 1.0f);
            controlOval.FillColor = Color.Blue;
            label = new Text();
            label.DisplayedString = l;
            label.FillColor = Color.White;
            type = 1;
            label.Position = new SFML.System.Vector2f(controlOval.GetGlobalBounds().Left + (controlOval.GetGlobalBounds().Width / 3), controlOval.GetGlobalBounds().Top);
            
        }
        public Button(float x, float y, float w, float h, string l) : base()//rounButton initializer
        {
            controlBox = new RectangleShape();
            controlBox.Position = new SFML.System.Vector2f(x, y);
            controlBox.Size = new SFML.System.Vector2f(w, h);
            controlBox.FillColor = Color.Black;
            label = new Text();
            label.DisplayedString = l;
            label.FillColor = Color.White;
            type = 0;
            label.Position = new SFML.System.Vector2f(controlBox.GetGlobalBounds().Left + (controlBox.GetGlobalBounds().Width / 3), controlBox.GetGlobalBounds().Top);

        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            if(type == 1)
            {
                target.Draw(controlOval);
                target.Draw(label);
            }else if(type == 0)
            {
                target.Draw(controlBox);
                target.Draw(label);
            }
        }

        
    }
}
