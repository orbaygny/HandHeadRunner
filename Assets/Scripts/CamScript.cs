using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    //public Transform target;
    //public float smoothSpeed = 0.125f;

    
    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
      if(hhController.Instance.gameStart)
      {
        transform.parent.position += hhController.Instance.parent.forward* hhController.Instance.speed*Time.deltaTime;
      }
    }
  

    // Update is called once per frame
   void LateUpdate()
    {
         /*Vector3 desiredPosition = target.position + offset;
         desiredPosition.x = 0;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;*/
    }
}
