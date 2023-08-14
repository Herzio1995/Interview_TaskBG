using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float speedX;
    private float speedY;
    private Animator AnimatorControl;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        AnimatorControl = GetComponent<Animator>();
    }

    void Update() {
        //horizontal movement
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        if (speedX > 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if(speedX < 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        AnimatorControl.SetBool("LatWalking", speedX != 0.0f);
        

        //vertical movement
        speedY = Input.GetAxisRaw("Vertical") * speed;
        if (speedY > 0.0f) {
            AnimatorControl.SetBool("UpWalk", true);
            AnimatorControl.SetBool("DownWalk", false);
            
        }
        else if (speedY < 0.0f) {
            AnimatorControl.SetBool("DownWalk", true);
            AnimatorControl.SetBool("UpWalk", false);
        }
        else {
            AnimatorControl.SetBool("UpWalk", false);
            AnimatorControl.SetBool("DownWalk", false);
        }

        rb.velocity = new Vector2(speedX, speedY);
    }
}