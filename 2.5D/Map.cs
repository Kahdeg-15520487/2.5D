using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace IsometricTile {
	class Map {
		private Tile[,] Tiles;
		private static Dictionary<int, Texture2D> tileTexture = null;

		public int Width {
			get;
			set;
		}
		public int Height {
			get;
			set;
		}

		public Map(int [,] map, int size) {
			if (tileTexture is null) {
				tileTexture = new Dictionary<int, Texture2D>();
				tileTexture.Add(1, CONTENT_MANAGER.spriteSheets["Tile1"]);
				tileTexture.Add(2, CONTENT_MANAGER.spriteSheets["Tile2"]);
				tileTexture.Add(3, CONTENT_MANAGER.spriteSheets["Tile3"]);
				tileTexture.Add(4, CONTENT_MANAGER.spriteSheets["Tile4"]);
				tileTexture.Add(5, CONTENT_MANAGER.spriteSheets["Tile5"]);
			}

			Generate(map, size);
		}

		private void Generate(int[,] map, int size) {
			Width = map.GetLength(0);
			Height = map.GetLength(1);
			Tiles = new Tile[Height,Width];
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					int tileType = map[x, y];

					if (tileType > 0) {
						Vector2 coord = CoordinateHelper.ScreenToWorld(new Vector2(x * size, y * size));
						Tiles[y, x] = new Tile(coord, tileType);
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch) {
			foreach (Tile tile in Tiles) {
				if (tile is null) {
					continue;
				}
				if (tile.ID == 1)
					spriteBatch.Draw(tileTexture[tile.ID], tile.Position, Color.White);
				else {
					Vector2 temp = tile.Position;
					temp.Y += -7f;
					spriteBatch.Draw(tileTexture[tile.ID], temp, Color.White);
				}
			}
		}
	}
}
