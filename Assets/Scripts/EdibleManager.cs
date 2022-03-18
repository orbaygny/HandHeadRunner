using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EdibleManager : MonoBehaviour
{
   
    public static EdibleManager Instance { get; private set; }
    
    public List<Transform> placePoints;

    int count;
     int  scaleCount =1;
    
    public int eatCount = 0;

    int pp ;

   
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
            foreach(Transform child in placePoint){
              //  child.transform.localScale *=0.5f;
            }
        }
       
    }
    void Start()
    {
        ChangeEdible();
       transform.DOMoveY(0.5f,0.75f).SetLoops(-1,LoopType.Yoyo);
       foreach(Transform placePoint in placePoints)
        {
            float x= Random.Range(-5,5.1f);
            placePoint.position = new Vector3(x,placePoint.position.y,placePoint.position.z);
            placePoint.DOLocalRotate(new Vector3(0, 50, 0), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ChangeEdible()
    {
        pp=3;
        int changer;
        switch(scaleCount)
        {
            case 1:
            
            foreach(Transform placePoint in placePoints)
            {
                changer = Random.Range(3,6);
                placePoint.GetChild(pp%3).gameObject.SetActive(true);
                //placePoint.GetChild(pp%3).DOMoveY(1,0.5f).SetLoops(-1,LoopType.Yoyo);
                pp++;
            }
            scaleCount++;
            break;

            case 2:
               
            foreach(Transform placePoint in placePoints)
            {
                changer = Random.Range(3,6);
                placePoint.GetChild(pp%3).gameObject.SetActive(false);
                placePoint.GetChild((pp%3)+3).gameObject.SetActive(true);
                pp++;
            }
            scaleCount++;
            break;

            case 3:
             
            foreach(Transform placePoint in placePoints)
            {
               changer = Random.Range(3,6);
                placePoint.GetChild((pp%3)+3).gameObject.SetActive(false);
               
                placePoint.GetChild((pp%3)+6).gameObject.SetActive(true);
               
                pp++;
            }
            scaleCount++;
            break;
        }
    }
}
