using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRun : StateMachineBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private MagentaGod red;
    [SerializeField] private float timerCounter = 3;
    private float timer = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        red = animator.GetComponent<MagentaGod>();
        rb = animator.GetComponent<Rigidbody2D>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        red.LookAtPlayer();

        // Vector2 target = new Vector2(player.transform.position.x, rb.transform.position.y);
        // Vector2 newPos = Vector2.MoveTowards(rb.position, target, red.speed * Time.fixedDeltaTime);
        // rb.MovePosition(newPos);
        timer += Time.deltaTime;;
        if (timer >= timerCounter)
        {
            timer = 0;
            animator.SetTrigger("shoot");
        }
        // if (Vector2.Distance(player.transform.position, rb.position) <= red.attackRange)
        // {
            // animator.SetTrigger("shoot");
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("shoot");
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
