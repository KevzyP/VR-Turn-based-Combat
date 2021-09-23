using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenuController : MonoBehaviour
{
    public RotateActions rotateActions;

    public WeaponList actions;

    private float _defaultSpeed;
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        _defaultSpeed = rotateActions.defaultSpeed;
    }

    public void EnableRotatingActions()
    {
        actions.EnableMeshRenderer();
        rotateActions.defaultSpeed = _defaultSpeed;
        //StartCoroutine(DelayRotation());
    }

    public void DisableRotatingActions()
    {
        rotateActions.defaultSpeed = 0;
        actions.DisableMeshRenderer();
    }

    public void StartRotating()
    {
        rotateActions.defaultSpeed = _defaultSpeed;

    }

    public void StopRotating()
    {
        rotateActions.defaultSpeed = 0;

    }

    public IEnumerator DelayRotation()
    {


        actions.EnableMeshRenderer();
        
        yield return new WaitForSeconds(waitTime);

        rotateActions.defaultSpeed = _defaultSpeed;
    }

}
