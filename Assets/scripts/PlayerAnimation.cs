
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animator;
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        AnimationMove();
    }


    #region Animation
    void AnimationMove()
    {
        if (player.Movement != Vector2.zero)
        {
            if (player.IsRolling)
            {
                AnimationRoll();
            }
            else
            {
                AnimationRun();
            }
        }
        else
        {
            AnimationIdle();
        }

        AnimationDirection();

    }

    void AnimationRun()
    {
        if (player.IsRunning)
        {
            animator.SetInteger("Transition", 2);
        }
        else
        {
            animator.SetInteger("Transition", 1);
        }
    }

    void AnimationRoll()
    {
        animator.SetTrigger("isRoll");

    }


    void AnimationIdle()
    {
        animator.SetInteger("Transition", 0);
    }

    void AnimationDirection()
    {
        if (player.Movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.Movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    #endregion


}
