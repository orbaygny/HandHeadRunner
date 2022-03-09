using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    private SwerveSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float maxRotateAmount = 2f;

    public float speed = 0f;

    


    // Start is called before the first frame update
    void Start()
    {
        _swerveInputSystem = GetComponent<SwerveSystem>();
    }

    // Update is called once per frame
    void Update()
    {

            transform.Translate(0, 0, speed * Time.fixedDeltaTime);
            float swerveAmount = Time.fixedDeltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            //swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
            float rotateAmount = Time.deltaTime * rotateSpeed * _swerveInputSystem.MoveFactorX;
            rotateAmount = Mathf.Clamp(rotateAmount, -maxRotateAmount, maxRotateAmount);
            //transform.Rotate(0, rotateAmount, 0);

    }

}
