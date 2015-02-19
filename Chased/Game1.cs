#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;
#endregion

namespace Chased
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        int count = 0;
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Player player;
        public List<Platform> platforms = new List<Platform>();
        public List<Platform> removable = new List<Platform>();
        public List<Hazard> hazards = new List<Hazard>();
        public Random r = new Random(200);
        public static SpriteFont font;
        //Texture2D player;
        //Rectangle playerLoc;
        //double time;
        //int timer = 0;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 700;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = false;

            System.Diagnostics.Debug.WriteLine(GamePad.GetState(PlayerIndex.One).IsConnected);
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
            font = Content.Load<SpriteFont>("Fonts/Arial"); 
            //Texture2D screen = Content.Load<Texture2D>("screen.png");
            Player.LoadContent(Content);
            Platform.LoadContent(Content);
            Hazard.LoadContent(Content);



            player = new Player(200, 200);
            platforms.Add(new Platform(800, 400));
            platforms.Add(new Platform(700, 400));
            platforms.Add(new Platform(600, 400));
            platforms.Add(new Platform(500, 400));
            platforms.Add(new Platform(400, 400));
            platforms.Add(new Platform(300, 400));
            platforms.Add(new Platform(200, 400));
            platforms.Add(new Platform(100, 400));
            platforms.Add(new Platform(000, 400));

            hazards.Add(new Hazard(0, 800, this));

            System.Diagnostics.Debug.Write("Done loading");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            foreach (Hazard d in hazards)
            {
                d.update(state, keyboard, this, gameTime);
            }
            foreach(Platform p in platforms)
            {
                p.update(state, keyboard, this, gameTime);
                if(p.bounds.X < -600)
                {
                    removable.Add(p);
                }
            }
            foreach(Platform p in removable)
            { 
                System.Diagnostics.Debug.WriteLine("removing " + p.ToString());
                platforms.Remove(p);
            }
            removable.Clear();
            count++;
            if (count >= 30)
            {
                count = 0;
                
                Int32 y = (Int32)(r.NextDouble() * graphics.PreferredBackBufferHeight/50.0) * 50;
                if (r.NextDouble() > 0.1)
                {
                    platforms.Add(new Platform(graphics.PreferredBackBufferWidth, y));
                }
                else
                {
                    platforms.Add(new Platform(graphics.PreferredBackBufferWidth, y, Platform.large_platform));
                }
            }
            player.update(state, keyboard, this, gameTime);
            //Thread.Sleep(100);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();   
            foreach (Platform p in platforms)
            {
                p.draw(spriteBatch);
            }
            foreach (Hazard h in hazards)
            {
                h.draw(spriteBatch);
            }
            player.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
