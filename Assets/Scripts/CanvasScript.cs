using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
   public Slider eatSlider;
    
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
        eatSlider.value = EdibleManager.Instance.eatCount;
         
         
    }


public void Restart(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
}
