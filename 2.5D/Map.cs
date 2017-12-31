using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile {
	class Map {
		private Tile[,] Tiles;

		public int Width {
			get;
			set;
		}
		public int Height {
			get;
			set;
		}

		public void Generate(int[,] map, int size) {
			Width = map.GetLength(0);
			Height = map.GetLength(1);
			Tiles = new Tile[Height,Width];
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					int number = map[x, y];

					if (number > 0) {
						Vector2 coord = CoordinateHelper.ScreenToWorld(new Vector2(x * size, y * size));
						Tiles[y, x] = new Tile(coord, number);
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch) {
			foreach (Tile tile in Tiles) {
				if (tile is null) {
					continue;
				}
				tile.Draw(spriteBatch);
			}
		}
	}
}
