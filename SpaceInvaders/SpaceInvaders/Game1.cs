using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JairLib;
using Gum.Forms.Controls;
using MonoGameGum;
using Gum.Forms;
using JairLib.Toolbox;
using JairLib.CustomObjects;
using SpaceInvaders.Core;
using System.Diagnostics;
using System;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Player _player;
        UpgradeObject test;

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
            Util.gummy.Initialize(this, DefaultVisualsVersion.V2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player();
            Util.Load();
            test = new UpgradeObject(_player);

            #region test gum ui button
            var stackPanel = new StackPanel();
            stackPanel.AddToRoot();


            var button = new Button();
            stackPanel.AddChild(button);
            stackPanel.X = 50;
            stackPanel.Y = 50;

            button.Width = 100;
            button.Height = 50;
            button.Text = "Hello MonoGame!";
            int clickCount = 0;
            button.Click += (_, _) =>
            {
                clickCount++;
                button.Text = $"Clicked {clickCount} times";
            };
            #endregion
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Util.Update(gameTime);
            //Util.gummy.Update(gameTime);
            //Button button = new Button();

            test.DoUpdate(gameTime, _player);
            test.Destroy(gameTime, _player);
            if (_player.PlayerScore % 1500 == 0 && _player.PlayerScore != 0 && test.GetGoingFlag)
            {

                int upgradeRand = Random.Shared.Next(0, 7);

                test.UpgradeDelegate = test.GetUpgradeMethod(_player, upgradeRand);
                Debug.WriteLine(upgradeRand + ": UPDATED TO: " + test.UpgradeDelegate.Method);

                test.GetGoing(_player);
            }

            GameStateManager.Playing(gameTime, _player);
            GameStateManager.RoundOver(gameTime, _player);
            GameStateManager.UpgradeTime(gameTime, _player);

            base.Update(gameTime);
        }

        #region Draw Function
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            GameFunctions.RoundOverDraw(_spriteBatch);
            GameFunctions.PlayingDraw(_spriteBatch, _player);

            _spriteBatch.Draw(test.texture, test.rectangle, test.color);

            //Util.gummy.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
