using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Ball : Sprite
    {
        public bool restart;
        private float timer = 0;
        private float delay = 2000;
        public Ball(Texture2D texture, Vector2 position, Vector2 direction, float speed, Rectangle screen) : base(texture, position, direction, speed, screen)
        {
          
        }

        public override void Update(GameTime gameTime)
        //hastighet ökar 
        {
            BoundsScreen();

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > delay)
            {
                speed++;
                timer = 0;
            }

            base.Update(gameTime);
        }

        private void BoundsScreen()
        {
            //gräns
            if (position.Y < 0 || position.Y > screen.Height - texture.Height)
                direction.Y *= -1;
        }

        public void BoundsPlayer(Player player, Player_AI playerAI)
        {
            //gräns
            if (spriteBox.Intersects(player.spriteBox) || spriteBox.Intersects(playerAI.spriteBox))
                direction.X *= -1;
        }

        public void StartBallPosition()
        {

        }

        public void ScorePlayer(Player player, Player_AI playerAI)
        {
            //poäng räkning
            if (position.X < 0)
            {
                playerAI.Score += 1;
                restart = true;
            }

            if (position.X > screen.Width - texture.Width)
            {
                player.Score += 1;
                restart = true;
            }
                
        }

    }
}
