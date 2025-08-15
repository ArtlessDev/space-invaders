using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib
{
    public class GameUpgrades
    {
        public void ExtraShot(Player _player)
        {
            int newLength = _player.ammo.Length + 1;
            Bullet[] tempAmmo = new Bullet[newLength];

            for (int i = 0; i < _player.ammo.Length; i++)
            {
                tempAmmo[i] = _player.ammo[i];
            }

            var tempBullet = new Bullet(new (MagicNumbers.RESET_HEIGHT, MagicNumbers.RESET_HEIGHT, MagicNumbers.BULLET_BASE_SIZE, MagicNumbers.BULLET_BASE_SIZE));
            tempBullet.type = BulletType.Single;
            tempBullet.bulletSpeed = MagicNumbers.BULLET_BASE_SPEED;

            tempAmmo[tempAmmo.Length - 1] = tempBullet;
            //should add some sort of visual indicator to show that the player has more ammo
            //
        }
        public void TripleShot(Player _player)
        {
            int newLength = _player.ammo.Length + 1;
            Bullet[] tempAmmo = new Bullet[newLength];

            for (int i = 0; i < _player.ammo.Length; i++)
            {
                tempAmmo[i] = _player.ammo[i];
            }

            var tempBullet = new Bullet(new(MagicNumbers.RESET_HEIGHT, MagicNumbers.RESET_HEIGHT, MagicNumbers.BULLET_BASE_SIZE, MagicNumbers.BULLET_BASE_SIZE));
            
            tempBullet.texture = Util.GlobalContent.Load<Texture2D>("Sprites/tripleShot");
            tempBullet.type = BulletType.Triple;
            tempBullet.bulletSpeed = MagicNumbers.BULLET_BASE_SPEED + 1;

            tempAmmo[tempAmmo.Length - 1] = tempBullet;

        }

        public void DamageBoost(Player _player)
        {
            foreach (var item in _player.ammo)
            {
                item.damageLevel++;
            }
        }

        public void HealthBoost(Player _player)
        {
            _player.PlayerHealth += 2;
        }

        public void SpeedBoost(Player _player)
        {
            _player.PlayerSpeed++;
        }

        public void Teleporter(Player _player)
        {

        }

        public void HeavyBlast(Player _player)
        {
            int newLength = _player.ammo.Length + 1;
            Bullet[] tempAmmo = new Bullet[newLength];

            for (int i = 0; i < _player.ammo.Length; i++)
            {
                tempAmmo[i] = _player.ammo[i];
            }

            var tempBullet = new Bullet(new(MagicNumbers.RESET_HEIGHT, MagicNumbers.RESET_HEIGHT, MagicNumbers.BULLET_BASE_SIZE, MagicNumbers.BULLET_BASE_SIZE));

            tempBullet.texture = Util.GlobalContent.Load<Texture2D>("Sprites/heavyShot");
            tempBullet.type = BulletType.Triple;
            tempBullet.bulletSpeed = MagicNumbers.BULLET_BASE_SPEED - 2;

            tempAmmo[tempAmmo.Length - 1] = tempBullet;
        }

        public void BulletSpeed(Player _player)
        {
            foreach (var item in _player.ammo)
            {
                item.bulletSpeed++;
            }
        }
    }

    public enum Upgrades
    {
        TripleShot,
        DamageBoost,
        HealthBoost,
        SpeedBoost,
        Teleporter,
        HeavyBlast,
        BulletSpeed,
    }
}
