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
        public const int SCREEN_WIDTH = 500;
        public const int SCREEN_BORDER_LIMIT_LEFT = 64;
        public const int SCREEN_BORDER_LIMIT_RIGHT = 372;
        public const int SCREEN_HEIGHT = 400;
        public const int RESET_HEIGHT = -100;


        public static Monster[] LEVEL_ONE = new Monster[]
        {
            new Monster(),
            new Monster(),
            new Monster(),
        };
    }
    public enum BulletStates
    {
        None,
        Firing,
        Ready,
        Hit,
    }

    public enum MonsterState
    {
        None,
        Alive,
        Attacking,
        Moving,
        Dead
    }
}
