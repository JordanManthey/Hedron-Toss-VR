using UnityEngine;

namespace ControllerCommands
{
    // Command object to request teleporting the hedron to this hand (XR controller).
    public class SummonHedronCommand : Command
    {
        [SerializeField]
        private Hedron _hedron;

        public override void Execute()
        {
            _hedron.Teleport(transform.position);
        }
    }
}

