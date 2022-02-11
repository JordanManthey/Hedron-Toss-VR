using ControllerCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerInputHandler : MonoBehaviour
{
    [SerializeField]
    private InputDeviceCharacteristics _controllerCharacteristics;
    private InputDevice _controllerDevice;

    // Assign controller binds in the Unity inspector.
    [SerializeField] private Command _primaryButton;
    [SerializeField] private Command _secondaryButton;
    [SerializeField] private Command _menuButton;

    private void GetControllerDevice()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(_controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            _controllerDevice = devices[0];
        }
    }

    private void HandleInput()
    {
        if (_controllerDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryActivated) && primaryActivated)
        {
            _primaryButton.Execute();
        }
        else if (_controllerDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryActivated) && secondaryActivated)
        {
            _secondaryButton.Execute();
        }
        else if (_controllerDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuActivated) && menuActivated)
        {
            _menuButton.Execute();
        }
    }

    void Start()
    {
        GetControllerDevice();
    }

    void Update()
    {
        HandleInput();
    }
}

