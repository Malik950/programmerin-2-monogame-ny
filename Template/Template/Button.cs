using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
namespace Template
    {
       public class Button
        {
            Texture2D btnTexture;
            Vector2 position;
            Rectangle rectangle;

            Color colour = new Color(255, 255, 255, 255);

            bool down;
            public bool isClicked;

            public Button()
            {

            }

            public void Load(Texture2D newTexture, Vector2 newPosition)
            {
                btnTexture = newTexture;
                position = newPosition;
            }

            public void Update(MouseState mouse)
            {
                mouse = Mouse.GetState();

                rectangle = new Rectangle((int)position.X, (int)position.Y, btnTexture.Width, btnTexture.Height);

                Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if (mouseRectangle.Intersects(rectangle))
                {
                    if (colour.A == 255) down = false;
                    if (colour.A == 0) down = true;
                    if (down) colour.A += 3; else colour.A -= 3;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        isClicked = true;
                        colour.A = 255;
                    }
                }
                else if (colour.A < 255)
                    colour.A += 3;
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(btnTexture, rectangle, colour);
            }
        }
    }
}

