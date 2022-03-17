using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTrigger : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer ==  LayerMask.NameToLayer ("Edible"))
        {
            other.gameObject.AddComponent<HeightFogPerObject>();
        }
    }
}
