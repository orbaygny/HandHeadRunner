using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTrigger : MonoBehaviour
{
   

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Burger"){
            other.transform.parent = transform.parent;
            
           hhController.Instance.walk = false;
           hhController.Instance.anim.SetTrigger("Eat");
        }
    }
}
