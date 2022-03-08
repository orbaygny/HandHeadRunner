using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTrigger : MonoBehaviour
{
   

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Burger"){
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(-0.00125f,0.0009f,0.0027f);
            other.transform.localScale = new Vector3(0.005f,0.005f,0.005f);
            hhController.Instance.edible = other.gameObject;
            
            
            
           hhController.Instance.walk = false;
           hhController.Instance.anim.SetTrigger("Eat");
        }
    }
}
