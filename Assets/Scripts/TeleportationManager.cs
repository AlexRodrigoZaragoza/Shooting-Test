using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [Header ("Left Hand Teleportation Controller")]
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleportationProvider;

    [SerializeField] private InteractionLayerMask TeleportationLayer;

    [SerializeField] private InputActionProperty teleportModeActivate;
    [SerializeField] private InputActionProperty teleportModeCancel;
    [SerializeField] private InputActionProperty thumbMove;
    [SerializeField] private InputActionProperty gripModeActivate;

    private bool teleportActive;
    private InteractionLayerMask initialInteractionLayers;
    public List<IXRInteractable> interactables = new List<IXRInteractable>();

    // Start is called before the first frame update
    void Start()
    {
        teleportModeActivate.action.Enable();
        teleportModeCancel.action.Enable();
        thumbMove.action.Enable();
        gripModeActivate.action.Enable();

        teleportModeActivate.action.performed += OnTeleportActivate;
        teleportModeCancel.action.performed -= OnTeleportCancel;

        initialInteractionLayers = rayInteractor.interactionLayers;
    }

    // Update is called once per frame
    void Update()
    {
        if (!teleportActive)
            return;
        if (thumbMove.action.triggered)
            return;
        rayInteractor.GetValidTargets(interactables);
        if (interactables.Count == 0)
        {
            TurnOffTeleportation();
            return;
        }
        rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit);
        TeleportRequest request = new TeleportRequest();
        if (interactables[0].interactionLayers == 2)
        {
            request.destinationPosition = hit.point;
        }
        else if(interactables[0].interactionLayers == 4)
        {
            request.destinationPosition = hit.transform.GetChild(0).transform.position;
        }
        teleportationProvider.QueueTeleportRequest(request);
        TurnOffTeleportation();
    }
    private void OnTeleportActivate(InputAction.CallbackContext obj)
    {
        if (gripModeActivate.action.phase != InputActionPhase.Performed)
        {
            teleportActive = true;
            rayInteractor.lineType = XRRayInteractor.LineType.ProjectileCurve;
            rayInteractor.interactionLayers = TeleportationLayer;
        }
    }
    private void OnTeleportCancel(InputAction.CallbackContext obj)
    {
        TurnOffTeleportation();
    }
    private void TurnOffTeleportation()
    {
        teleportActive = false;
        rayInteractor.lineType = XRRayInteractor.LineType.StraightLine;
        rayInteractor.interactionLayers = initialInteractionLayers;
    }
}
