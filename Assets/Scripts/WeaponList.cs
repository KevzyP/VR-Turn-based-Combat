using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{

    public Canvas circleMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DisableMeshRenderer()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
                meshRenderer.enabled = false;

        }

        if (circleMenu.gameObject.activeInHierarchy == true)
            circleMenu.gameObject.SetActive(false);
    }

    public void EnableMeshRenderer()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
                meshRenderer.enabled = true;

        }
        if (circleMenu.gameObject.activeInHierarchy == false)
            circleMenu.gameObject.SetActive(true);
    }
}
