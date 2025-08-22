using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.Toolbox
{
    public enum Upgrades
    {
        ExtraShot,
        TripleShot,
        DamageBoost,
        HealthBoost,
        SpeedBoost,
        Teleporter,
        HeavyShot,
        BulletSpeed,
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
    public enum GameState
    {
        None,
        Playing,
        RoundOver,
        UpgradeTime,
    }
    public enum BulletType
    {
        Single,
        Triple,
        Heavy,
    }
    public enum UpgradeStates
    {
        None,
        Reset,
        Moving,
        Waiting,
    }
}
