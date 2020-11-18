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
    class Bullets : Playerbase
    {

        public Vector2 Origin;

        public float Rotationvelocity = 3f;
        public float LinearVelocity = 4f;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        private Point size = new Point(15, 15);

        public Bullets(Texture2D tex, Vector2 startPos) : base(tex)
        {
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
            xwingpos = startPos;
        }

        public override void Update()
        {
            xwingpos += new Vector2(0, -5);
            hitbox = new Rectangle(xwingpos.ToPoint(), size);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }

        public bool isVisible;

    }
}
