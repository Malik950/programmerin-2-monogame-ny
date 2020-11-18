using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class Playerbase
    {
        protected Texture2D texture;
        protected Vector2 xwingpos = new Vector2(100, 100);
        protected Rectangle hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }


        public virtual void Update()
        {

        }

        public Playerbase(Texture2D tex)
        {
            texture = tex;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, xwingpos, Color.White);
        }

    }
}
