using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // when game starts, when object becomes enabled, it will check on gameobject
        // that script is attached to, if object has component of type Rigidbody2D attached
        // if there is, it will store it in rb2d and reference it in script
        rb2d = GetComponent<Rigidbody2D>();
        // send commands to animator using anim variable
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            // if left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap");
                // every time player jumps, set velocity to zero so Rigidbody2D falls
                rb2d.velocity = Vector2.zero;
                // don't add any force on player's horizontal movement
                // add up force on player's vertical movement
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    // built-in unity function that gets called when game object with this component registers a collision
    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}