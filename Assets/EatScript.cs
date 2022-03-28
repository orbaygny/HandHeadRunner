using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EatScript : StateMachineBehaviour
{

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(hhController.Instance.edible !=null)
        {
            GameObject.Destroy(hhController.Instance.edible);
           hhController.Instance.EatTexter(EatTrigger.lastEated);
           CanvasScript.Instance.inc = true;

            
        }

        if(EdibleManager.Instance.eatCount >= 10){
            if(EdibleManager.Instance.scaleCount == 5)
            {
                EdibleManager.Instance.positionScaler = 5;
            }
            else{EdibleManager.Instance.positionScaler = 1;}
            hhController.Instance.ScaleUp(); 
            EdibleManager.Instance.ChangeEdible();
            EdibleManager.Instance.eatCount -=10;}

        if(EdibleManager.Instance.eatCount < 0 &&  EdibleManager.Instance.scaleCount-1 > 1)
        {   
            if(EdibleManager.Instance.scaleCount == 6)
            {
                EdibleManager.Instance.positionScaler = -5;
            }
            else{EdibleManager.Instance.positionScaler = -1;}
            hhController.Instance.ScaleDown();
            EdibleManager.Instance.scaleCount-=2;
            EdibleManager.Instance.eatCount =0;
            EdibleManager.Instance.ChangeEdible();
            

        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        //GameObject.Destroy(hhController.Instance.edible);
    //}

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
