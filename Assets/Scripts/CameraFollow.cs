
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform boat;
    public float distance = 10f;
    public float hauteur = 5f;
    public float vitesse = 0.05f; 

    private void LateUpdate()
    {
        if (boat == null) return;
        // Calcule de la position de la camera derrière le bateau
        Vector3 offset = -boat.transform.right * distance + Vector3.up * hauteur;
        Vector3 desiredPosition = boat.position + offset;
        // Déplacement de la caméra
        transform.position = Vector3.Lerp(transform.position, desiredPosition, vitesse);
        // Orientation de la caméra en fonction du deplacement du bateau
        Vector3 lookAtTarget = boat.position + boat.transform.forward * -1 + Vector3.up * 3; 
        transform.LookAt(lookAtTarget);
    }
}
