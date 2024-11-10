using UnityEngine;

public class MascotCtrl : MonoBehaviour
{
    public float hauteur = 1f;//hauteur souhait�e du perso au dessus du sol
    public float jumpForce = 5f;//force du saut du perso
    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;//d�sactivation de la gravit�
    }

    private void FixedUpdate()
    {
        // Maintient du perso � la hauteur souhait�e
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Vector3 targetPosition = new Vector3(transform.position.x, hit.point.y + hauteur, transform.position.z);
                rb.MovePosition(targetPosition);
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        // Gestion des mouvements
        float verticale = Input.GetAxis("Vertical");
        float horizontale = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontale, 0, verticale);
        rb.velocity = transform.TransformDirection(movement);

        // Gestion du saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
