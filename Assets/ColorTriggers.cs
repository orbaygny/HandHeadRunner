using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTriggers : MonoBehaviour
{
    public Material mat;
    
    MeshRenderer parentRenderer;
    // Start is called before the first frame update
    void Start()
    {
        parentRenderer = transform.parent.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.tag == "Evil"){ parentRenderer.material = mat;}
   }
}
