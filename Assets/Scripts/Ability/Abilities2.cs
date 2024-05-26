using UnityEngine;
using UnityEngine.UI;

public class Abilities2 : MonoBehaviour
{
    [Header("Shooting Ability")]
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public KeyCode shootKey = KeyCode.Mouse0;  // Left mouse button
    public float shootCooldown = 1f;
    public Image shootImage;
    private bool isShootCooldown = false;
    public float bulletLifetime = 3f; // Lifetime of the bullet in seconds

    private Animator animator;

    void Start()
    {
        shootImage.fillAmount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingAbility();
    }

    void HandleShootingAbility()
    {
        if (Input.GetKeyDown(shootKey) && !isShootCooldown)
        {
            isShootCooldown = true;
            shootImage.fillAmount = 1;

            // Trigger "Attack2" animation
            animator.SetTrigger("Attack");

            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            Destroy(bullet, bulletLifetime); // Destroy the bullet after bulletLifetime seconds
        }

        if (isShootCooldown)
        {
            shootImage.fillAmount -= 1 / shootCooldown * Time.deltaTime;

            if (shootImage.fillAmount <= 0)
            {
                shootImage.fillAmount = 0;
                isShootCooldown = false;
            }
        }
    }
}
