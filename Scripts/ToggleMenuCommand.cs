using UnityEngine;

namespace ControllerCommands
{
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

