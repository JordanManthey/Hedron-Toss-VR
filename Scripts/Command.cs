using UnityEngine;

namespace ControllerCommands
{
    // A command class to decouple actions from controller input.
    public abstract class Command : MonoBehaviour
    {
        public abstract void Execute();
    }
}

