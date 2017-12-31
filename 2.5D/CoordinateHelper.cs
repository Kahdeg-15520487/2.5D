using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    static class CoordinateHelper
    {
        public static Vector2 WorldToScreen(Vector2 point)
        {
			return new Vector2() {
				X = (2 * point.Y + point.X) / 2,
				Y = (2 * point.Y - point.X) / 2
			};
        }

        public static Vector2 ScreenToWorld(Vector2 point)
        {
			return new Vector2 {
				X = point.X - point.Y,
				Y = (point.X + point.Y) / 2
			};
        }

        public static Vector2 GetTileCoordinates(Vector2 point, int height)
        {
			return new Vector2 {
				X = (float)Math.Floor(point.X / height),
				Y = (float)Math.Floor(point.Y / height)
			};
        }
    }
}
