using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController controller;

    public Hand hands;

    private void Awake()
    {
        controller = GetComponent<ActionBasedController>();
    }

    private void Update()
    {
        XRDirectInteractor directInteractor = GetComponent<XRDirectInteractor>();
        
        hands.SetTrigger(controller.activateAction.action.ReadValue<float>());

        if (hands.triggerCurrent > 0.2)
        {
            directInteractor.interactionLayerMask = LayerMask.GetMask("Nothing");
        }
        else
            directInteractor.interactionLayerMask = LayerMask.GetMask("Default");
    }

    private void OnTriggerEnter(Collider other)
    {
        hands._collision = other;
        hands.rotateActions.isGrabbing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hands._collision = null;
        hands.rotateActions.isGrabbing = false;
    }

}
