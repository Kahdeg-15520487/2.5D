#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utilities;
#endregion

namespace IsometricTile {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game {
		GraphicsDeviceManager graphics;

		Map map;
		Camera camera;
		Player player;
		Texture2D highLight;

		public Game1() : base() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			CONTENT_MANAGER.Content = Content;

			graphics.PreferredBackBufferWidth = 1280;
			graphics.PreferredBackBufferHeight = 720;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize() {
			// TODO: Add your initialization logic here
			graphics.ApplyChanges();
			this.IsMouseVisible = true;
			camera = new Camera(GraphicsDevice.Viewport);
			player = new Player();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			CONTENT_MANAGER.spriteBatch = new SpriteBatch(GraphicsDevice);

			CONTENT_MANAGER.LoadSprites("Tile1", "Tile2", "Tile3", "Tile4", "Tile5");
			CONTENT_MANAGER.LoadSpriteSheet("Player", 400, 200);

			map = new Map(new int[,]{
				{1,1,2,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0},
				{1,1,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0},
				{2,1,1,1,1,1,1,1,1,1,1,1,2,0,0,2,2,2,2,2},
				{0,2,2,2,2,2,2,1,1,1,1,1,2,2,2,2,1,1,1,1},
				{0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1},
				{0,0,0,0,0,0,2,1,1,1,1,1,2,2,2,2,1,1,1,1},
				{0,0,0,0,0,0,2,2,2,2,2,2,2,0,0,2,2,1,2,2},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,2,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
			}, 50);

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
			Content.Unload();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			MouseState ms = Mouse.GetState();
			if (ms.LeftButton == ButtonState.Pressed) {
				Console.WriteLine(CoordinateHelper.ScreenToWorld(ms.Position.ToVector2()));
				Console.WriteLine(CoordinateHelper.GetTileCoordinates(CoordinateHelper.ScreenToWorld(ms.Position.ToVector2()), 50));
			}

			player.Update();
			//camera.Centre = player.Position;
			camera.Update();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);

			CONTENT_MANAGER.spriteBatch.Begin(SpriteSortMode.Deferred,
							  BlendState.AlphaBlend,
							  transformMatrix: camera.Transform);
			map.Draw(CONTENT_MANAGER.spriteBatch);
			player.Draw(CONTENT_MANAGER.spriteBatch);
			CONTENT_MANAGER.spriteBatch.End();

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
