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

    // Update is called once per frame
    void Update()
    {
        if (player.movement != Vector2.zero){
            animator.SetInteger("Transition", 1);
            
        }else{
            animator.SetInteger("Transition", 0);
        }

        if (player.movement.x > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }else if (player.movement.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
