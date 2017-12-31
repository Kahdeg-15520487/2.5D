using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile {
	class Player {
		private Texture2D texture;
		private Vector2 position = CoordinateHelper.WorldToScreen(new Vector2(0, 150));
		public void Load(ContentManager Content) {
			texture = Content.Load<Texture2D>("Player");
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
			spriteBatch.Draw(texture, position, Color.White);
		}
	}
}
