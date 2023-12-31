﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace LevelUp.GrabInteractions
{
    public class TestScript : MonoBehaviour
    {
        XRGrabInteractable m_GrabInteractable;

        [Tooltip("The Transform that the object will return to")]
        [SerializeField] Vector3 returnToPosition;
        [SerializeField] float resetDelayTime;
        protected bool shouldReturnHome { get; set; }
        bool isController;

        // Start is called before the first frame update
        void Awake()
        {
            m_GrabInteractable = GetComponent<XRGrabInteractable>();
            //returnToPosition = this.transform.position;
            shouldReturnHome = true;
        }

        private void OnEnable()
        {
            m_GrabInteractable.onSelectExited.AddListener(OnSelectExit);
            m_GrabInteractable.onSelectEntered.AddListener(OnSelect);
        }

        private void OnDisable()
        {
            m_GrabInteractable.onSelectExited.RemoveListener(OnSelectExit);
            m_GrabInteractable.onSelectEntered.RemoveListener(OnSelect);
        }

        private void OnSelect(XRBaseInteractor interactor)
        {
            returnToPosition = this.transform.position;
            CancelInvoke("ReturnHome");

        }
        private void OnSelectExit(XRBaseInteractor interactor) => Invoke(nameof(ReturnHome), resetDelayTime);

        protected virtual void ReturnHome()
        {
            if (shouldReturnHome)
                transform.position = returnToPosition;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (ControllerCheck(other.gameObject))
                return;

            var socketInteractor = other.gameObject.GetComponent<XRSocketInteractor>();

            if (socketInteractor == null)
                shouldReturnHome = true;

            else if (socketInteractor.CanSelect(m_GrabInteractable))
            {
                shouldReturnHome = false;
            }
            else
                shouldReturnHome = true; //The socket interactor exists and CANNOT select the Grab object
        }

        private void OnTriggerExit(Collider other)
        {
            if (ControllerCheck(other.gameObject))
                return;

            shouldReturnHome = true;
        }

        

        bool ControllerCheck(GameObject collidedObject)
        {
            //first check that this is not the collider of a controller
            isController = collidedObject.gameObject.GetComponent<XRBaseController>() != null ? true : false;
            return isController;
        }
    }
}
