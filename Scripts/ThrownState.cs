using UnityEngine;

namespace HedronStateMachine
{
    // State in which the hedron is thrown by the throwing player.
    public class ThrownState : HedronState
    {
        // broadcasts events for the GameManager.
        public delegate void ScoreAction(int amount);
        public static event ScoreAction OnScore;
        public delegate void DeadAction();
        public static event DeadAction OnDead;

        public ThrownState() : base() { }

        public override void HandleCollision(Hedron hedron, Collision collision)
        {

            switch (collision.gameObject.tag)
            {
                case "Bounce_Table":
                    hedron.State = ValidBounce;
                    hedron.Bounce(collision.gameObject);
                    break;
                case "Ricochet_Wall":
                    hedron.State = Dead;
                    hedron.Bounce(collision.gameObject);
                    break;
                case "Sink_Tube":
                    hedron.State = Dead;
                    OnScore(3);
                    break;
                default:
                    hedron.State = Dead;
                    OnDead();
                    break;
            }
        }
    }
}

