using UnityEngine;

public class ScarecrowJump : MonoBehaviour
{
    public float jumpForce = 5f;  // Force du saut
    public float jumpInterval = 2f; // Intervalle entre les sauts
    public Vector3 jumpArea = new Vector3(5f, 0f, 5f); // Zone de saut (largeur et profondeur)
    
    private Rigidbody rb;
    private float nextJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextJumpTime = Time.time + jumpInterval; // Initialise le temps du prochain saut
    }

    void Update()
    {
        if (Time.time >= nextJumpTime)
        {
            Jump();
            nextJumpTime = Time.time + jumpInterval; // Met à jour le temps du prochain saut
        }
    }

    void Jump()
    {
        // Générer une position aléatoire dans la zone définie
        Vector3 randomPosition = new Vector3(
            Random.Range(-jumpArea.x, jumpArea.x),
            0f, // On garde la hauteur à zéro
            Random.Range(-jumpArea.z, jumpArea.z)
        );

        // Appliquer la force de saut
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Déplacer l'épouvantail à la position aléatoire
        transform.position += randomPosition;
    }
}
