using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    private Vector2 movement;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(movement.x !=0 || movement.y != 0){
            anim.SetFloat("LastMoveX", movement.x);
            anim.SetFloat("LastMoveY", movement.y);
        }
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement*speed*Time.fixedDeltaTime);
    }
}
