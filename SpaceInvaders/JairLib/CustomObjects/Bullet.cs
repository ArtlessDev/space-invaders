using JairLib.Toolbox;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JairLib.CustomObjects
{
    public class Bullet : IJairObject
    {
        public Bullet(Rectangle _rect)
        {
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/Bullets/bullet");
            color = Color.White;
            rectangle = _rect;
            state = BulletStates.None;
            bulletSpeed = MagicNumbers.BULLET_BASE_SPEED;
            damageLevel = 1 * MagicNumbers.CURRENT_ROUND;
        }

        public string identifier { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2D texture { get; set; }
        public Color color { get; set; }
        public BulletStates state { get; set; }
        public int damageLevel { get; set; }
        public int bulletSpeed { get; set; }
        public BulletType type { get; set; }

        public void Travel()
        {
            if (state == BulletStates.Firing)
                rectangle = new Rectangle(rectangle.X, rectangle.Y - bulletSpeed, rectangle.Width, rectangle.Height);

            if (rectangle.Y <= -50)
                state = BulletStates.Ready;
        }

        public void Hit()
        {
            //TODO: implement bullet hitting enemies
        }

        public void ResetBullet()
        {
            state = BulletStates.Ready;
            rectangle = new Rectangle(0, MagicNumbers.RESET_HEIGHT, rectangle.Width, rectangle.Height);

        }
    }
}
