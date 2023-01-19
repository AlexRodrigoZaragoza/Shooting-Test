using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;

public class LeftAcciones : MonoBehaviour
{
    #region Disparo
    public GameObject pelota;
    public Transform spawn;
    public float fuerzaDisparo;
    public float ratioDisparo = 0.5f;
    private float tiempoDisparo = 0;
    public float vida;
    #endregion
    private ActionBasedController controller;
    public InputActionReference _MultiActivate;
    public InputActionReference _RightSector;
    public InputActionReference _YourChoose;
    public Text _Text;


    private void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.selectAction.action.performed += SelectAction;
        _MultiActivate.action.performed += MultiActivate;
        _RightSector.action.performed += RightSector;
        _YourChoose.action.performed += YourChoose;

    }

    private void SelectAction(InputAction.CallbackContext obj)
    {
        //Debug.Log("Select pressed in performed");
        //Debug.Log("Select result: " + obj.ReadValue<float>());
    }
    private void MultiActivate(InputAction.CallbackContext obj)
    {
        if (Time.time > tiempoDisparo)
        {
            GameObject pelotaNueva;

            pelotaNueva = Instantiate(pelota, spawn.position, spawn.rotation);

            pelotaNueva.GetComponent<Rigidbody>().AddForce(spawn.forward * fuerzaDisparo);

            tiempoDisparo = Time.time + ratioDisparo;

            Destroy(pelotaNueva, vida);

        }
        _Text.text = "Click Left Trigger";
    }
    private void RightSector(InputAction.CallbackContext obj)
    {
        Debug.Log("Derecha");
        _Text.text = "Joystick Left to Right";
    }
    private void YourChoose(InputAction.CallbackContext obj)
    {
        Debug.Log("Touched");
        _Text.text = "Touched Left X";
    }
}
