using UnityEngine;

namespace HedronStateMachine
{
    public abstract class HedronState
    {
        protected static ThrownState Thrown;
        protected static ValidBounceState ValidBounce;
        protected static DeadState Dead;
        protected bool AllowTeleport;

        public HedronState()
        {
            AllowTeleport = false;
        }

        public bool GetAllowTeleport()
        {
            return AllowTeleport;
        }

        public abstract void HandleCollision(Hedron hedron, Collision collision);

    }
}

