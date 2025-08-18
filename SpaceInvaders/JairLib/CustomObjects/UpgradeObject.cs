using Gum.Forms.Controls;
using JairLib.Toolbox;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.CustomObjects
{
    public partial class UpgradeObject : ShootableObject
    {
        public UpgradeObject(Player _player)
        {
            int rand = Random.Shared.Next(0, 6);

            UpgradeDelegate = GetUpgradeMethod(_player, rand);
            texture = Util.GlobalContent.Load<Texture2D>("Sprites/heavyShot");
            rectangle = new Rectangle(64,64,32,32);
            color = Color.White;
            upgradeId = (Upgrades)rand;
        }

        public GameUpgradeDelegate UpgradeDelegate { get; set; }
        public Upgrades upgradeId { get; set; } 

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
    }
}
