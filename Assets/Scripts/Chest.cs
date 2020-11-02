using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] public bool isOpen;
    [SerializeField] public Animator animator;
    
    
    


    public void Start()
    {
        /*
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-9, 11);
        */
    }

    

    

    public void FixedUpdate()
    {
        animator.SetBool("isOpen", isOpen);
        /*
        if (transform.position.x < -3)
        {
            Destroy(this.gameObject);
        }
        */
    }

    public void openChest()
    {
        if (!isOpen)
        {
            isOpen = true;

        }
    }
}
