using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFinish : StateMachineBehaviour
{
    Material normalMat;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EdibleManager.Instance.eatCount =0;
        hhController.Instance.speed = 0;
        normalMat 
        = hhController.Instance.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material; 
        
        hhController.Instance.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material 
        = hhController.Instance.bombMat;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float t =stateInfo.normalizedTime*stateInfo.length;
       if(t>= 0.4f)
       {
        hhController.Instance.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material 
        = normalMat;
        hhController.Instance.transform.GetChild(7).gameObject.SetActive(true);
        hhController.Instance.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material 
        = hhController.Instance.bombFaceMat;
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
       //hhController.Instance.Fail();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
