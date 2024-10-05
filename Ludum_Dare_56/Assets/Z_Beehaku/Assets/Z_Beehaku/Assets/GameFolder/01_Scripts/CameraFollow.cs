using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au personnage à suivre
    public float smoothSpeed = 0.125f; // Vitesse du lissage (lag)
    public Vector3 offset; // Décalage pour la position de la caméra

    void LateUpdate()
    {
        // Position désirée avec le décalage
        Vector3 desiredPosition = target.position + offset;

        // Position lissée avec interpolation pour l'effet de lag
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Appliquer la nouvelle position
        transform.position = smoothedPosition;
    }
}
