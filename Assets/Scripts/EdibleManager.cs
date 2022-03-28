using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EdibleManager : MonoBehaviour
{
   
    public static EdibleManager Instance { get; private set; }
    
    public List<Transform> placePoints;
    public List<Transform> locations;

    int count;

     public int  scaleCount =1;
    
    public int eatCount = 0;

    public int negativeCount = 0;
    
    public float positionScaler;

    //public int pp ;

   
    void Awake()
    {
        Instance = this;
        foreach(Transform child in transform)
        {
            placePoints.Add(child);
        }

        count= placePoints.Count;

        foreach(Transform placeP in placePoints)
        {
            placeP.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach(Transform placePoint in placePoints)
        {
            placePoint.GetChild(2).localScale = Vector3.one*2.5f;
            placePoint.GetChild(4).localScale = Vector3.one*3;
            placePoint.GetChild(6).localScale = Vector3.one*7;
            placePoint.GetChild(8).gameObject.tag = "Plane";
            placePoint.GetChild(8).gameObject.layer = 6;
            placePoint.GetChild(8).localScale = Vector3.one*4f;
            placePoint.GetChild(9).localScale = Vector3.one*1.5f;
            
            // placePoint.DOLocalRotate(new Vector3(0, 180, 0), 1.5f, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
        }

        locations = new List<Transform>();
       
    }
    void Start()
    {
        ChangeEdible();
      // transform.DOMoveY(0.5f,0.75f).SetLoops(-1,LoopType.Yoyo);
      // PlaceMaker();
      positionScaler = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceMaker()
    {
        foreach(Transform placePoint in placePoints)
        {
            float x= Random.Range(hhController.Instance.gameObject.GetComponent<SwerveSystem>().swerveMinus,
           hhController.Instance.gameObject.GetComponent<SwerveSystem>().swervePlus);
            placePoint.position = new Vector3(x,placePoint.position.y,placePoint.position.z);
          placePoint.DOLocalRotate(new Vector3(0, 180, 0), 1.5f, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
        }
    }

    IEnumerator BackToScale(Transform obj,Vector3 temp){
        yield return new WaitForSeconds(0.26f);
        if(obj != null)
        {
            obj.gameObject.SetActive(false);
             obj.localScale = temp;
        }
    }

  

    public  async void ChangeEdible()
    {
       
        int pp=0;
        int changer;
        
        
        switch(scaleCount)
        {
            case 1:
            if(locations.Count !=0)
            {   
                for(int i = 0; i<locations.Count ;i++)
                {
                    if(locations[i] != null)
                    {
                        Vector3 tempScale =  locations[i].localScale;
                    locations[i].DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(locations[i],tempScale));
                    }
                }
                
                /*foreach(Transform child in locations){ Vector3 tempScale =  child.localScale;
                child.DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(child,tempScale)); 
             }*/
            
            StartCoroutine("WaitAndCall");
            }
            else{

                foreach(Transform placePoint in placePoints)
            {
               
                if(placePoint.gameObject.layer == 6){
                     placePoint.GetChild(0).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(0));
                }

                if(placePoint.gameObject.layer == 7){
                     placePoint.GetChild(1).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(1));
                }
               
                
            }
            scaleCount++;
            }
            
            break;

            case 2:
            for(int i = 0; i<locations.Count ;i++)
                {
                    if(locations[i] != null)
                    {
                        Vector3 tempScale =  locations[i].localScale;
                    locations[i].DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(locations[i],tempScale));
                    }
                }
            /*foreach(Transform child in locations){ Vector3 tempScale =  child.localScale;
                child.DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(child,tempScale)); 
             }*/
            
            StartCoroutine("WaitAndCall");
           // foreach(Transform child in locations){child.gameObject.SetActive(false);}
            
           
           /* foreach(Transform placePoint in placePoints)
            {
                changer = Random.Range(3,6);
               // placePoint.GetChild(locations[pp]).gameObject.SetActive(false);
                placePoint.GetChild((changer%3)+3).gameObject.SetActive(true);
                 locations.Add(placePoint.GetChild((changer%3)+3));
                 Sizer(placePoint.GetChild((changer%3)+3));
                pp++;
                
            }
            //PlaceMaker();
            scaleCount++;*/
           
            break;

            case 3:
            for(int i = 0; i<locations.Count ;i++)
                {
                    if(locations[i] != null)
                    {
                        Vector3 tempScale =  locations[i].localScale;
                    locations[i].DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(locations[i],tempScale));
                    }
                }
            /*foreach(Transform child in locations){
                 Vector3 tempScale =  child.localScale;
                child.DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
             StartCoroutine(BackToScale(child,tempScale)); }*/
            StartCoroutine("WaitAndCall");
             //foreach(Transform child in locations){child.gameObject.SetActive(false);}
               
             
           /* foreach(Transform placePoint in placePoints)
            {
               changer = Random.Range(3,6);
                
               
                placePoint.GetChild((changer%3)+6).gameObject.SetActive(true);

                locations.Add(placePoint.GetChild((changer%3)+6));
                Sizer(placePoint.GetChild((changer%3)+6));
                pp++;
            }
            // PlaceMaker();
            scaleCount++;*/
             
            break;

            case 4:
            for(int i = 0; i<locations.Count ;i++)
                {
                    if(locations[i] != null)
                    {
                        Vector3 tempScale =  locations[i].localScale;
                    locations[i].DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(locations[i],tempScale));
                    }
                }
            /*foreach(Transform child in locations){
              Vector3 tempScale =  child.localScale;
                child.DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
             StartCoroutine(BackToScale(child,tempScale)); }*/
             
            StartCoroutine("WaitAndCall");
            break;

            case 5:
            for(int i = 0; i<locations.Count ;i++)
                {
                    if(locations[i] != null)
                    {
                        Vector3 tempScale =  locations[i].localScale;
                    locations[i].DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
                StartCoroutine(BackToScale(locations[i],tempScale));
                    }
                }
             /*foreach(Transform child in locations){ Vector3 tempScale =  child.localScale;
                child.DOScale(Vector3.zero,0.25f).SetEase(Ease.InFlash);
             child.gameObject.SetActive(false);
             child.localScale = tempScale;}*/
             
            StartCoroutine("WaitAndCall");
            break;
        }
    }

    void Sizer(Transform sizeObj)
    {
        Vector3 tmp = sizeObj.localScale;
        sizeObj.localScale = Vector3.zero;
        sizeObj.DOScale(tmp,0.25f).SetEase(Ease.InFlash);

    }

    private IEnumerator WaitAndCall()
    {
        
        yield return new WaitForSeconds(0.26f);
       //  PlaceMaker();
         Debug.Log("Scaleeee");
         int changer;
        switch(scaleCount)
        {
            case 1:
           
              foreach(Transform placePoint in placePoints)
            {
               if(positionScaler<0)
               {
                   
                    if(placePoint.position.x<0)
                    {
                        placePoint.localPosition -= Vector3.right*positionScaler; }
                    if(placePoint.position.x>0){
                         placePoint.localPosition += Vector3.right*positionScaler;
                    }
               }
                
                 if(placePoint.gameObject.layer == 6){
                    
                     placePoint.GetChild(0).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(0));
                Sizer(placePoint.GetChild(0));
                }

                if(placePoint.gameObject.layer == 7){
                    
                     placePoint.GetChild(1).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(1));
                Sizer(placePoint.GetChild(1));
                }
   
            }
            scaleCount++;
            break;

            case 2:
             
           foreach(Transform placePoint in placePoints)
            {
                    if(placePoint.position.x<0)
                    {
                        placePoint.localPosition -= Vector3.right*positionScaler; }
                    if(placePoint.position.x>0){
                         placePoint.localPosition += Vector3.right*positionScaler;
                    }

                 if(placePoint.gameObject.layer == 6){
                     
                     placePoint.GetChild(2).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(2));
                Sizer(placePoint.GetChild(2));
                }

                if(placePoint.gameObject.layer == 7){
                    placePoint.position -= new Vector3(1,0,0);
                     placePoint.GetChild(3).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(3));
                Sizer(placePoint.GetChild(3));
                }
                
                
                
            }
            
            scaleCount++;
            break;

            case 3:
            
           foreach(Transform placePoint in placePoints)
            {
                if(placePoint.position.x<0)
                    {
                        placePoint.localPosition -= Vector3.right*positionScaler; }
                    if(placePoint.position.x>0){
                         placePoint.localPosition += Vector3.right*positionScaler;
                    }
              
                 if(placePoint.gameObject.layer == 6){
                     
                     placePoint.GetChild(4).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(4));
                Sizer(placePoint.GetChild(4));
                }

                if(placePoint.gameObject.layer == 7){
                    
                     placePoint.GetChild(5).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(5));
                Sizer(placePoint.GetChild(5));
                }
                
            }
            
            scaleCount++;
            break;

             case 4:
              
              foreach(Transform placePoint in placePoints)
              {  if(placePoint.position.x<0)
                    {
                        placePoint.localPosition -= Vector3.right*positionScaler; }
                    if(placePoint.position.x>0){
                         placePoint.localPosition += Vector3.right*positionScaler;
                    }

                  if(placePoint.gameObject.layer == 6){
                     placePoint.GetChild(6).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(6));
                Sizer(placePoint.GetChild(6));
                }

                if(placePoint.gameObject.layer == 7){
                     placePoint.GetChild(7).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(7));
                Sizer(placePoint.GetChild(7));
                }}
                scaleCount++;
             break;

             case 5:
               
             foreach(Transform placePoint in placePoints)
              {  
                  if(placePoint.position.x<0)
                    {
                        placePoint.localPosition -= Vector3.right*positionScaler; }
                    if(placePoint.position.x>0){
                         placePoint.localPosition += Vector3.right*positionScaler;
                    }

                  if(placePoint.gameObject.layer == 6){
                     placePoint.GetChild(8).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(8));
                Sizer(placePoint.GetChild(8));
                }

                if(placePoint.gameObject.layer == 7){
                     placePoint.GetChild(9).gameObject.SetActive(true);
                locations.Add(placePoint.GetChild(9));
                Sizer(placePoint.GetChild(9));
                }}
                scaleCount++;
             break;

        }
        
       
    }
}
