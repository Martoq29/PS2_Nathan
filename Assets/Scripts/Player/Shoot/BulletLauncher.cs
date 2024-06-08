using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab de la balle
    [SerializeField] private Transform launchPoint; // Point de lancement de la balle

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchBullet();
        }
    }

    private void LaunchBullet()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - launchPoint.position).normalized;

        GameObject bulletInstance = Instantiate(bulletPrefab, launchPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.SetStraightVelocity(direction);
    }
}
