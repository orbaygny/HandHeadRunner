using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                child.transform.localScale *=0.5f;
            }
        }
       
    }
    void Start()
    {
        ChangeEdible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ChangeEdible()
    {
        pp=3;
        switch(scaleCount)
        {
            case 1:
            
            foreach(Transform placePoint in placePoints)
            {
                placePoint.GetChild(pp%3).gameObject.SetActive(true);
                pp++;
            }
            scaleCount++;
            break;

            case 2:
               
            foreach(Transform placePoint in placePoints)
            {
                placePoint.GetChild(pp%3).gameObject.SetActive(false);
                placePoint.GetChild((pp%3)+3).gameObject.SetActive(true);
                pp++;
            }
            scaleCount++;
            break;

            case 3:
             
            foreach(Transform placePoint in placePoints)
            {
               
                placePoint.GetChild((pp%3)+3).gameObject.SetActive(false);
               
                placePoint.GetChild((pp%3)+6).gameObject.SetActive(true);
               
                pp++;
            }
            scaleCount++;
            break;
        }
    }
}
