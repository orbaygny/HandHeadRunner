using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EatTrigger : MonoBehaviour
{
    public GameObject canvas;
   

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Burger"){
            other.transform.parent = transform;
            if(TestVertical._vActive)
            {
                other.transform.localPosition = new Vector3(0.003f,-0.00026f,0.00066f);
                other.transform.localRotation = Quaternion.Euler(75,0,60);
            }
            else
            {
                other.transform.localPosition = new Vector3(-0.00125f,0.0009f,0.0027f);
            }
            other.transform.localScale = new Vector3(0.005f,0.005f,0.005f);
            hhController.Instance.edible = other.gameObject;
            
            
            
           hhController.Instance.walk = false;
           hhController.Instance.anim.SetTrigger("Eat");
        }

        if(other.gameObject.tag == "Finish")
        {
            canvas.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
}



