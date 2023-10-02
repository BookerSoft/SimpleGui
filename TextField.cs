using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace SimpleGui.Controls
{
    class TextField : SFML.Graphics.Drawable
    {

        static SFML.Graphics.RectangleShape controlBox;
        class Field : Text
        {
            public bool clickable = true;
            public Field():base()
            {

            }
        }
        public bool fieldisClickable
        {
            get
            {
                return field.clickable;
            }
        }
        VertexArray caret;
        Field field;
        public Font fontface
        {
            get
            {
                return field.Font;
            }
            set
            {
                field.Font = value;
            }
        }
        public FloatRect bounds
        {
            get
            {
                return controlBox.GetGlobalBounds();
            }
        }
        public FloatRect fieldbounds
        {
            get
            {
                return field.GetGlobalBounds();
            }
        }
        public uint TextSize
        {
            get
            {
                return field.CharacterSize;
            }
            set
            {
                if(TextSize > 0)
                {
                    field.CharacterSize = value;
                }
            }
        }
        public Color TextColor
        {
            get
            {
                return field.FillColor;
            }
            set
            {
                field.FillColor = value;
            }
        }
        public Color background
        {
            get
            {
                return controlBox.FillColor;
            }
            set
            {
                controlBox.FillColor = value;
            }
        }
        public bool needsUpdate, beginEditing, doneEditing;
        
        public TextField(float x, float w,float y,float h)
        {

            controlBox = new RectangleShape();
            controlBox.Position = new SFML.System.Vector2f(x, y);
            controlBox.Size = new SFML.System.Vector2f(w, h);
            controlBox.FillColor = SFML.Graphics.Color.Black;
            controlBox.OutlineColor = SFML.Graphics.Color.Blue;
            controlBox.OutlineThickness = 2;
            field = new Field();
            
            field.CharacterSize = 25;
            field.Position = new SFML.System.Vector2f(controlBox.GetGlobalBounds().Left + 10, controlBox.GetGlobalBounds().Top + 10);
            field.FillColor = SFML.Graphics.Color.White;
            caret = new VertexArray(PrimitiveType.Lines, 2);
            
        }
        public TextField(float x, float w, float y, float h,Font f)
        {

            controlBox = new RectangleShape();
            controlBox.Position = new SFML.System.Vector2f(x, y);
            controlBox.Size = new SFML.System.Vector2f(w, h);
            controlBox.FillColor = SFML.Graphics.Color.Black;
            controlBox.OutlineColor = SFML.Graphics.Color.Blue;
            controlBox.OutlineThickness = 2;
            field = new Field();
            field.Font = f;
            field.CharacterSize = 25;
            field.Position = new SFML.System.Vector2f(controlBox.GetGlobalBounds().Left + 10, controlBox.GetGlobalBounds().Top + 10);
            field.FillColor = SFML.Graphics.Color.White;
            caret = new VertexArray(PrimitiveType.Lines, 2);

        }
        public TextField()
        {
            controlBox = new RectangleShape();
            controlBox.FillColor = SFML.Graphics.Color.Black;
            controlBox.OutlineColor = SFML.Graphics.Color.Blue;
            controlBox.OutlineThickness = 2;
            field = new Field();
            
            field.CharacterSize = 25;
            field.Position = new SFML.System.Vector2f(controlBox.GetGlobalBounds().Left + 10, controlBox.GetGlobalBounds().Top + 10);
            field.FillColor = SFML.Graphics.Color.White;
            caret = new VertexArray(PrimitiveType.Lines, 2);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(controlBox);
            target.Draw(field);
            if (beginEditing && needsUpdate)
            {
                target.Draw(field);
            }
        }
        public void TextEntered(object sender, TextEventArgs e)
        {
            if (e.Unicode == "\r")
            {
                doneEditing = true;
                needsUpdate = false;
                
            }
            else if (e.Unicode == "\b")
            {

                field.DisplayedString = field.DisplayedString.Substring(0,(field.DisplayedString.Length-1));
                needsUpdate = true;
            }
            else
            {
                field.DisplayedString += e.Unicode;
                needsUpdate = true;
            }

        }
        public void MouseEntered(object sender, MouseMoveEventArgs e)
        {
            if (controlBox.GetGlobalBounds().Contains(e.X, e.Y))
            {
                beginEditing = true;
            }
        }
    }
}
