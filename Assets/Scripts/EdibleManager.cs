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
        switch(scaleCount)
        {
            case 1:
            int i = 3;
            foreach(Transform placePoint in placePoints)
            {
                placePoint.GetChild(i%3).gameObject.SetActive(true);
                i++;
            }
            scaleCount++;
            break;

            case 2:
               i = 3;
            foreach(Transform placePoint in placePoints)
            {
                placePoint.GetChild(i%3).gameObject.SetActive(false);
                placePoint.GetChild((i%3)+3).gameObject.SetActive(true);
                i++;
            }
            scaleCount++;
            break;

            case 3:
             i = 3;
            foreach(Transform placePoint in placePoints)
            {
                placePoint.GetChild((i%3)+3).gameObject.SetActive(false);
                placePoint.GetChild((i%3)+6).gameObject.SetActive(true);
                i++;
            }
            scaleCount++;
            break;
        }
    }
}
