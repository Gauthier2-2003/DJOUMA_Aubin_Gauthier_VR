using UnityEngine;
public class MapAligner : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,0);// pour mettre la map parfaitement horizontale pour une meilleur navigation
    }
}
