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

     public Transform root,rotationPoint;

     public bool moveToLeft,moveToRight;
    public static bool rotateActive,resetCheck,verticalActive;
     float touchXDelta = 0;
     float offset = 0;
public float rotationAngle =0;
     float clampOffset;


     public GameObject edible;
    

     //public Vector2 startPos;

     public Transform parent;

    //bool resetPos = false;
     void Awake() { Instance = this;}
    
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        anim = GetComponent<Animator>();
        if(verticalActive)
        {
            rotationPoint.rotation = Quaternion.Euler(-90,0,0);
            transform.position = new Vector3(transform.position.x,transform.position.y,3.0f);
            Camera.main.GetComponent<CamScript>().offset.y=1;
            anim.SetBool("verticalActive",true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
       
        
    
    
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
            if( rotationAngle <1f && rotationAngle>-1f){rotationAngle =0; rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,0,0) ; resetCheck = false;}
         else if(rotationAngle>0f)
         {
             rotationAngle -=50*Time.deltaTime;
            rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
         }
        else if(rotationAngle<0f)
         {
             rotationAngle += 50*Time.deltaTime;
             rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;

         }
        }
    }
   
   public void Movement()
{   
       parent.position += parent.forward*6*Time.deltaTime;
    
       
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
             parent.position -= new Vector3(10,0,0)*Time.deltaTime;

             if(rotateActive && rotationAngle> -30)
             {  
                 rotationAngle -=100*Time.deltaTime;
                 rotationPoint.rotation =Quaternion.Euler(rotationPoint.eulerAngles.x,rotationAngle,0) ;
             }
         
             startPos = touch.position;
             lastPos = parent.position;

         }

         if(startPos.x<touch.position.x && parent.position.x<4f)
         {  
             parent.position += new Vector3(10,0,0)*Time.deltaTime;

             if(rotateActive && rotationAngle<30)
             {  
                 rotationAngle +=100*Time.deltaTime;
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

public void withRotation(){rotateActive = true; verticalActive = false; SceneManager.LoadScene(0);}
public void Vertical(){rotateActive = false; verticalActive = true; SceneManager.LoadScene(0);}  

public void wOutRotation(){rotateActive = false; verticalActive = false; SceneManager.LoadScene(0);}


    
}