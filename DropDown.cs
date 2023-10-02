using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SimpleGui.Controls
{
    public class DropDown : SFML.Graphics.Drawable
    {
        static int count,DisplayedItems = 5;
        public int itemIdx;
        public List<Text> items;
        
        SFML.Graphics.VertexArray arrow;
        SFML.Graphics.Text label;
        SFML.Graphics.RectangleShape controlBox, menu;
        bool needsDisplay = false;
        
        public SFML.Graphics.FloatRect getBounds()
        {
            return controlBox.GetGlobalBounds();
        }
        public FloatRect ArrowBounds
        {
            get
            {
                return arrow.Bounds;
            }
        }
        public FloatRect MenuBounds
        {
            get
            {
                return menu.GetGlobalBounds();

            }
        }
        public FloatRect LisitemBounds
        {
            get
            {
                return items[itemIdx].GetGlobalBounds();
            }
        }
        
        public void ItemText(int i,string str)
        {
            itemIdx = i;
            ListItemText = str;
        }
        public void ItemColor(int i, Color c)
        {
            itemIdx = i;
            ListItemColor = c;
        }
        public void ItemFont(int i, Font f)
        {
            itemIdx = i;
            itemface = f;
        }
        private string ListItemText
        {
            get
            {
                return items[itemIdx].DisplayedString;
            }
            set
            {
                items[itemIdx].DisplayedString = value;

            }
        }
        private Color ListItemColor
        {
            get
            {
                return items[itemIdx].FillColor;
            }
            set
            {
                items[itemIdx].FillColor = value;
            }
        }

        private Font itemface
        {
            get
            {
                return items[itemIdx].Font;
            }
            set
            {
                items[itemIdx].Font = value;
            }
        }
        public DropDown(float w, float h, float x,float y, int Count)
        {
            
            
            count = Count;
            items = new List<Text>(Count);
            controlBox = new SFML.Graphics.RectangleShape();
            controlBox.Size = new SFML.System.Vector2f(w, h);
            controlBox.Position = new SFML.System.Vector2f(x, y);
            controlBox.FillColor = SFML.Graphics.Color.Black;
            label = new Text();
            label.Position = new SFML.System.Vector2f(controlBox.Position.X + 10, controlBox.Position.Y);
            label.FillColor = SFML.Graphics.Color.White;
            
            label.CharacterSize = 25;
            label.DisplayedString = "Pick an Item";
            arrow = new VertexArray(PrimitiveType.Triangles, 3);
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width + 10, label.GetGlobalBounds().Top), SFML.Graphics.Color.White));
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width+ 30, label.GetGlobalBounds().Top), SFML.Graphics.Color.White));
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width +20, label.GetGlobalBounds().Top + label.GetGlobalBounds().Height), SFML.Graphics.Color.White));
            menu = new RectangleShape();
            menu.Size = new SFML.System.Vector2f(label.GetGlobalBounds().Width, label.GetGlobalBounds().Height * Count);
            menu.Position = new SFML.System.Vector2f(label.Position.X, label.Position.Y + label.GetGlobalBounds().Height + 10);
            menu.FillColor = SFML.Graphics.Color.Black;
            for(int i = 0; i < Count; i++)
            {
                items.Insert(i, new Text());
                items[i].FillColor = SFML.Graphics.Color.White;
                
                items[i].CharacterSize = 15;
                switch (i)
                {
                    case 0:
                        {
                            items[i].Position = new SFML.System.Vector2f(menu.GetGlobalBounds().Left + 1, menu.GetGlobalBounds().Top + 1);
                            
                            break;
                        }
                    default:
                        {
                            items[i].Position = new SFML.System.Vector2f(items[i - 1].Position.X, items[i - 1].Position.Y + 20);

                            break;
                        }
                }
            }
        }
        public DropDown(int Count) //Initializer called by UI Constructor
        {


            count = Count;
            items = new List<Text>(Count);
            controlBox = new SFML.Graphics.RectangleShape();
            
            controlBox.FillColor = SFML.Graphics.Color.Black;
            label = new Text();
            label.Position = new SFML.System.Vector2f(controlBox.Position.X + 10, controlBox.Position.Y);
            label.FillColor = SFML.Graphics.Color.White;
            
            label.CharacterSize = 25;
            label.DisplayedString = "Pick an Item";
            arrow = new VertexArray(PrimitiveType.Triangles, 3);
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width + 10, label.GetGlobalBounds().Top), SFML.Graphics.Color.White));
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width + 30, label.GetGlobalBounds().Top), SFML.Graphics.Color.White));
            arrow.Append(new Vertex(new SFML.System.Vector2f(label.GetGlobalBounds().Left + label.GetGlobalBounds().Width + 20, label.GetGlobalBounds().Top + label.GetGlobalBounds().Height), SFML.Graphics.Color.White));
            menu = new RectangleShape();
            menu.Size = new SFML.System.Vector2f(label.GetGlobalBounds().Width, label.GetGlobalBounds().Height * Count);
            menu.Position = new SFML.System.Vector2f(label.Position.X, label.Position.Y + label.GetGlobalBounds().Height + 10);
            menu.FillColor = SFML.Graphics.Color.Black;
            for (int i = 0; i < Count; i++)
            {
                items.Insert(i, new Text());
                items[i].FillColor = SFML.Graphics.Color.White;
                
                items[i].CharacterSize = 15;
                switch (i)
                {
                    case 0:
                        {
                            items[i].Position = new SFML.System.Vector2f(menu.GetGlobalBounds().Left + 1, menu.GetGlobalBounds().Top + 1);

                            break;
                        }
                    default:
                        {
                            items[i].Position = new SFML.System.Vector2f(items[i - 1].Position.X, items[i - 1].Position.Y + 20);

                            break;
                        }
                }
            }
        }
        public void SetElementPos(float x,float y,float w, float h)
        {
            controlBox.Position = new SFML.System.Vector2f(x, y);
            controlBox.Size = new SFML.System.Vector2f(w, h);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(controlBox);
            target.Draw(label);
            target.Draw(arrow);
            if (needsDisplay)
            {
                target.Draw(menu);
                foreach (Text i in items)
                {
                    target.Draw(i);
                }
            }
        }
        public void arrowClicked(object sender, MouseButtonEventArgs e)
        {
            if (arrow.Bounds.Contains(e.X, e.Y) && !label.GetGlobalBounds().Contains(e.X,e.Y))
            {
                if (!needsDisplay)
                {
                    needsDisplay = true;
                }
                else
                {
                    needsDisplay = false;
                }
                
            }
        }
        public void itemSelected(object sender, MouseButtonEventArgs e)
        {
            foreach(Text i in items)
            {
                if (i.GetGlobalBounds().Contains(e.X, e.Y))
                {
                    label.DisplayedString = i.DisplayedString;
                    label.FillColor = i.FillColor;
                    needsDisplay = false;
                }
            }
        }
    }
}
