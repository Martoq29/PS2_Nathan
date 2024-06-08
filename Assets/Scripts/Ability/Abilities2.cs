using UnityEngine;
using UnityEngine.UI;

public class Abilities2 : MonoBehaviour
{
    [Header("Shooting Ability 1")]
    public Transform shootingPoint1;
    public GameObject bulletPrefab1;
    public KeyCode shootKey1 = KeyCode.Mouse0;  // Left mouse button
    public float shootCooldown1 = 1f;
    public Image shootImage1;
    private bool isShootCooldown1 = false;
    public float bulletLifetime1 = 3f; // Lifetime of the bullet in seconds

    [Header("Shooting Ability 2")]
    public Transform shootingPoint2;
    public GameObject bulletPrefab2;
    public KeyCode shootKey2 = KeyCode.Mouse1;  // Right mouse button
    public float shootCooldown2 = 2f;
    public Image shootImage2;
    private bool isShootCooldown2 = false;
    public float bulletLifetime2 = 3f; // Lifetime of the bullet in seconds

    private Animator animator;

    void Start()
    {
        shootImage1.fillAmount = 0;
        shootImage2.fillAmount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingAbility1();
        HandleShootingAbility2();
    }

    void HandleShootingAbility1()
    {
        if (Input.GetKeyDown(shootKey1) && !isShootCooldown1)
        {
            isShootCooldown1 = true;
            shootImage1.fillAmount = 1;

            // Trigger "Attack" animation
            animator.SetTrigger("Attack");

            GameObject bullet = Instantiate(bulletPrefab1, shootingPoint1.position, shootingPoint1.rotation);
            Destroy(bullet, bulletLifetime1); // Destroy the bullet after bulletLifetime1 seconds
        }

        if (isShootCooldown1)
        {
            shootImage1.fillAmount -= 1 / shootCooldown1 * Time.deltaTime;

            if (shootImage1.fillAmount <= 0)
            {
                shootImage1.fillAmount = 0;
                isShootCooldown1 = false;
            }
        }
    }

    void HandleShootingAbility2()
    {
        if (Input.GetKeyDown(shootKey2) && !isShootCooldown2)
        {
            isShootCooldown2 = true;
            shootImage2.fillAmount = 1;

            // Trigger "Attack" animation
            animator.SetTrigger("Attack");

            GameObject bullet = Instantiate(bulletPrefab2, shootingPoint2.position, shootingPoint2.rotation);
            Destroy(bullet, bulletLifetime2); // Destroy the bullet after bulletLifetime2 seconds
        }

        if (isShootCooldown2)
        {
            shootImage2.fillAmount -= 1 / shootCooldown2 * Time.deltaTime;

            if (shootImage2.fillAmount <= 0)
            {
                shootImage2.fillAmount = 0;
                isShootCooldown2 = false;
            }
        }
    }
}
