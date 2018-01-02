using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace IsometricTile {
	class Map {
		private Vector2[,] TilePos;
		private int[,] TileType;
		private static Dictionary<int, Texture2D> tileTexture = null;

		public int Width {
			get;
			set;
		}
		public int Height {
			get;
			set;
		}

		public Map(int[,] map, int size) {
			if (tileTexture is null) {
				tileTexture = new Dictionary<int, Texture2D> {
					{ 0, CONTENT_MANAGER.Sprites["tile0"] },
					{ 1, CONTENT_MANAGER.Sprites["tile1"] },
					{ 2, CONTENT_MANAGER.Sprites["tile2"] },
					{ 3, CONTENT_MANAGER.Sprites["tile3"] }
				};
			}

			Generate(map, size);
		}

		private void Generate(int[,] map, int size) {
			Width = map.GetLength(0);
			Height = map.GetLength(1);
			TilePos = new Vector2[Height, Width];
			TileType = new int[Height, Width];
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					TilePos[x, y] = CoordinateHelper.ScreenToWorld(new Vector2(x * size, y * size));
					TileType[x, y] = map[x,y];
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch) {
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					spriteBatch.Draw(tileTexture[TileType[x, y]], TilePos[x, y], null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, LayerDepth.TerrainBase);
				}
			}
		}
	}
}
