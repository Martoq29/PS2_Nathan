using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier = 1f;
    public float smoothTime = .3f;

    private Vector2 mouseStartPosition;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 velocity;

    private void Start()
    {
        startPosition = transform.position;
        mouseStartPosition = Input.mousePosition;
    }

    private void Update()
    {
        // Calculez le mouvement de la souris depuis le début
        Vector2 mouseDelta = (Vector2)Input.mousePosition - mouseStartPosition;

        // Calculez la nouvelle position cible en fonction du mouvement de la souris
        targetPosition = startPosition + new Vector3(mouseDelta.x, mouseDelta.y, 0) * offsetMultiplier;

        // Appliquez un lissage pour créer un effet de transition doux
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
