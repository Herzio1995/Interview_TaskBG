using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accesory : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animatorControl;
    private Vector2 movement;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animatorControl.SetFloat("Horizontal", movement.x);
        animatorControl.SetFloat("Vertical", movement.y);
        animatorControl.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}