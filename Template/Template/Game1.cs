using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D xwing;
        Texture2D bullets;
        Texture2D enemy;
        Texture2D Space;
        public Vector2 xwingpos = new Vector2(100, 300);
        public Vector2 bulletspos = new Vector2(100, 300);
        public Vector2 enemypos = new Vector2(100, 300);
        List<Bullets> bulletList = new List<Bullets>();
        List<Enemies> enemies = new List<Enemies>();
        Random random = new Random();

        Player player;
        Bullets bullet;


        int counter = 1;
        int limit = 50;
        float countDuration = 2f;
        float currentTime = 0f;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            xwing = Content.Load<Texture2D>("xwing");
            bullets = Content.Load<Texture2D>("bullets");
            Space = Content.Load<Texture2D>("Space");
            enemy = Content.Load<Texture2D>("enemy");

            player = new Player(xwing, bulletList, bullets);



            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        float spawn = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Enemies enemy in enemies)
                enemy.Update();

            LoadEnemies();

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;
                currentTime -= countDuration;
            }
            if (counter >= limit)
            {
                counter = 0;
            }

            player.Update();
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randY = random.Next(50, 50);

            if (spawn >= 1)
            {
                spawn = 0;
                if (enemies.Count() < 4)
                    enemies.Add(new Enemies(Content.Load<Texture2D>("enemy"), new Vector2(110, randY)));
            }

            for (int i = 0; i < enemies.Count; i++)
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            foreach (var item in bulletList)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.Draw(Space, new Rectangle(), Color.White);
            foreach (Enemies enemy in enemies)
                enemy.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
