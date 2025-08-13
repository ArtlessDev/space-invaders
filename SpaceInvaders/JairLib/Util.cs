using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Input;

namespace JairLib
{
    public static class Util
    {
        public static KeyboardStateExtended keyboardState;
        public static ContentManager GlobalContent;

        public static void Update(GameTime gameTime)
        {
            KeyboardExtended.Update();
            keyboardState = KeyboardExtended.GetState();

        }
    }
}
