using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Enemies
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        protected Rectangle hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }

        public bool isVisible = true;

        Random random = new Random();
        int randX, randY;

        Point size = new Point(70, 50);

        public Enemies(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

            randY = random.Next(50, 50);
            randX = random.Next(50, 50);

            velocity = new Vector2(randX, randY);
        }

        public Enemies()
        {
        }

        public void Update()
        {
            position.Y++;

            hitbox = new Rectangle(position.ToPoint(), size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }


    }
}
