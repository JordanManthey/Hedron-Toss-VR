using UnityEngine;

namespace ControllerCommands
{
    // Command object for requesting the AI (bot) to throw to the player.
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
