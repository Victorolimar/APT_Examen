using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    private float originalSpeed; // Variable para guardar la velocidad original
    private Rigidbody rb;

    private float posX;
    private float posZ;
    private Vector3 movimiento;

    [Header("Jump")]
    
    [SerializeField] private float jumpForce;
    private float originalJumpForce;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isCollider;

    private float camRayDistance = 1000f;
    private float duracionPowerUp = 10f; // Duración del aumento de velocidad

    public void AumentarSalto(float aumentoFactor)
    {
        jumpForce *= aumentoFactor; // Aumentar la fuerza de salto por el factor de aumento
    }

    public void RestaurarSalto()
    {
        jumpForce = originalJumpForce; // Restaurar la fuerza de salto original
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed; // Guardar la velocidad original al inicioz
        originalJumpForce = jumpForce; 
    }

    private void Update()
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

        if (Input.GetKeyDown(KeyCode.Space) && isCollider)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    public void AumentarVelocidad(float aumento)
    {
        speed *= aumento; // Multiplicar la velocidad por el aumento
        Invoke("RestaurarVelocidad", duracionPowerUp); // Restaurar la velocidad original después de un tiempo específico
    }

    public void RestaurarVelocidad()
    {
        speed = originalSpeed; // Restaurar la velocidad original
    }

    public void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorhit;

        if (Physics.Raycast(camRay, out floorhit, camRayDistance, layer))
        {
            Vector3 playerToMouse = floorhit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }
}
