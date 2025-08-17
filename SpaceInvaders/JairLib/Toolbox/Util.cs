using JairLib.CustomObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collisions.Layers;
using MonoGame.Extended.Input;
using MonoGame.Extended.Tiled.Renderers;
using MonoGameGum;

namespace JairLib.Toolbox
{
    public static class Util
    {
        public static GumService gummy => GumService.Default;
        public static KeyboardStateExtended keyboardState;
        public static ContentManager GlobalContent;
        public static SpriteFont gameFont;
        public static GameState gameState = GameState.Playing;
        public static int GameLevel = MagicNumbers.STARTING_ROUND;

        public static void Load()
        {
            gameFont = GlobalContent.Load<SpriteFont>("Sprites/PrettyPixelBIG");
        }

        public static void Update(GameTime gameTime)
        {
            KeyboardExtended.Update();
            keyboardState = KeyboardExtended.GetState();

        }

        public static void HandleBulletCollision(Player _player, GameTime _gameTime)
        {
            foreach (var monster in MagicNumbers.LEVEL_ONE)
            {
                foreach (var bullet in _player.ammo)
                {
                    if (bullet.rectangle.Intersects(monster.rectangle))
                    {
                        bullet.ResetBullet();
                        monster.ResetMonster();
                        _player.ScoreIncrease(monster);
                    }
                }

                if (monster.rectangle.Y >= MagicNumbers.MONSTER_PASS_HEIGHT)
                {
                    monster.ResetMonster();
                    _player.Yeowch();
                }
            }
        }
    }
}
