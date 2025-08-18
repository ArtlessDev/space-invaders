using Gum.Forms.Controls;
using JairLib.Toolbox;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JairLib.CustomObjects
{
    public partial class UpgradeObject : ShootableObject
    {
        public UpgradeObject(Player _player)
        {
            int rand = Random.Shared.Next(0, 7);

            UpgradeDelegate = GetUpgradeMethod(_player, rand);
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/heavyShot");
            rectangle = new Rectangle(0, MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, 64, 64);
            color = Color.White;
            upgradeId = (Upgrades)rand;
            upgradeState = UpgradeStates.Moving;
            speed = 1;
            GetGoingFlag = true;
        }

        public GameUpgradeDelegate UpgradeDelegate { get; set; }
        public Upgrades upgradeId { get; set; }
        public UpgradeStates upgradeState { get; set; }
        public bool GetGoingFlag { get; set; }

        public GameUpgradeDelegate GetUpgradeMethod(Player _player, int rand)
        {

            switch ((Upgrades)rand)
            {
                case (Upgrades.TripleShot)://1
                    return TripleShot;
                case (Upgrades.DamageBoost)://2
                    return DamageBoost;
                case (Upgrades.HealthBoost)://3
                    return HealthBoost;
                case (Upgrades.SpeedBoost)://4
                    return SpeedBoost;
                case (Upgrades.Teleporter)://5
                    return Teleporter;
                case (Upgrades.HeavyBlast)://6
                    return HeavyBlast;
                case (Upgrades.BulletSpeed)://7
                    return BulletSpeed;
                default: //ExtraShot    0
                    return ExtraShot;
            }
        }

        public void DoUpdate(GameTime gameTime, Player _player)
        {

            if (upgradeState != UpgradeStates.Moving)
                return;
            
            rectangle = new Rectangle(rectangle.X, rectangle.Y + speed, rectangle.Width, rectangle.Height);

            foreach (var bulllet in _player.ammo)
            {
                if (bulllet.rectangle.Intersects(this.rectangle))
                {
                    UpgradeDelegate(_player);
                    Debug.WriteLine(upgradeId + " triggered");
                    upgradeState = UpgradeStates.Reset;
                    GetGoingFlag = true;

                }
            }
        }
        public void Destroy(GameTime gameTime, Player _player)
        {
            if (upgradeState != UpgradeStates.Reset)
                return;

            rectangle = new Rectangle(MagicNumbers.RESET_HEIGHT, MagicNumbers.RESET_HEIGHT, 32, 32);
            upgradeState = UpgradeStates.Reset;

        }

        public void GetGoing(Player _player)
        {
            upgradeState = UpgradeStates.Moving;
            GetGoingFlag = false;

            int rand = Random.Shared.Next(MagicNumbers.SCREEN_BORDER_LIMIT_LEFT, MagicNumbers.SCREEN_BORDER_LIMIT_RIGHT);
            rectangle = new Rectangle(rand, 0, rectangle.Width, rectangle.Height);

        }

    }
}
