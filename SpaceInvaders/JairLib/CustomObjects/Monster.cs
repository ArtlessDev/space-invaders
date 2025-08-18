using JairLib.Toolbox;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.CustomObjects
{
    public class Monster : ShootableObject
    {
        public Monster()
        {
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/monster");
            color = Color.Azure;

            MaxHealth = 3;
            Health = 3;
            Damage = 5;
            state = MonsterState.Alive;
            PointWorth = 300;
            speed = 1;

            int rand = Random.Shared.Next(MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, MagicNumbers.SCREEN_BORDER_LIMIT_RIGHT);
            rectangle = new Rectangle(rand, 0, 32, 32);
        }

        public int PointWorth { get; set; }
        public int Damage { get; set; }
        public MonsterState state { get; set; }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y + speed, rectangle.Width, rectangle.Height);
        }

        public void ResetMonster()
        {
            //state = BulletStates.Ready;
            int rand = Random.Shared.Next(MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, MagicNumbers.SCREEN_BORDER_LIMIT_RIGHT);
            rectangle = new Rectangle(rand, 0, rectangle.Width, rectangle.Height);

        }
    }
}
