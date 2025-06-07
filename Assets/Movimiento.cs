using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public Transform camara;

    private Rigidbody rb;
    private float rotacionX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor
    }

    void Update()
    {
        Mover();
        RotarCamara();
    }

    void Mover()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * x + transform.forward * z;
        Vector3 velocidad = direccion * moveSpeed;
        velocidad.y = rb.linearVelocity.y;

        rb.linearVelocity = velocidad;
    }

    void RotarCamara()
    {
        if (Input.GetMouseButton(1)) // botón derecho
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

            camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
