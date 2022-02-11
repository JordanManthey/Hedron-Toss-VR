using UnityEngine;

namespace HedronStateMachine
{
    public class ValidBounceState : HedronState
    {
        public delegate void ScoreAction(int amount);
        public static event ScoreAction OnScore;
        public delegate void CatchAction();
        public static event CatchAction OnCatch;

        public ValidBounceState() : base() { }

        public override void HandleCollision(Hedron hedron, Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ricochet_Wall":
                    hedron.Bounce(collision.gameObject);
                    break;
                case "Catching_Hand":
                    hedron.State = Dead;
                    OnCatch();
                    break;
                case "Floor":
                    hedron.State = Dead;
                    OnScore(1);
                    break;
                default:
                    hedron.State = Dead;
                    break;
            }
        }
    }
}

