using UnityEngine;

public class b_TriangleFollow : MonoBehaviour
{
    private Transform player; // Référence du joueur à suivre
    public float followSpeed = 3f; // Vitesse du triangle
    public bool isFollowing = false; // Indique si le triangle suit le joueur

    private MeshRenderer sphereRenderer;
    private Collider sphereCollider;
    private Transform triangleParent; // Référence au parent du triangle
private Collider triangleCollider;
    void Start()
    {
        // Assurez-vous que le collider du triangle est bien un trigger
        triangleCollider = GetComponent<Collider>(); 
        sphereCollider = transform.GetChild(0).GetComponent<Collider>();
        if (triangleCollider != null)
        {
            triangleCollider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Le triangle doit avoir un Collider attaché !");
        }

        // Récupérer le MeshRenderer de la sphère enfant
        sphereRenderer = transform.GetChild(0).GetComponent<MeshRenderer>(); 

        // Désactiver le MeshRenderer de la sphère au démarrage
        if (sphereRenderer != null)
        {
            sphereRenderer.enabled = false; // La sphère est invisible au départ
        }

        sphereCollider.enabled = false;


        // Référence au parent du triangle
        triangleParent = transform.parent; // Le parent doit être correctement assigné dans Unity
        if (triangleParent == null)
        {
            Debug.LogError("Le triangle n'a pas de parent défini !");
        }
    }

    void Update()
    {
        // Si le triangle suit le joueur
        if (isFollowing)
        {
            FollowPlayer();

           
        }
        
    }

    // Détecter la collision avec le joueur
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Collision détectée !");
        if (other.gameObject.CompareTag("Player")) 
        {
            player = other.transform;
            sphereRenderer.enabled = true;
            isFollowing = true;
            triangleCollider.isTrigger = false;
            sphereCollider.enabled = true;
        }
    }

    void FollowPlayer()
    {
        if (triangleParent != null)
        {
            // Calculer la position cible du parent du triangle
            Vector3 targetPosition = player.position;

            // Interpolation pour déplacer le parent du triangle progressivement vers le joueur
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
