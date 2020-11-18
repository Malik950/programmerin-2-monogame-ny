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
        protected float rotation;


        public Vector2 Position;
        public Vector2 Origin;

        public Vector2 Direction;
        public float Rotationvelocity = 3f;
        public float LinearVelocity = 4f;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public Bullets(Texture2D tex, Vector2 startPos) : base(tex)
        {
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
            Position = startPos;
        }

        public override void Update()
        {
            Position += new Vector2(0, -1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }

        public bool isVisible;

    }
}
