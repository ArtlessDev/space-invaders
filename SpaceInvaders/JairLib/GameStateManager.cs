using JairLib.CustomObjects;
using JairLib.Toolbox;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collisions.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib
{
    public static class GameStateManager
    {
        public static void RoundOver(GameTime gameTime, Player _player)
        {
            if (Util.gameState != GameState.RoundOver)
                return;


        }

        public static void Playing(GameTime gameTime, Player _player)
        {
            if (Util.gameState != GameState.Playing)
                return;

            _player.Update(gameTime);

            foreach (var monster in MagicNumbers.BASE_LEVEL)
            {
                monster.Update(gameTime);
            }

            Util.HandleBulletCollision(_player, gameTime);
        }

        public static void UpgradeTime(GameTime gameTime, Player _player)
        {
            if (Util.gameState != GameState.UpgradeTime)
                return;

        }
    }
}
