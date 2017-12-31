using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsometricTile
{
    class Tile
    {
        private Texture2D texture;
        public static ContentManager Content;

        public int ID
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }

        public Tile(Vector2 position, int id)
        {
            this.Position = position;
            texture = Content.Load<Texture2D>("Tile" + id);
            ID = id;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(ID == 1)
                spriteBatch.Draw(texture, Position, Color.White);
            else
            {
                Vector2 temp = Position;
                temp.Y += -7f;
                spriteBatch.Draw(texture, temp, Color.White);
            }
        }
    }
}
