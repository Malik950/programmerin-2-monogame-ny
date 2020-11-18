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


            oldKState = kstate;
        }

    }
}









