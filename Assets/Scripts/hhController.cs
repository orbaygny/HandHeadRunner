using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class hhController : MonoBehaviour
{
    

     public static hhController Instance { get; private set; }

     private Vector2 startPos, endPos;
     public float speed;
     public bool walk = true;
     public Animator anim;
     public Vector3 lastPos;

     public Transform root,rotationPoint,rotationP_reset;

     public bool moveToLeft,moveToRight;
    public static bool rotateActive,resetCheck,verticalActive;
     float touchXDelta = 0;
     float offset = 0;
    public float rotationAngle =0;
      public  float rotationAngle_reset = 0;
     float clampOffset;

   

    public Transform floor;


     public GameObject edible;

     Vector3 camPos;
    

     //public Vector2 startPos;

     public Transform parent;

    //bool resetPos = false;
     void Awake() { Instance = this; }
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        DOTween.Init();
        anim = GetComponent<Animator>();
        if(verticalActive)
        {
            rotationPoint.rotation = Quaternion.Euler(-90,0,0);
            transform.position = new Vector3(transform.position.x,transform.position.y,3.0f);
            Camera.main.GetComponent<CamScript>().offset.y=1;
            anim.SetBool("verticalActive",true);


        }

        camPos = Camera.main.transform.localPosition;
        camPos.x *=0.5f;
        camPos.y *= 2;
        camPos.z *= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
       
        
    
    
    }

   public void ScaleUp()
    {
        float scaleTo = transform.lossyScale.x+1f;
       /* transform.localScale = new Vector3(transform.localScale.x-0.2f,transform.localScale.y-0.2f,transform.localScale.z-0.2f);
        transform.localScale = new Vector3(transform.localScale.x+0.4f,transform.localScale.y+0.4f,transform.localScale.z+0.4f);
        transform.localScale = new Vector3(transform.localScale.x-0.1f,transform.localScale.y-0.1f,transform.localScale.z-0.1f);*/
        transform.DOScale(scaleTo,1.2f).SetEase(Ease.OutBounce);
        Camera.main.transform.DOLocalMove( Camera.main.transform.localPosition+camPos,1.5f); 
        foreach(Transform child in floor)
        {
            child.DOScale(new Vector3(
               child.localScale.x+(child.localScale.x*0.5f),
                child.localScale.y,
                child.localScale.z
            ),0.75f).SetEase(Ease.Linear);
        }
       
        gameObject.GetComponent<SwerveSystem>().swerveMinus +=gameObject.GetComponent<SwerveSystem>().swerveMinus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swervePlus += gameObject.GetComponent<SwerveSystem>().swervePlus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swerveSpeed += 0.5f;

    }

    void LateUpdate()
    {
        //parent.position += parent.forward*3*Time.fixedDeltaTime;

        ResetPos();

        
    }

  
    void ResetPos()
    {   
        if(resetCheck )
        {
            if( //rotationAngle <1f && rotationAngle>-1f
            rotationAngle == rotationAngle_reset){rotationAngle =0; rotationAngle_reset =0; 
            rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,0,0) ;
            rotationP_reset.localRotation =Quaternion.Euler(rotationP_reset.eulerAngles.x,0,0); 
            resetCheck = false;}
        
         else if(rotationAngle>0f)
         {
             if(rotationAngle_reset>-rotationAngle)
             {
                //rotationAngle -=100*Time.deltaTime;
            //rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
            rotationAngle_reset -=100*Time.deltaTime;
            rotationP_reset.localRotation =Quaternion.Euler(rotationP_reset.eulerAngles.x,rotationAngle_reset,0) ;
             }
             

           
         }
        else if(rotationAngle<0f)
         {
             //rotationAngle += 100*Time.deltaTime;
            // rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;

             if(rotationAngle_reset<-rotationAngle)
             {
                //rotationAngle -=100*Time.deltaTime;
            //rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
            rotationAngle_reset +=100*Time.deltaTime;
            rotationP_reset.localRotation =Quaternion.Euler(rotationP_reset.eulerAngles.x,rotationAngle_reset,0) ;
             }

         }
        }

        
    }
   
   public void Movement()
{   
       parent.position += parent.forward*9*Time.deltaTime;
    
       
   if (Input.touchCount > 0)
{       
     Touch touch = Input.GetTouch(0);

    if(touch.phase == TouchPhase.Began)
    {
        startPos = touch.position;
    }
    
    if(touch.phase== TouchPhase.Ended)
    {
        endPos = touch.position;
        
    }
    
    
     
            // Move the cube if the screen has the finger moving.
    if (touch.phase == TouchPhase.Moved )
     {
         
         

         if(startPos.x>touch.position.x && parent.position.x > -4f)
         {
             //parent.position -= new Vector3(20,0,0)*Time.deltaTime;

             if(rotateActive && rotationAngle> -20)
             {  
                 rotationAngle -=200*Time.deltaTime;
                 rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
             }
         
             startPos = touch.position;
             lastPos = parent.position;

         }

         if(startPos.x<touch.position.x && parent.position.x<4f)
         {  
             //parent.position += new Vector3(20,0,0)*Time.deltaTime;

             if(rotateActive && rotationAngle<20)
             {  
                 rotationAngle +=200*Time.deltaTime;
                 rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
             }
            
             startPos = touch.position;
             lastPos = parent.position;

         }

        
        

     }

     else
     {
         resetCheck = true;
     }

}
        
     
}

public void withRotation(){rotateActive = true; TestVertical._vActive = false; SceneManager.LoadScene(0);}
public void Vertical(){rotateActive = false; //verticalActive = true; 
//parent.GetChild(2).gameObject.SetActive(true);
gameObject.SetActive(false);
SceneManager.LoadScene(0);}  

public void wOutRotation(){rotateActive = false; TestVertical._vActive = false; SceneManager.LoadScene(0);}




    
}
