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
    class Player : Playerbase
    {
        KeyboardState oldKState;
        List<Bullets> BulletsList;
        Texture2D bulletTex;

        public Player(Texture2D tex, List<Bullets> bulletList, Texture2D bulleTex) : base(tex)
        {
            bulletTex = bulleTex;
            BulletsList = bulletList;
            hitbox = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Right))
                xwingpos.X += 10;
            if (kstate.IsKeyDown(Keys.Left))
                xwingpos.X -= 10;
            if (kstate.IsKeyDown(Keys.Up))
                xwingpos.Y -= 10;
            if (kstate.IsKeyDown(Keys.Down))
                xwingpos.Y += 10;
            if (kstate.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                BulletsList.Add(new Bullets(bulletTex, xwingpos));
            }

            if (xwingpos.X <= 0)
                xwingpos.X = 0;
            if (xwingpos.X >= 1780)
                xwingpos.X = 1780;
            if (xwingpos.Y <= 0)
                xwingpos.Y = 0;
            if (xwingpos.Y >= 930)
                xwingpos.Y = 930;


            hitbox.Location = xwingpos.ToPoint();

            oldKState = kstate;
        }

    }
}









