using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utilities;

namespace IsometricTile {
	class Player {
		private Texture2D texture;
		private Direction direction;
		private Dictionary<Direction, Rectangle> spriterects;
		private Vector2 position = CoordinateHelper.WorldToScreen(new Vector2(0, 150));

		public Player() {
			spriterects = new Dictionary<Direction, Rectangle>() {
				{ Direction.North, new Rectangle() },
				{ Direction.NorthEast, new Rectangle() },
				{ Direction.East, new Rectangle() },
				{ Direction.SouthEast, new Rectangle() },
				{ Direction.South, new Rectangle() },
				{ Direction.SouthWest, new Rectangle() },
				{ Direction.West, new Rectangle() },
				{ Direction.NorthWest, new Rectangle() }
			};

		}

		public void Update() {
			KeyboardState ks = Keyboard.GetState();

			if (ks.IsKeyDown(Keys.W)) {
				position += CoordinateHelper.ScreenToWorld(new Vector2(0f, -10f));
			}
			if (ks.IsKeyDown(Keys.S)) {
				position += CoordinateHelper.ScreenToWorld(new Vector2(0f, 10f));
			}
			if (ks.IsKeyDown(Keys.A)) {
				position += CoordinateHelper.ScreenToWorld(new Vector2(-10f, 0f));
			}
			if (ks.IsKeyDown(Keys.D)) {
				position += CoordinateHelper.ScreenToWorld(new Vector2(10f, 0f));
			}

			//Console.WriteLine("Norm position: " + position);
			//Console.WriteLine("Iso pos: " + CoordinateHelper.ScreenToWorld(position));
		}

		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(texture, position, spriterects, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, LayerDepth.Unit);
		}
	}
}
