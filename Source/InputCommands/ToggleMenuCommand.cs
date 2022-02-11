using UnityEngine;

namespace ControllerCommands
{
    // Command object for the player to toggle the menu.
    public class ToggleMenuCommand : Command
    {
        [SerializeField]
        private Menu _menu;

        public override void Execute()
        {
            _menu.Toggle();
        }
    }
}

