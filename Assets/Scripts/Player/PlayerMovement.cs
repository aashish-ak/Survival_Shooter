using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;
    Rigidbody rb;
    Vector3 move;
    Animator anim;
    int floorMask;
    float camRayLength = 100f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");

    }
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        Move(xAxis, yAxis);
        Turning();
        Animating(xAxis, yAxis);
    }
    void Move(float h, float v)
    {
        move.Set(h, 0f, v);
        move = move.normalized * Speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(rotation);
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
