using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile {
	class Tile {
		public int ID { get; set; }
		public Vector2 Position { get; set; }

		public Tile(Vector2 position, int id) {
			this.Position = position;
			ID = id;
		}
		public void Draw(SpriteBatch spriteBatch) {
			
		}
	}
}
