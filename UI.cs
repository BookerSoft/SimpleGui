using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace SimpleGui
{
    public class UI : Drawable
    {
        static RenderWindow Window;
        static int ddcnt = 1, tfcnt = 1, lblcnt = 1, bucnt = 1;
        static List<Controls.Button> myButtons;
        static List<Controls.DropDown> myDropDowns;
        static List<Controls.Label> myLabels;
        static List<Controls.TextField> myTextBoxes;
        static Font uiFont;
        public Font font
        {
            get
            {
                return uiFont;
            }
            set
            {
                uiFont = value;

            }

        }
        public List<object> members;
        public Text getLabel(int i)
        {
            return myLabels[i];
        }
        public Controls.Button getButton(int id)
        {
            return myButtons[id];
        }
        public Controls.DropDown GetDropDown(int i)
        {
            return myDropDowns[i];
        }
        public UI(RenderWindow window, string fontPath, int dd, int tf, int lbl, int butt)
        {
            uiFont = new Font(fontPath);




            //Section - Init Empty objects
            members = new List<object>(tf + dd + lbl + butt);
            if (dd > 0)
            {
                myDropDowns = new List<Controls.DropDown>(dd);
                for (int i = 0; i < dd; i++)
                {
                    myDropDowns.Insert(i, new Controls.DropDown(5));
                    myDropDowns[i].ItemFont(i, uiFont);
                    

                }
            }
            if (tf > 0)
            {
                myTextBoxes = new List<Controls.TextField>(tf);
                for (int i = 0; i < tf; i++)
                {
                    myTextBoxes.Insert(i, new Controls.TextField());
                    myTextBoxes[i].fontface = uiFont;


                }

            }
            if (lbl > 0)
            {
                myLabels = new List<Controls.Label>(lbl);
                for(int i = 0; i < myLabels.Capacity; i++)
                {
                    myLabels.Insert(i, new Controls.Label());
                    myLabels[i].Font = uiFont;
                }
            }
            if (butt > 0)
            {
                myButtons = new List<Controls.Button>(butt);
                for(int i = 0; i < myButtons.Capacity;i++)
                {
                    myButtons.Insert(i, new Controls.Button(0));
                    myButtons[i].fontface = uiFont;
                    myButtons[i].TextColor = Color.White;
                    myButtons[i].backColor = Color.Red;
                    
                }
            }

            //end section
            
            

            if (window.IsOpen)
            {
                Window = window;

            }
            else
            {
                System.IO.File.AppendAllText("UI_Log.txt", "Window is null.");
            }
        }
       public void Draw(RenderTarget target, RenderStates states)
        {
           if(myLabels != null)
            {
                foreach (Controls.Label l in myLabels)
                {

                    target.Draw(l);


                }
            }
           if(myButtons != null)
            {
                foreach (Controls.Button b in myButtons)
                {
                    target.Draw(b);
                }
            }
           
           if(myDropDowns != null)
            {
                foreach (Controls.DropDown d in myDropDowns)
                {
                    target.Draw(d);
                }
            }
           if(myTextBoxes != null)
            {
                foreach (Controls.TextField t in myTextBoxes)
                {
                    target.Draw(t);
                }
            }
           
        }
        public virtual void MouseMoved(object sender, SFML.Window.MouseMoveEventArgs e)
        {

        }
        public virtual void LeftButtonPressed(object sender, MouseButtonEventArgs e)
        {
            
        }
        public virtual void closeSrc(object sender, MouseMoveEventArgs e)
        {
            Window.Close();
        }
    }
}
