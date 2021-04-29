using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Player_AI : Sprite
    {
        public Player_AI(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle screen) : base(texture, position, direction, speed, screen)
        {
            Score = 0;
        }

        public override void Update(GameTime gameTime)
        {
            BoundsRestrictions();

            base.Update(gameTime);
        }

        public void AI_Movement(Ball ball)
        {
            //Hur AI ska röra sig efter bollen
            if (ball.Direction.X > 0 && ball.Direction.Y > 0)
                direction.Y = 1;
            else if (ball.Direction.X > 0 && ball.Direction.Y < 0)
                direction.Y = -1;
            else
                direction = Vector2.Zero;
        }

        private void BoundsRestrictions()
        {
            //hur långt den kan röra sig gränser
            if (position.Y < 0)
                position.Y = 0;
            if (position.Y > screen.Height - texture.Height)
                position.Y = screen.Height - texture.Height;
        }
    }
}
