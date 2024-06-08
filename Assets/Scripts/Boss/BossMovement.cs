using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform pointA;  // Le point de d�part
    public Transform pointB;  // Le point d'arriv�e
    public float moveSpeed = 10f;

    private Transform target;  // La cible actuelle (pointA ou pointB)

    void Start()
    {
        target = pointB;  // Commence par se d�placer vers B
    }

    void Update()
    {
        // D�placement vers la cible
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // V�rifie si la position actuelle est proche de la cible
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
