using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
   
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
   private float MoveFactorX => _moveFactorX;

    public bool isMoveForward = false;
    public bool isParent = false;

    public float speed = 0f;

     public float swerveSpeed = 0.5f;
    public float swerveMinus;
    public float swervePlus;


    public Transform parentObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
        if(hhController.Instance.gameStart){
        Movement();
        Swerve();
        }
    }


    void Movement()
    {
        if(isMoveForward)
        {
            switch(isParent){
                case true:
                parentObject.Translate(0, 0, speed * Time.fixedDeltaTime);
                break;

                case false:
                transform.Translate(0, 0, speed * Time.fixedDeltaTime);
                break;
            }
        }
    }

    void Swerve()
    {   float swerveAmount = Time.fixedDeltaTime * swerveSpeed * MoveFactorX;
        switch(isParent){
            case true:
            if(MoveFactorX<=0 && parentObject.position.x>swerveMinus)
            {
                parentObject.Translate(swerveAmount, 0, 0);
            } 
            if(MoveFactorX>0 && parentObject.position.x<swervePlus)
            {
                parentObject.Translate(swerveAmount, 0, 0);
            }           
            break;

            case false:
            if(MoveFactorX>=0 && transform.position.x>swerveMinus)
            {
                transform.Translate(swerveAmount, 0, 0);
            } 
            if(MoveFactorX>0 && transform.position.x<swervePlus)
            {
                transform.Translate(swerveAmount, 0, 0);
            }      
              
            break;
        }
    }
}
