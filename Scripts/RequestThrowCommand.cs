using UnityEngine;

namespace ControllerCommands
{
    public class RequestThrowCommand : Command
    {
        [SerializeField]
        private BotHandler _botHandler;

        public override void Execute()
        {
            _botHandler.RequestThrow();
        }
    }
}
