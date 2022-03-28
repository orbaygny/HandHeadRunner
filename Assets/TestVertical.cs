using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestVertical : MonoBehaviour
{
public static bool _vActive = true;

void Awake()
{
    if(_vActive)
    {

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        Camera.main.transform.localRotation = Quaternion.Euler(15,-10,0);
         Camera.main.transform.localPosition = new Vector3(2f,1.5f,-10);

        
        
    }

    else
    {
         transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

        Camera.main.transform.localPosition = new Vector3(0,8,-11);
       
    }
}
    public void Vertical(){
_vActive = true;
SceneManager.LoadScene(0);}  

   }
