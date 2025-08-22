using JairLib.CustomObjects;
using JairLib.Toolbox;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.Core
{
    public static class GameFunctions
    {
        //need to place these draw functions into its own method for playing phase

        public static void PlayingDraw(SpriteBatch _spriteBatch, Player _player)
        {
            if (Util.gameState != GameState.Playing)
                return;
            _spriteBatch.Draw(_player.texture, _player.rectangle, _player.color);

            foreach (var item in _player.ammo)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            foreach (var item in MagicNumbers.BASE_LEVEL)
            {
                _spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }

            _spriteBatch.DrawString(Util.gameFontSmall, $"Score: {_player.PlayerScore}\nCurrent Round: {MagicNumbers.CURRENT_ROUND}", new Vector2(MagicNumbers.SCREEN_WIDTH-200, MagicNumbers.SCREEN_HEIGHT - 64), Color.White);
            _spriteBatch.DrawString(Util.gameFont, $"Player HP: {_player.PlayerHealth}", new Vector2(MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, MagicNumbers.SCREEN_HEIGHT - 32), Color.White);
            _spriteBatch.DrawString(Util.gameFontSmall, $"Move: [A/LEFT] and [D/RIGHT] Shoot: [SPACE]", new Vector2(16, MagicNumbers.SCREEN_HEIGHT - 64), Color.White);

        }

        public static void RoundOverDraw(SpriteBatch _spriteBatch, Player player)
        {
            if (Util.gameState != GameState.RoundOver)
                return;

            //make a continue button
            //make a reset button
            //

            _spriteBatch.DrawString(Util.gameFont, $"Your Score: {player.PlayerScore.ToString()}", new Vector2(MagicNumbers.SCREEN_WIDTH / 3, MagicNumbers.SCREEN_HEIGHT / 2), Color.White);
            _spriteBatch.DrawString(Util.gameFont, "Round Over", new Vector2(MagicNumbers.SCREEN_WIDTH / 3  , MagicNumbers.SCREEN_HEIGHT - 32), Color.White);

        }
    }
}
