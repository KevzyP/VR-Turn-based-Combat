using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KatanaWeaponGrab()
    {
        _animator.SetBool("GrabKatana", true);
    }
    public void KatanaWeaponRelease()
    {
        _animator.SetBool("GrabKatana", false);
    }

    
}
