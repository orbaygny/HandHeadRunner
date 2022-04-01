using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
   public Slider eatSlider;

   public Slider heroHpSlider;
   public Slider enemyHpSlider;
   
   public static CanvasScript Instance { get; private set; }
    
    public bool inc = false;

    public bool heroDec = false;
    public bool enmyDec = false;
    void Awake()
    {
        Instance = this;

        heroHpSlider = transform.GetChild(6).GetChild(0).GetComponent<Slider>();
        enemyHpSlider   = transform.GetChild(6).GetChild(1).GetComponent<Slider>();
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
       // eatSlider.value = EdibleManager.Instance.eatCount;

         if(inc)
         {  if(eatSlider.value == EdibleManager.Instance.eatCount){inc = false;}
             eatSlider.value = Mathf.Lerp(eatSlider.value,EdibleManager.Instance.eatCount,5*Time.deltaTime);
         }

         if(heroDec)
         {if(heroHpSlider.value == hhController.Instance.heroHP){heroDec = false;}
           heroHpSlider.value = Mathf.Lerp(heroHpSlider.value,hhController.Instance.heroHP,5*Time.deltaTime);}
        
        if(enmyDec){
            {if(enemyHpSlider.value == hhController.Instance.enemyHP){enmyDec = false;}
           enemyHpSlider.value = Mathf.Lerp(enemyHpSlider.value,hhController.Instance.enemyHP,5*Time.deltaTime);}
        }
    }


public void Restart(){ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}

public void BarIncrease()
{
       Debug.Log("Girdi");
        inc = true;
        eatSlider.value = Mathf.Lerp(eatSlider.value,EdibleManager.Instance.eatCount,5*Time.deltaTime);
    
}

public void HeroGetDamage()
{
    heroHpSlider.value = Mathf.Lerp(heroHpSlider.value,hhController.Instance.heroHP,5*Time.deltaTime);
}

public void EnemyGetDamage()
{
    enemyHpSlider.value = Mathf.Lerp(enemyHpSlider.value,hhController.Instance.enemyHP,5*Time.deltaTime);
}
}
