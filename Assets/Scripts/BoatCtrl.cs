
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCtrl : MonoBehaviour
{
    public float vitesse = 2f;
    public float hauteur = 1f;
    public float coeff = 0.15f;
    private float verticale;
    private float horizontale;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void FixedUpdate()
    {
        
            // maintien le bateau a une hauteur souhaitée au dessus de l'eau
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Water")
                {
                    Vector3 targetPosition = new Vector3(transform.position.x, hit.point.y + hauteur, transform.position.z);
                    rb.MovePosition(targetPosition);
                }
            }

            // détection et calcul des touches de direction
            verticale = Input.GetAxis("Vertical");
            horizontale = Input.GetAxis("Horizontal");
            Vector3 velocity = new Vector3(verticale * vitesse, 0, 0);
            rb.velocity = rb.transform.TransformDirection(velocity);
            Vector3 angularVel = new Vector3(0, horizontale * coeff * vitesse, 0);
            rb.angularVelocity = angularVel;
    }
}

