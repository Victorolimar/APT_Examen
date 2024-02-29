using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody rb;
    private float posX;
    private float posZ;
    private Vector3 movimiento;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isCollider;

    private float camRayDistance = 1000f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Turning();
    }

    private void Move()
    {
        posX = Input.GetAxis("Horizontal");
        posZ = Input.GetAxis("Vertical");

        movimiento.Set(posX, 0f, posZ);
        movimiento = movimiento.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movimiento);
    }
    private void Jump()
    {
        RaycastHit hit;
        isCollider = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f, layer);
        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.black);
        if (Input.GetKeyDown(KeyCode.Space) && isCollider)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    public void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorhit;

        if(Physics.Raycast(camRay, out floorhit, camRayDistance,layer))
        {
            Vector3 playerToMouse = floorhit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }
}


// if(Input.GetKey(KeyCode.D))
        // {
        //     transform.Translate(speed * Time.deltaTime, 0, 0);
        // }
        // if(Input.GetKey(KeyCode.A))
        // {
        //     transform.Translate(- speed * Time.deltaTime ,0, 0);
        // }
        // if(Input.GetKey(KeyCode.W))
        // {
        //     transform.Translate(0, 0, speed * Time.deltaTime);
        // }
        // if(Input.GetKey(KeyCode.S))
        // {
        //     transform.Translate(0, 0, - speed * Time.deltaTime);
        // }