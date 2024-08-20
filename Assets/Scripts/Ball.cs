using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 12f;
    public Rigidbody rb;
    Vector2 moveInput;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Move(){
        Vector3 velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y * moveSpeed, moveInput.y * moveSpeed);
        // = transform.TransformDirection(velocity);
        if(moveInput.x == -1){
            rb.AddForce(-moveSpeed, 0, 0);
        }else if(moveInput.x == 1){
            rb.AddForce(moveSpeed, 0, 0);
        }
    }

    void FixedUpdate(){
        Move();
    }

    void OnMovement(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnDrop(){
        GetComponent<PlayerInput>().enabled = false;
        rb.velocity = new Vector3(0, 0, 0);
        rb.useGravity = true;
    }

}
