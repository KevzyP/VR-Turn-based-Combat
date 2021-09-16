using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenuController : MonoBehaviour
{
    public RotateActions rotateActions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableRotatingActions()
    {
        rotateActions.gameObject.SetActive(true);
    }

    public void DisableRotatingActions()
    {
        rotateActions.gameObject.SetActive(false);
    }

}
