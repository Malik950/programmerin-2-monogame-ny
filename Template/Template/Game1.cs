using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Template.Template;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static int ScreenWidth;
        public static int ScreenHeight;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Texture2D playerTexture;
        Rectangle screen;
        int offsetPlayer = 20;
        int offsetFont = 50;
        SpriteFont scorePlayer, scoreAI;
        Ball ball;
        Texture2D ballTexture;
        Player_AI playerAI;
        Texture2D playerAI_texture;
        Random rand;
        private float _timer;
        SpriteFont Font;
        float time = 0;

        //paus
        bool paused = false;
        Texture2D PausedTexture;
        Rectangle PausedRectangle;
        Button btnPlay, btnQuit;
        bool GamePaused;
        
        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
           graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            rand = new Random();
            graphics.ApplyChanges();
        }

        public enum GameState
        {
            MainMenu,
            ColorSelect,
            Color1,
        }
        GameState Currentstate = GameState.MainMenu;



        protected override void Initialize()
        {
          //  ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;


            base.Initialize();
            graphics.ApplyChanges();
        }

        
        protected override void LoadContent()
        {
            // Alla sprites ritas här
            spriteBatch = new SpriteBatch(GraphicsDevice);

            IsMouseVisible = true;

            playerTexture = Content.Load<Texture2D>("player");
            player = new Player(playerTexture, new Vector2(offsetPlayer, screen.Height / 2 - playerTexture.Height / 2), Vector2.Zero, 5f, screen);

            ballTexture = Content.Load<Texture2D>("Ball");
            ball = new Ball(ballTexture, new Vector2(screen.Width / 2 - ballTexture.Width / 2, screen.Height / 2 - ballTexture.Height / 2), Vector2.Zero, 5f, screen);


            playerAI_texture = Content.Load<Texture2D>("player");
            playerAI = new Player_AI(playerAI_texture, new Vector2(screen.Width / 2 - playerAI_texture.Width / 2, screen.Height / 2 - playerAI_texture.Height / 2), Vector2.Zero, 5f, screen);

            scorePlayer = Content.Load<SpriteFont>("ScoreFont");
            scoreAI = Content.Load<SpriteFont>("ScoreFont");

            Font = Content.Load<SpriteFont>("Time");

            //paus
            PausedTexture = Content.Load<Texture2D>("Paused");
            PausedRectangle = new Rectangle(0, 0, PausedTexture.Width, PausedTexture.Height);
            btnPlay = new Button();
            btnPlay.Load(Content.Load<Texture2D>("Play"), new Vector2(200, 225));
            btnQuit = new Button();
            btnQuit.Load(Content.Load<Texture2D>("Pause"), new Vector2(200, 275));

            Restart();
        }

        private void Restart()
        {
            //De olika hållen bollen rör sig efter kollision
            ball.Position = new Vector2(screen.Width / 2 - ballTexture.Width / 2, screen.Height / 2 - ballTexture.Height / 2);
            int randNumber = rand.Next(0, 4);

            switch (randNumber)
            {
                case 0:
                    ball.Direction = new Vector2(1, 1);
                    break;
                case 1:
                    ball.Direction = new Vector2(1, -1);
                    break;
                case 2:
                    ball.Direction = new Vector2(-1, 1);
                    break;
                case 3:
                    ball.Direction = new Vector2(-1, -1);
                    break;

            }
            ball.Speed = 5;

            ball.restart = false;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_timer <= 0)
            {

            }

            //ritar ut sprites
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            ball.Update(gameTime);
            playerAI.Update(gameTime);
            ball.BoundsPlayer(player, playerAI);
            ball.ScorePlayer(player, playerAI);

            playerAI.AI_Movement(ball);
            playerAI.Update(gameTime);

            if (ball.restart)
                Restart();

            Console.WriteLine();

            switch (Currentstate)
            {
                case GameState.MainMenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        Currentstate = GameState.ColorSelect;
                    break;

                case GameState.ColorSelect:
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                        Currentstate = GameState.MainMenu;
                    break;
            }

            MouseState mouse = Mouse.GetState();

            if (!paused)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    paused = true;
                    btnPlay.isClicked = false;
                }

            }

            else if (paused)
            {
                if (btnPlay.isClicked)
                    paused = false;
                if (btnQuit.isClicked)
                    Exit();

                btnPlay.Update(mouse);
                btnQuit.Update(mouse);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (Currentstate)
            {
                case GameState.MainMenu:
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                        Currentstate = GameState.ColorSelect;
                    break;

                case GameState.ColorSelect:
                    GraphicsDevice.Clear(Color.GreenYellow);
                        Currentstate = GameState.MainMenu;
                    break;
            }

            spriteBatch.Begin();

            spriteBatch.DrawString(scorePlayer, player.Score.ToString(), new Vector2(screen.Width / 2 - 2*offsetFont, offsetFont), Color.White);
            spriteBatch.DrawString(scoreAI, playerAI.Score.ToString(), new Vector2(screen.Width / 2 + offsetFont, offsetFont), Color.White);
            player.Draw(spriteBatch);
                ball.Draw(spriteBatch);
            playerAI.Draw(spriteBatch);

            //Timer
            spriteBatch.DrawString(Font, "Session Time:" + time.ToString("0.00"), new Vector2(100, 50), Color.Black);

            //pause
            if (paused)
            {
                spriteBatch.Draw(PausedTexture, PausedRectangle, Color.White);
                btnPlay.Draw(spriteBatch);
                btnQuit.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
