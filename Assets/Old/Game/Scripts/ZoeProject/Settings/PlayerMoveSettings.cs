
using System;

namespace ZoeProject
{
    [Serializable]
    public class PlayerMoveSettings
    {
        public float KeepAddVelocity;
        public MoveSettings Rush;

        public MoveSettings Run;

        public MoveSettings Walk;

        public AnimSettings Idle;
    }
    
    [Serializable]
    public class MoveSettings
    {
        public float Speed;
        public AnimSettings Anim;
    }
}

