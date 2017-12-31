using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile {
	class Camera {
		private Matrix transform;
		public Matrix Transform {
			get { return transform; }
		}

		private Vector2 centre;
		public Vector2 Centre { get => centre; set => centre = value; }
		private Viewport viewport;
		private const float cameraSpeed = 5f;

		public Camera(Viewport newViewport) {
			viewport = newViewport;
			centre.X = viewport.Width / 2;
			centre.Y = viewport.Height / 2;
		}

		public void Update() {
			KeyboardState ks = Keyboard.GetState();
			if (ks.IsKeyDown(Keys.Up)) {
				centre.Y -= cameraSpeed;
			}
			else if (ks.IsKeyDown(Keys.Down)) {
				centre.Y += cameraSpeed;
			}
			else if (ks.IsKeyDown(Keys.Left)) {
				centre.X -= cameraSpeed;
			}
			else if (ks.IsKeyDown(Keys.Right)) {
				centre.X += cameraSpeed;
			}

			transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewport.Width / 2), -centre.Y + (viewport.Height / 2), 0));
		}
	}
}
