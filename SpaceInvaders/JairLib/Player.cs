using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace JairLib
{
    public class Player : IJairObject
    {
        public Player()
        {
            color = Color.White;
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/playerShip");
            rectangle = new Rectangle(100, 400, 32, 32);
            ammo = [new Bullet(new()), new Bullet(new()), new Bullet(new())];
            PlayerHealth = MagicNumbers.PLAYER_BASE_HEALTH;
            PlayerSpeed = MagicNumbers.SHIP_BASE_SPEED;
        }

        public string identifier { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2D texture { get; set; }
        public Color color { get; set; }
        public Bullet[] ammo { get; set; }
        public int PlayerScore { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerSpeed { get; set; }

        public void Update(GameTime gameTime)
        {
            Movement();
            Shoot();

            foreach (var item in ammo)
            {
                item.Travel();
            }
        }

        public void Movement()
        {
            if (Util.keyboardState.IsKeyDown(Keys.A))
            {
                rectangle = new Rectangle(rectangle.X - PlayerSpeed, rectangle.Y, rectangle.Width, rectangle.Height);
            }
            else if (Util.keyboardState.IsKeyDown(Keys.D))
            {
                rectangle = new Rectangle(rectangle.X + PlayerSpeed, rectangle.Y, rectangle.Width, rectangle.Height);
            }
        }

        public void Shoot()
        {
            if (Util.keyboardState.WasKeyPressed(Keys.Space))
            {
                foreach (var item in ammo)
                {
                    if (item.state != BulletStates.Firing)
                    {
                        item.rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                        item.state = BulletStates.Firing;
                        break;
                    }
                }
            }
        }

        public void ScoreIncrease(Monster monster)
        {
            PlayerScore += 100 * monster.MaxHealth;
        }

        public void Yeowch()    //!
        {
            PlayerHealth--;

            if (PlayerHealth <= 0)
                Util.gameState = GameState.RoundOver;

        }
    }
}
