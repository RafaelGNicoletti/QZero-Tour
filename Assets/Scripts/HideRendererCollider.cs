using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRendererCollider : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
