using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib
{
    public static class MagicNumbers
    {
        public const int SHIP_BASE_SPEED = 1;
        public const int BULLET_BASE_SPEED = 3;
    }
    public enum BulletStates
    {
        None,
        Firing,
        Ready,
        Hit,
    }
}
