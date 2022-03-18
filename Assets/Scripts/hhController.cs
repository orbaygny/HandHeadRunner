using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class hhController : MonoBehaviour
{
    
    

     public static hhController Instance { get; private set; }

     private Vector2 startPos, endPos;
     public float speed = 9;
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

     public Transform text;
     public float  textHeight = 2.5f;

    
    public Transform floor;
    public Transform arena;

    public GameObject canvas;

    


     public GameObject edible;

     Vector3 camPos;

     public  bool gameStart;
    

     //public Vector2 startPos;

     public Transform parent;

     public Transform finalPlace;

     public bool finishStart;

    //bool resetPos = false;
     void Awake() { Instance = this; }
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        speed = 9;
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
        camPos.x *= 0.5f;
        camPos.y *= 2;
        camPos.z *= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
       if(gameStart && !finishStart){ Movement();
       }

     
    }

   public void ScaleUp()
    {
        float scaleTo = transform.lossyScale.x+1f;
       /* transform.localScale = new Vector3(transform.localScale.x-0.2f,transform.localScale.y-0.2f,transform.localScale.z-0.2f);
        transform.localScale = new Vector3(transform.localScale.x+0.4f,transform.localScale.y+0.4f,transform.localScale.z+0.4f);
        transform.localScale = new Vector3(transform.localScale.x-0.1f,transform.localScale.y-0.1f,transform.localScale.z-0.1f);*/
        rotationPoint.DOScale(scaleTo,1.2f).SetEase(Ease.OutBounce);
        Camera.main.transform.DOLocalMove( Camera.main.transform.localPosition+camPos,1.5f); 
        /*foreach(Transform child in floor)
        {
            child.DOScale(new Vector3(
               child.localScale.x+(child.localScale.x*0.5f),
                child.localScale.y,
                child.localScale.z
            ),0.75f).SetEase(Ease.Linear);
        }*/

        floor.DOScale(new Vector3(
               floor.localScale.x+(floor.localScale.x*0.5f),
                floor.localScale.y,
                floor.localScale.z
            ),0.75f).SetEase(Ease.Linear);
        arena.DOScale(new Vector3(
               arena.localScale.x+(arena.localScale.x*0.5f),
                arena.localScale.y,
                arena.localScale.z+(arena.localScale.z*0.5f)
            ),0.75f).SetEase(Ease.Linear);
        
        gameObject.GetComponent<SwerveSystem>().swerveMinus +=gameObject.GetComponent<SwerveSystem>().swerveMinus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swervePlus += gameObject.GetComponent<SwerveSystem>().swervePlus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swerveSpeed += 0.5f;
        textHeight+=2;
        speed +=9/2;

        

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
       parent.position += parent.forward*speed*Time.deltaTime;
    
       
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

public void EatTexter(int count)
{
    float randomPos = Random.Range(-2,2);
   Transform textTemp =  Instantiate(text,new Vector3(randomPos,textHeight,parent.position.z),Quaternion.identity,parent);
    /*hhController.Instance.texts.GetChild
    (hhController.Instance.textCount%3).gameObject.SetActive(true);

    Transform text = hhController.Instance.texts.GetChild
    (hhController.Instance.textCount%3);
    Vector3 pos = text.transform.localPosition;
    text.transform.DOMoveY(5,1f,false);
    text.transform.DOScale(1.25f,1f);
    StartCoroutine(TurnOffText(pos));*/
    textTemp.GetComponent<TextMeshPro>().text = "+"+count;
    textTemp.transform.DOMoveY(textHeight+2,1f,false);
    textTemp.transform.DOScale(1f,1f);
    StartCoroutine(TurnOffText(textTemp));
    
    
    
}

IEnumerator TurnOffText(Transform textTemp)
{
    yield return new WaitForSeconds(1.1f);
    Destroy(textTemp.gameObject);

}

public void FinishStart()
{
    transform.DOJump(new Vector3(
                    hhController.Instance.finalPlace.position.x,
                    hhController.Instance.transform.position.y,
                    hhController.Instance.finalPlace.position.z),3,1,1);
    Camera.main.transform.DOLocalMove(new Vector3(0,10.5f,22),1.5f);
    Camera.main.transform.DOLocalRotateQuaternion(Quaternion.Euler(
        Camera.main.transform.rotation.eulerAngles.x,
        0,
        Camera.main.transform.rotation.eulerAngles.z),1.5f);
        StartCoroutine(CanvasOpen());
}

IEnumerator CanvasOpen()
{
    yield return new WaitForSeconds(1.6f);
    
    canvas.transform.GetChild(4).gameObject.SetActive(true);
    PlayerPrefs.SetInt("Level",
        PlayerPrefs.GetInt("Level",1)+1);
}
}
