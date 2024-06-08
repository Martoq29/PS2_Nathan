using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform pointA;  // Le point de départ
    public Transform pointB;  // Le point d'arrivée
    public float moveSpeed = 10f;

    private Transform target;  // La cible actuelle (pointA ou pointB)

    void Start()
    {
        target = pointB;  // Commence par se déplacer vers B
    }

    void Update()
    {
        // Déplacement vers la cible
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Vérifie si la position actuelle est proche de la cible
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Change de cible
            if (target == pointB)
            {
                target = pointA;
            }
            else
            {
                target = pointB;
            }
        }
    }
}
