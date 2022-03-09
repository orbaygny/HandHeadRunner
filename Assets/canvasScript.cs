using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour
{
     public static canvasScript Instance { get; private set; }

     void Awake()
     {
         Instance = this;
     }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
