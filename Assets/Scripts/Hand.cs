using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    public float speed;
    private float triggerTarget;
    [HideInInspector] public float triggerCurrent;

    public RotateActions rotateActions;

    private Animator _animator;
     public Collider _collision;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IdleGrab();
    }

    public void KatanaWeaponGrab()
    {
        _animator.SetBool("GrabKatana", true);
    }
    public void KatanaWeaponRelease()
    {
        _animator.SetBool("GrabKatana", false);
    }

    public void IdleGrab()
    {
        if (triggerCurrent != triggerTarget && _collision == null)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            _animator.SetFloat("GrabNothing", triggerCurrent);            
        }

        if (_collision != null)
        {
            triggerCurrent = 0f;
            _animator.SetFloat("GrabNothing", triggerCurrent);
        }
    }

    public void SetTrigger(float x)
    {
        triggerTarget = x;
    }
}
