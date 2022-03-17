using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hhController.Instance.gameStart)
        {
             if (Input.GetMouseButtonDown(0)){
                 transform.GetChild(0).gameObject.SetActive(false);
                 hhController.Instance.GetComponent<Animator>().SetBool("gameStart",true);
                 hhController.Instance.gameStart = true;
                 
             }
        }
    }
}
