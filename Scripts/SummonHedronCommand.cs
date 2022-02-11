using UnityEngine;

namespace ControllerCommands
{

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

