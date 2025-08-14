using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collisions.Layers;
using MonoGame.Extended.Input;

namespace JairLib
{
    public static class Util
    {
        public static KeyboardStateExtended keyboardState;
        public static ContentManager GlobalContent;
        public static SpriteFont gameFont;

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
            }
        }
    }
}
