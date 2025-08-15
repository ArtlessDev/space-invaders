
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JairLib
{
    public class Bullet : IJairObject
    {
        public Bullet(Rectangle _rect)
        {
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/bullet");
            color = Color.White;
            rectangle = _rect;
            state = BulletStates.None;
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
                rectangle = new Rectangle(rectangle.X, rectangle.Y - MagicNumbers.BULLET_BASE_SPEED, rectangle.Width, rectangle.Height);

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
