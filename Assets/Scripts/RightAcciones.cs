using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;

public class RightAcciones : MonoBehaviour
{
    public InputActionReference _ActivateHold;
    public InputActionReference _MultiTap;
    public Text _Text;

    private void Start()
    {
        _ActivateHold.action.performed += ActivateHold;
        _MultiTap.action.performed += MultiTap;
    }

    private void ActivateHold(InputAction.CallbackContext obj)
    {
        Debug.Log("Hold");
        _Text.text = "Hold Right Trigger";
    }
    private void MultiTap(InputAction.CallbackContext obj)
    {
        Debug.Log("MultiTap");
        _Text.text = "MultiTap Right A";
    }
}
