#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utilities;
using Utilities.UI;
using Utilities.Noise;
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

		Canvas canvas;

		public Game1() : base() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			CONTENT_MANAGER.Content = Content;

			graphics.PreferredBackBufferWidth = 1366;
			graphics.PreferredBackBufferHeight = 768;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges();
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

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			CONTENT_MANAGER.spriteBatch = new SpriteBatch(GraphicsDevice);

			CONTENT_MANAGER.LoadSprites("tile0", "tile1", "tile2", "tile3");
			CONTENT_MANAGER.LoadSpriteSheet("Player", 800, 800);
			CONTENT_MANAGER.LoadFont("defaultFont");

			player = new Player(new Vector2(-350, 350), CONTENT_MANAGER.SpriteSheets["Player"], new Vector2(100, 100),20);

			SimplexNoise.Seed = 0;
			var noise = SimplexNoise.Calc2D(100, 100, 0.1f);

			int[,] mapdata = new int[100, 100];
			for (int x = 0; x < 100; x++) {
				for (int y = 0; y < 100; y++) {
					var t = noise[x, y];
					if (0 <= t && t <= 63) {
						mapdata[x, y] = 0;
					}
					else if (64 < t && t <= 127) {
						mapdata[x, y] = 1;
					}
					else if (128 < t && t < 191) {
						mapdata[x, y] = 2;
					}
					else {
						mapdata[x, y] = 3;
					}
				}
			}

			map = new Map(mapdata, 50);

			// TODO: use this.Content to load your game content here
		}

		void InitUI() {
			canvas = new Canvas();



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

			CONTENT_MANAGER.CurrentInputState = new InputState(Mouse.GetState(), Keyboard.GetState());

			if (HelperFunction.IsLeftMousePressed()) {
				var mousepos = CoordinateHelper.ScreenToWorld(CONTENT_MANAGER.CurrentInputState.mouseState.Position.ToVector2());
				Console.WriteLine(mousepos);
				Console.WriteLine(CoordinateHelper.GetTileCoordinates(mousepos, 50));
			}

			player.Update();
			camera.Centre = player.IsoPosition;
			camera.Update();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.LightSeaGreen);

			CONTENT_MANAGER.spriteBatch.Begin(SpriteSortMode.Deferred,
							  BlendState.AlphaBlend,
							  transformMatrix: camera.Transform);
			map.Draw(CONTENT_MANAGER.spriteBatch);
			player.Draw(CONTENT_MANAGER.spriteBatch);
			CONTENT_MANAGER.spriteBatch.Draw(CONTENT_MANAGER.Sprites["tile0"], new Vector2(-100,-100),null, Color.White,0f,Vector2.Zero,0.1f,SpriteEffects.None,LayerDepth.GuiBackground);
			CONTENT_MANAGER.spriteBatch.End();

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
