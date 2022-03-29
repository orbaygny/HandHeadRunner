using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHurt : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.gameObject.tag == "Hero"){
             if(stateInfo.IsName("Hit1")){
            hhController.Instance.enemy.GetChild(0).GetComponent<Animator>().SetTrigger("Hurt1"); }

            if(stateInfo.IsName("Hit2")){
            hhController.Instance.enemy.GetChild(0).GetComponent<Animator>().SetTrigger("Hurt2"); }

            if(stateInfo.IsName("FinalHit"))
            {
                hhController.Instance.enemy.GetChild(0).GetComponent<Animator>().SetTrigger("FHurt"); 
            }
        }

        if(animator.gameObject.tag == "Evil")
        {
            if(stateInfo.IsName("Hit_1")){
            hhController.Instance.anim.SetTrigger("Hurt1"); }

            if(stateInfo.IsName("Hit_2")){
            hhController.Instance.anim.SetTrigger("Hurt2"); }
         }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  //  override public void OnStateUpdate(Animator animator, AsnimatorStateInfo stateInfo, int layerIndex)
  //  {
   //     
   // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
