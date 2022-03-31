using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;
using MoreMountains.NiceVibrations;

public class hhController : MonoBehaviour
{
    
    

     public static hhController Instance { get; private set; }

     private Vector2 startPos, endPos;
     public float speed = 15;
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
     public float  textHeight = 6f;

    
    public Transform floor;
    public Transform arena;

    public GameObject canvas;

    


     public GameObject edible;

     Vector3 camPos;

     public  bool gameStart;
    

     //public Vector2 startPos;

     public Transform parent;

     public Transform finalPlace;
     public Transform enemyPlace;

     public bool finishStart;

     float[] floorScales;
     int fScales_pointer = 0;
    
    float[] arenaScale_x;
    float[] arenaScale_z;
    int arena_sPointer = 0;

    float[] swervePluses;
    float[] swerveMinuses;
    int swervePointer = 0;

    float[] heroScales;
    int heroSpointer=0;

    Vector3 camVector;

    float time = 4f;
    bool hitHero;

    public Transform enemy;

    private bool timerSet = true;
    private float startTime;

    public float enemyHP = 10;
    public float heroHP = 10;
    
    bool followEnemy;

    bool fight;

    public Material bombMat;
    public Material bombFaceMat;

    Transform texter;
    
    bool end;

    public Transform diamonds;
    public Transform acidBarrel;
    //bool resetPos = false;
     void Awake() { Instance = this; }
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        speed = 15;
        DOTween.Init();
        anim = GetComponent<Animator>();
        if(verticalActive)
        {
            rotationPoint.rotation = Quaternion.Euler(-90,0,0);
            transform.position = new Vector3(transform.position.x,transform.position.y,3.0f);
            //Camera.main.GetComponent<CamScript>().offset.y=1;
            anim.SetBool("verticalActive",true);


        }

        camPos = Camera.main.transform.localPosition;
        camPos.x *= 0.5f;
        camPos.y *= 2f;
        camPos.z *= 0.5f;

        floorScales = new float[5];
        arenaScale_x =new float[5];
        arenaScale_z = new float[5];
        swervePluses = new float[5];
        swerveMinuses = new float[5];
        heroScales = new float[5];

        camVector = new Vector3(0,5,532);

        texter = rotationP_reset.GetChild(4);
    }

    // Update is called once per frame
    void Update()
    {
       
        
       if(gameStart && !finishStart){ Movement();
       }
       else if(finishStart&&!end){FinalControl();}
    
       if(followEnemy){
           Camera.main.transform.position =  new Vector3(enemy.GetChild(0).GetChild(2).position.x,
               Camera.main.transform.position.y,
               Camera.main.transform.position.z);/*Vector3.MoveTowards(Camera.main.transform.position,
               new Vector3(enemy.GetChild(0).GetChild(2).position.x,
               Camera.main.transform.position.y,
               Camera.main.transform.position.z),1f);*/

               if(enemy.GetChild(0).GetComponent<Rigidbody>().velocity.magnitude == 0)
               {
                   CanvasScript.Instance.transform.GetChild(4).gameObject.SetActive(true);
               }
       }

     
    }

   public void ScaleUp()
    {
        
        float scaleTo = transform.lossyScale.x+1;
        heroScales[heroSpointer] = transform.lossyScale.x;
        heroSpointer++;
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
        floorScales[fScales_pointer] =  floor.localScale.x;
        fScales_pointer++;

        arenaScale_x[arena_sPointer] = arena.localScale.x;
        arenaScale_z[arena_sPointer] = arena.localScale.z;
        arena_sPointer++;

        swervePluses[swervePointer] = gameObject.GetComponent<SwerveSystem>().swervePlus;
        swerveMinuses[swervePointer] = gameObject.GetComponent<SwerveSystem>().swerveMinus;
        swervePointer++;

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

         enemy.transform.localScale = Vector3.one*scaleTo;
        
        

        gameObject.GetComponent<SwerveSystem>().swerveMinus +=gameObject.GetComponent<SwerveSystem>().swerveMinus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swervePlus += gameObject.GetComponent<SwerveSystem>().swervePlus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swerveSpeed += 0.5f;
        textHeight+=2;
        //Vector2 tmpOffset =  floor.GetComponent<MeshRenderer>().material.mainTextureScale;
       // tmpOffset.y += 10f;
        //floor.GetComponent<MeshRenderer>().material.mainTextureScale = tmpOffset;
        speed +=10/2;

        camVector.x += 1; camVector.y+=5; camVector.z-=10;

        if(acidBarrel != null)
        {
            acidBarrel.localScale += Vector3.one * 0.2f;
            acidBarrel.position +=  Vector3.right;
        }
        diamonds.localScale += Vector3.one *0.2f;
        foreach(Transform child in diamonds)
        {
            if(child.localPosition.x<0){child.localPosition -= Vector3.right;}
            if(child.localPosition.x>0){child.localPosition += Vector3.right;}
            
        }
        Invoke("ScaleCalibration",1.2f);
    }

    public void ScaleDown()
    {
        
        float scaleTo = heroScales[EdibleManager.Instance.scaleCount-3];//transform.lossyScale.x-1;
        //scaleTo = Mathf.Round(scaleTo);
        rotationPoint.DOScale(scaleTo,1.2f).SetEase(Ease.OutBounce);
       Camera.main.transform.DOLocalMove( Camera.main.transform.localPosition-camPos,1.5f); 
      
        floor.DOScale(new Vector3(
               //floor.localScale.x-(floor.localScale.x*0.5f),
               floorScales[EdibleManager.Instance.scaleCount-3],
                floor.localScale.y,
                floor.localScale.z
            ),0.75f).SetEase(Ease.Linear);
        arena.DOScale(new Vector3(
               //arena.localScale.x-(arena.localScale.x*0.5f),
               arenaScale_x[EdibleManager.Instance.scaleCount-3],
                arena.localScale.y,
                arenaScale_z[EdibleManager.Instance.scaleCount-3]
                //arena.localScale.z-(arena.localScale.z*0.5f)
            ),0.75f).SetEase(Ease.Linear);
        
        enemy.transform.localScale = Vector3.one*scaleTo;
        gameObject.GetComponent<SwerveSystem>().swerveMinus = swerveMinuses[EdibleManager.Instance.scaleCount-3]; //-=gameObject.GetComponent<SwerveSystem>().swerveMinus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swervePlus = swervePluses[EdibleManager.Instance.scaleCount-3];//-= gameObject.GetComponent<SwerveSystem>().swervePlus * 0.5f;
        gameObject.GetComponent<SwerveSystem>().swerveSpeed -= 0.5f;
        textHeight+=2;
       
        speed -=10/2;

        camVector.x -= 1; camVector.y-=5; camVector.z+=10;
        diamonds.localScale -= Vector3.one *0.2f;
        foreach(Transform child in diamonds)
        {
            if(child.localPosition.x<0){child.localPosition += Vector3.right;}
            if(child.localPosition.x>0){child.localPosition -= Vector3.right;}
            
        }
         Invoke("ScaleCalibration",1.2f);
    }

    void LateUpdate()
    {
       

        
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

public void Restart(){SceneManager.LoadScene(0);}

public void wOutRotation(){rotateActive = false; TestVertical._vActive = false; SceneManager.LoadScene(0);}

public void EatTexter(int count)
{
    float randomPos = Random.Range(-1f*(EdibleManager.Instance.scaleCount-1),1f*(EdibleManager.Instance.scaleCount-1));
   Transform textTemp =  Instantiate(text,new Vector3(transform.localPosition.x,textHeight,parent.position.z),Quaternion.identity,rotationP_reset);
   textTemp.localPosition = texter.localPosition;
   
    /*hhController.Instance.texts.GetChild
    (hhController.Instance.textCount%3).gameObject.SetActive(true);

    Transform text = hhController.Instance.texts.GetChild
    (hhController.Instance.textCount%3);
    Vector3 pos = text.transform.localPosition;
    text.transform.DOMoveY(5,1f,false);
    text.transform.DOScale(1.25f,1f);
    StartCoroutine(TurnOffText(pos));*/
    if(count<0)
    {   
         textTemp.GetComponent<TextMeshPro>().color = Color.red;
        textTemp.GetComponent<TextMeshPro>().text =count.ToString();
    }
    else{
         textTemp.GetComponent<TextMeshPro>().color = Color.green;
        textTemp.GetComponent<TextMeshPro>().text = "+"+count;
    }
    
    textTemp.GetComponent<TextMeshPro>().fontSize = 15;
    textTemp.transform.DOLocalMoveY(texter.localPosition.y+1,1f,false);
    textTemp.transform.DOScale(0f,1f);
    StartCoroutine(TurnOffText(textTemp));
    
    
    
}

IEnumerator TurnOffText(Transform textTemp)
{
    yield return new WaitForSeconds(1.1f);
    Destroy(textTemp.gameObject);

}

 IEnumerator FinalTimer()
{
    yield return new WaitForSeconds(1.6f);
    Camera.main.GetComponent<CameraShaker>().enabled = true;
    Transform prnt = finalPlace.parent;
    for(int i =3 ; i<13 ;i++)
    {
        prnt.GetChild(i).gameObject.SetActive(true);
    }
}

IEnumerator Ending()
{
    yield return new WaitForSeconds(0.4f);
    //Camera.main.transform.parent = enemy; 
    CanvasScript.Instance.transform.GetChild(6).gameObject.SetActive(false); 
     enemy.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            enemy.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            enemy.GetChild(0).GetComponent<SphereCollider>().enabled = true;

            int a = Random.Range(25,51);
            followEnemy = true;
            enemy.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.right*a*(EdibleManager.Instance.scaleCount-1),ForceMode.Impulse);
            
}


void FinalControl()
{   
    if(fight){if(timerSet){startTime = Time.time; timerSet =false;}
    float t = Time.time-startTime;
       // string min =((int)t/60).ToString();
        string sec = (t%60).ToString("f1");
        Debug.Log(sec);
    if(Input.GetMouseButtonDown(0))
    {
        
        if(enemyHP==2){
            anim.SetTrigger("Hit");
            MMVibrationManager.Haptic(HapticTypes.Failure);
            Camera.main.gameObject.GetComponent<CameraShaker>().enabled=false;
            StartCoroutine(Ending());
           
        }
      else{  int tmp = Random.Range(1,3);
        anim.SetTrigger("Hit"+tmp);}
        startTime =Time.time;
        CameraShaker.Instance.ShakeOnce(2f,2f,1f,1f);
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        enemyHP-=2;
        CanvasScript.Instance.enmyDec = true;
       
    }

    if(heroHP ==2)
    {
        int tmp = Random.Range(1,3);
        enemy.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Hit"+tmp);
        startTime = Time.time;
        CameraShaker.Instance.ShakeOnce(2f,2f,1f,1f);
        MMVibrationManager.Haptic(HapticTypes.Failure);
        heroHP -= 2;
        CanvasScript.Instance.heroDec = true;
        anim.SetTrigger("BeatFail");
        end = true;
    }
    else if(float.Parse(sec) >=4f)
    {
        int tmp = Random.Range(1,3);
        enemy.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Hit"+tmp);
        startTime = Time.time;
        CameraShaker.Instance.ShakeOnce(2f,2f,1f,1f);
        MMVibrationManager.Haptic(HapticTypes.Failure);
        heroHP -= 2;
        CanvasScript.Instance.heroDec = true;
    }}

}


public void FinishStart()
{   
    Camera.main.transform.parent = null;
    Camera.main.transform.rotation = Quaternion.Euler(15,0,0);
    Camera.main.transform.DOMove(camVector,1.5f);
        transform.DOJump(new Vector3(
                    hhController.Instance.finalPlace.position.x,
                    hhController.Instance.transform.position.y,
                    hhController.Instance.finalPlace.position.z),3,1,1);
    enemy.GetChild(0).DOMove(enemyPlace.position,1);
    CameraShaker.Instance.RestPositionOffset =camVector;
    CameraShaker.Instance.RestRotationOffset = new Vector3(15,0,0);
    StartCoroutine(FinalTimer());
    /*Camera.main.transform.DOLocalMove(new Vector3(0,10.5f,22),1.5f);
    Camera.main.transform.DOLocalRotateQuaternion(Quaternion.Euler(
        Camera.main.transform.rotation.eulerAngles.x,
        0,
        Camera.main.transform.rotation.eulerAngles.z),1.5f);*/
        StartCoroutine(CanvasOpen());
}

IEnumerator CanvasOpen()
{
    yield return new WaitForSeconds(1f);
    
    canvas.transform.GetChild(5).DOScale(10,0.5f).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Linear);
    canvas.transform.GetChild(6).gameObject.SetActive(true);
    fight = true;

    /*canvas.transform.GetChild(4).gameObject.SetActive(true);
    PlayerPrefs.SetInt("Level",
        PlayerPrefs.GetInt("Level",1)+1);*/
}

public void Fail()
{
    
    speed =0;
    //rotationPoint.DOScale(Vector3.zero,0.5f).SetEase(Ease.InExpo);
    transform.GetChild(9).gameObject.SetActive(true);
    anim.SetTrigger("BeatFail");
    //canvas.transform.GetChild(7).gameObject.SetActive(true);
    
}
void ScaleCalibration()
{   
    Debug.Log("Calib Start");
  if(EdibleManager.Instance.scaleCount-1 == 1){rotationPoint.localScale = Vector3.one;}
   else if(EdibleManager.Instance.scaleCount-1 > 1){
       if(rotationPoint.localScale.x < heroScales[EdibleManager.Instance.eatCount-1]+1 
       || rotationPoint.localScale.x> heroScales[EdibleManager.Instance.eatCount-1]+1)
    {
        rotationPoint.localScale = Vector3.one* (heroScales[EdibleManager.Instance.eatCount-1]+1);
        Debug.Log("Calib DONE");
    }}
}
}
