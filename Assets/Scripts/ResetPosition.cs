using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPosition : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;

    public Vector3 originalPosition = Vector3.zero;
    public Quaternion originalRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(SavePosition);
        grabInteractable.onSelectExited.AddListener(ReturnToSlot);
    }

    public void SavePosition(XRBaseInteractor interactor)
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Debug.Log("function called: save position");

    }

    // Update is called once per frame
    public void ReturnToSlot(XRBaseInteractor interactor)
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        Debug.Log("function called: return to slot");

    }

}
