using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;




public class EatTrigger : MonoBehaviour
{
    public static int lastEated = 0;
    public GameObject canvas;
    [SerializeField]
    private Transform placeHolder;

    private GameObject parentForDelete;

    Vector3 scaler;
    
    void Awake()
    {
        lastEated = 0;
        scaler = new Vector3(0.1f,0.1f,0.1f);
    }

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
            lastEated = 1;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
            hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.25f).SetEase(Ease.OutQuart).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Burger":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.032f,0.05f,-0.096f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
           // other.transform.localRotation = Quaternion.Euler(90,0,0);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.12f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            break;

            case "Cupcake":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
           lastEated = 2;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Mouton":
            
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
           lastEated = 2;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            break;

            case "Foodpod":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.02f,-0.1f,0.04f);
            other.transform.localScale = new Vector3(1,1,1);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
        hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Cake":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.02f,0,0.04f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 1;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

             case "Chicken":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 2;
           parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

             case "Mailbox":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-1.59f,0.67f,0.72f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            other.transform.localRotation = Quaternion.Euler(180,202,90);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 1;
           parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Table":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.47f,-0.15f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 2;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Bookshelf":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            EdibleManager.Instance.locations.Remove(other.transform);
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

             case "AirBal":
             
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            break;

            case "House":
            
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

           
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            break;

            case "Plane":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
           parentForDelete.SetActive(false);

           
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            break;

            case "RottenApple":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale-scaler,0.12f).SetEase(Ease.InBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.Failure);

            break;

             case "Cactus":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.115f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == -10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale-scaler,0.12f).SetEase(Ease.InBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

             case "Volcano":
             
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.7f,-0.15f,0.04f);
            other.transform.localScale = new Vector3(0.15f,0.15f,0.15f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -=2;
            lastEated = 3;
           parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == -10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale-scaler,0.12f).SetEase(Ease.InBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

             case "Elect":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -=2;
            lastEated = 3;
           parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == -10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale-scaler,0.12f).SetEase(Ease.InBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

             case "Ufo":
             
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.268f,0.236f,0.101f);
            other.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -=2;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == -10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale-scaler,0.12f).SetEase(Ease.InBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

            case "Bomb1":
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -= 10;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
           
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

            case "Bomb2":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -= 10;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
           
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

            case "Bomb3":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -= 10;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
           
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

            case "Bomb4":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -= 10;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
           
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;

            case "Bomb5":
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount -= 10;
            lastEated = 3;
            parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount  == -10){hhController.Instance.anim.SetTrigger("Eat");}
           
           MMVibrationManager.Haptic(HapticTypes.Failure);
            break;
            
        }


        
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
            hhController.Instance.finishStart = true;
           hhController.Instance.FinishStart();
           hhController.Instance.anim.SetTrigger("Finish");

           

            
        }
    }

   /* void OnTriggerStay(Collider other)
    {
         if(placeHolder.childCount == 0)
       {
            switch(other.tag)
        {

            case "Burger":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.032f,0.05f,-0.096f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
           //other.transform.localRotation = Quaternion.Euler(90,0,0);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            //parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

              case "Mouton":
              
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(0.00476f,0.000456f,0);
            other.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
           lastEated = 2;
            //parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

             case "AirBal":
             
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            //parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "House":
            
            
             parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
            //parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
            hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;}
            break;

            case "Plane":
            
            parentForDelete = other.transform.parent.gameObject;
            other.transform.parent = placeHolder;
            other.transform.localPosition = new Vector3(-0.3f,-0.15f,0.12f);
            other.transform.localScale = new Vector3(1f,1f,1f);
            hhController.Instance.edible = other.gameObject;
            EdibleManager.Instance.locations.Remove(hhController.Instance.edible.transform);
            EdibleManager.Instance.eatCount +=2;
            lastEated = 3;
           // parentForDelete.SetActive(false);

            
            hhController.Instance.walk = false;
            if(EdibleManager.Instance.eatCount == 10){hhController.Instance.anim.SetTrigger("Eat");}
            else{GameObject.Destroy(hhController.Instance.edible);
             hhController.Instance.rotationPoint.DOScale(hhController.Instance.rotationPoint.lossyScale+scaler,0.5f).SetEase(Ease.OutBack).SetLoops(2,LoopType.Yoyo);
                                    hhController.Instance.EatTexter(EatTrigger.lastEated);
                                    CanvasScript.Instance.inc = true;}
            break;

        }
       }
    }*/
}



