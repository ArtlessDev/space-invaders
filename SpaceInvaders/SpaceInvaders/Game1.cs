using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JairLib;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Util.GlobalContent = Content;
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = MagicNumbers.SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = MagicNumbers.SCREEN_HEIGHT;
            _graphics.PreferredBackBufferFormat = SurfaceFormat.Color;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player();
            Util.Load();
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Util.Update(gameTime);

            _player.Update(gameTime);

            foreach (var monster in MagicNumbers.LEVEL_ONE)
            {
                monster.Update(gameTime);
            }
            
            Util.HandleBulletCollision(_player, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_player.texture, _player.rectangle, _player.color);

            foreach (var item in _player.ammo)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            foreach (var item in MagicNumbers.LEVEL_ONE)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            _spriteBatch.DrawString(Util.gameFont, $"Score: {_player.PlayerScore}", new Vector2(MagicNumbers.SCREEN_WIDTH/2, MagicNumbers.SCREEN_HEIGHT-32), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
