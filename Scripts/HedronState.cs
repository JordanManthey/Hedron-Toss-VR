using UnityEngine;

namespace HedronStateMachine
{
    // HedronState subclasses define the game logic in the form of a Finite State Machine for the Hedron.
    public abstract class HedronState
    {
        // States that make up the FSM. There is always only one hedron in play and one concurrent state.
        protected static ThrownState Thrown;
        protected static ValidBounceState ValidBounce;
        protected static DeadState Dead;
        // Whether the hedron can be teleported in this state.
        protected bool AllowTeleport;

        public HedronState()
        {
            AllowTeleport = false;
        }

        public bool GetAllowTeleport()
        {
            return AllowTeleport;
        }

        // For defining transitions between states and to delegate how the hedron object collisions are handled.
        public abstract void HandleCollision(Hedron hedron, Collision collision);
    }
}

