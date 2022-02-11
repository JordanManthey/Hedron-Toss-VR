using UnityEngine;

namespace HedronStateMachine
{
    // State in which hedron is out-of-play or the turn if over.
    public class DeadState : HedronState
    {
        public DeadState()
        {
            AllowTeleport = true;
        }

        public override void HandleCollision(Hedron hedron, Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Throwing_Hand":
                    hedron.State = Thrown;
                    break;
            }
        }
    }
}

