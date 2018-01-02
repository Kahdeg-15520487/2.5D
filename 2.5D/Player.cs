using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utilities;
using System.Collections;

namespace IsometricTile {
	class Player {
		private int direction;
		private SpriteSheetMap spriteSheet;
		private Vector2 position;
		public Vector2 IsoPosition { get => position; }
		public Vector2 WorldPosition { get => CoordinateHelper.ScreenToWorld(position); }

		public Vector2 Origin;

		/// <summary>
		/// speed of the air plane per second
		/// </summary>
		public readonly float Speed;

		public Vector2 Velocity;

		public Player(Vector2 pos, SpriteSheetMap sprite, Vector2 origin, int speed = 10) {
			//if (directionClamp is null) {
			//	directionClamp = new Range(0, 360, 15);
			//}
			direction = 3;
			position = CoordinateHelper.WorldToScreen(pos);
			spriteSheet = sprite;
			Speed = speed / 60f;
			Velocity = Vector2.Zero;
			Origin = origin;
		}

		public void Update() {
			//w/s for acelerate and decelerate
			//a/d for turn left/right
			var acceleration = 0f;
			if (HelperFunction.IsKeyDown(Keys.W)) {
				acceleration -= Speed;
			}
			if (HelperFunction.IsKeyDown(Keys.S)) {
				acceleration += Speed;
				if (acceleration > 0) {
					acceleration = 0;
				}
			}
			if (HelperFunction.IsKeyDown(Keys.D)) {
				direction -= 1;
				if (direction < 0) {
					direction = 23;
				}
				Console.WriteLine(direction * 15);
			}
			if (HelperFunction.IsKeyDown(Keys.A)) {
				direction += 1;
				if (direction >= 24) {
					direction = 0;
				}
				Console.WriteLine(direction * 15);
			}
			var angle = HelperFunction.DegreeToRadian(direction * 15 - 45);

			HelperFunction.RotateVector(Velocity, angle);

			var accelVector = new Vector2((float)Math.Cos(angle), -(float)Math.Sin(angle)) * acceleration;
			
			Velocity += accelVector;

			position += CoordinateHelper.ScreenToWorld(Velocity);

			Console.WriteLine(direction * 15);
			Console.WriteLine(acceleration);
			Console.WriteLine(Velocity);

			//Console.WriteLine("Norm position: " + position);
			//Console.WriteLine("Iso pos: " + CoordinateHelper.ScreenToWorld(position));
		}

		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(spriteSheet.SpriteSheet, position, spriteSheet[direction.ToString()], Color.White, 0f, Origin, 0.25f, SpriteEffects.None, LayerDepth.Unit);
		}
	}
}
