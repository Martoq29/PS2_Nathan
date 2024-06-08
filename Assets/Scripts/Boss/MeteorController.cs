using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float fallSpeed;

    public void SetFallSpeed(float speed)
    {
        fallSpeed = speed;
    }

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // D�truisez le m�t�ore lorsqu'il sort de l'�cran (facultatif, selon votre jeu)
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
