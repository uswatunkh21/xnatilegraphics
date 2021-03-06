using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace TileEngineTest
{
    public class InGameGui : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteFont font;
        TiledBackground tiledBackground;
        SpriteBatch spriteBatch;

        public InGameGui(Game game, TiledBackground tiledBackground)
            : base(game)
        {
            this.tiledBackground = tiledBackground;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        
        public InGameGui(Game game)
            : this(game, null)
        {
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("Lucida Console");

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            Point p = tiledBackground.SelectedTile;
            spriteBatch.DrawString(font, "Hai Wurldz. You have selected tile " + p.X + "," + p.Y + ".", new Vector2(1.0f, 1.0f), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (spriteBatch != null)
            {
                spriteBatch.Dispose();
            }
            if (tiledBackground != null)
            {
                tiledBackground.Dispose();
            }
        }
    }
}