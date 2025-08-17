using JairLib.CustomObjects;
using JairLib.Toolbox;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public static class Globals
    {
        public static void PlayingDraw(SpriteBatch _spriteBatch, Player _player)
        {
            if (Util.gameState != GameState.Playing)
                return;
            //need to place these draw functions into its own method for playing phase
            _spriteBatch.Draw(_player.texture, _player.rectangle, _player.color);

            foreach (var item in _player.ammo)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            foreach (var item in MagicNumbers.LEVEL_ONE)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            _spriteBatch.DrawString(Util.gameFont, $"Score: {_player.PlayerScore}", new Vector2(MagicNumbers.SCREEN_WIDTH / 2, MagicNumbers.SCREEN_HEIGHT - 32), Color.White);
            _spriteBatch.DrawString(Util.gameFont, $"Player HP: {_player.PlayerHealth}", new Vector2(MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, MagicNumbers.SCREEN_HEIGHT - 32), Color.White);

        }

        public static void RoundOverDraw(SpriteBatch _spriteBatch)
        {
            if (Util.gameState != GameState.RoundOver)
                return;

            //make a continue button
            //make a reset button
            //

            _spriteBatch.DrawString(Util.gameFont, "Round Over", new Vector2(MagicNumbers.SCREEN_WIDTH / 2, MagicNumbers.SCREEN_HEIGHT - 32), Color.White);

        }
    }
}
