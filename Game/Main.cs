
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Project1
{
    public class Main
    {
        private Texture2D turtleTexture;
        private Texture2D enemyTexture;
        private Vector2 turtlePos = new Vector2(100, 100);
        private Vector2 turtleVel = new Vector2(1, 0);
        private Vector2 enemyPos = new Vector2(350, 300);
        private Vector2 enemyVel = new Vector2(0, 0);
        private const float TurtleScale = 0.2f;
        private const float EnemyScale = 0.2f;
        public Main(ContentManager content)
        {
            Debug.WriteLine("initialize");
            LoadContent(content);
        }
        private void LoadContent(ContentManager content)
        {
            turtleTexture = content.Load<Texture2D>("alien");
            enemyTexture = content.Load<Texture2D>("Space-Invaders-PNG-Transparent-Image");
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A)) {
                enemyVel.X = -1;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D)) {
                enemyVel.X = 1;
            }
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) {
                enemyVel.Y = -1;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) {
                enemyVel.Y = 1;
            }
            enemyPos += enemyVel;
            enemyVel = Vector2.Zero;
            turtlePos += turtleVel;
            if (turtlePos.X > 700 || turtlePos.X < 0)
            {
                turtleVel.X *= -1;
                turtlePos.Y += 50;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(turtleTexture, turtlePos, null, Color.White, 0f, Vector2.Zero, TurtleScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(enemyTexture, enemyPos, null, Color.White, 0f, Vector2.Zero, EnemyScale, SpriteEffects.None, 0f);
            spriteBatch.End();

        }
    }
}