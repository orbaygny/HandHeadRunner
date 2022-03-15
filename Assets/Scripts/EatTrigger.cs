using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EatTrigger : MonoBehaviour
{
    public int eatCount = 0;
    public GameObject canvas;
    [SerializeField]
    private Transform placeHolder;

    private GameObject parentForDelete;
   

     private void OnTriggerEnter(Collider other)
    {

       if(placeHolder.childCount == 0)
       {
            switch(other.tag)
        {
            case "Pear":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Burger":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.03f,0.43f,-0.22f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            other.transform.localRotation = Quaternion.Euler(90,0,0);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Cupcake":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Foodpod":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.02f,-0.1f,0.04f);
            other.transform.localScale = new Vector3(1,1,1);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Cake":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.02f,0,0.04f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

             case "Chicken":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

             case "Mailbox":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-1.59f,0.67f,0.72f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            other.transform.localRotation = Quaternion.Euler(180,202,90);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Table":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.47f,-0.15f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;

            case "Bookshelf":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            parentForDelete.SetActive(false);
            break;
            
        }

        hhController.Instance.walk = false;
        hhController.Instance.anim.SetTrigger("Eat");
       // if(eatCount>=10){hhController.Instance.ScaleUp(); eatCount -=10;
       //               EdibleManager.Instance.ChangeEdible(); }
       }
        /*if(other.gameObject.tag == "Burger" && placeHolder.childCount ==0){

            other.transform.parent = placeHolder; 
            if(TestVertical._vActive)
            {
                
                other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
               // other.transform.localRotation = Quaternion.Euler(75,0,60);
            }
            else
            {
                other.transform.localPosition = new Vector3(0.035f,0.09f,0.075f);
            }
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            
            
            
           hhController.Instance.walk = false;
           hhController.Instance.anim.SetTrigger("Eat");
           eatCount+=2;
           if(eatCount>=10){hhController.Instance.ScaleUp(); eatCount -=10;}
           
        }*/

        if(other.gameObject.tag == "Finish")
        {
            canvas.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
}



