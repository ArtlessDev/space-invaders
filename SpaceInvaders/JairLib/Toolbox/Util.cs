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
        public static SpriteFont gameFontSmall;
        public static GameState gameState = GameState.Playing;
        public static int GameLevel = MagicNumbers.STARTING_ROUND;

        public static void Load()
        {
            gameFont = GlobalContent.Load<SpriteFont>("Sprites/PrettyPixelBIG");
            gameFontSmall = GlobalContent.Load<SpriteFont>("Sprites/PrettyPixelSMALL");
        }

        public static void Update(GameTime gameTime)
        {
            KeyboardExtended.Update();
            keyboardState = KeyboardExtended.GetState();

        }

        public static List<Monster> GetCurrentRoundMonsters(Player player)
        {
            if((player.PlayerScore * GameLevel) % MagicNumbers.LEVEL_SCALER == 0 
                && (player.PlayerScore * GameLevel) != 0 
                && MagicNumbers.ADD_MONSTERS)
            {
                MagicNumbers.BASE_LEVEL.Add(new Monster());
                MagicNumbers.BASE_LEVEL.Add(new Monster());
                MagicNumbers.BASE_LEVEL.Add(new Monster());
                MagicNumbers.ADD_MONSTERS = false;

                MagicNumbers.CURRENT_ROUND++;
            }

            return MagicNumbers.BASE_LEVEL;
        }

        public static void HandleBulletCollision(Player _player, GameTime _gameTime)
        {
            var currRound = GetCurrentRoundMonsters(_player);
            foreach (var monster in currRound)
            {
                foreach (var bullet in _player.ammo)
                {
                    if (bullet.rectangle.Intersects(monster.rectangle))
                    {
                        bullet.ResetBullet();
                        monster.Health -= bullet.damageLevel;

                        if (monster.Health <= 0)
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

            if ((_player.PlayerScore * GameLevel) % MagicNumbers.LEVEL_SCALER != 0
                && (_player.PlayerScore * GameLevel) != 0)
            {
                MagicNumbers.ADD_MONSTERS = true;
            }
        }
    }
}
