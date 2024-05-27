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

    [Header("Heal Ability")] // New variables for Heal Ability
    public KeyCode healKey = KeyCode.Q;
    public int healAmount = 20;
    public float healCooldown = 10f;
    public Image healImage;
    private bool isHealCooldown = false;

    void Start()
    {
        shootImage.fillAmount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingAbility();
        HandleHealAbility(); // Call HandleHealAbility in Update
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

    void HandleHealAbility() // New method for Heal Ability
    {
        if (Input.GetKeyDown(healKey) && !isHealCooldown)
        {
            isHealCooldown = true;
            healImage.fillAmount = 1;

            // Handle healing logic here
            // Example: playerHealth.Heal(healAmount);
        }

        if (isHealCooldown)
        {
            healImage.fillAmount -= 1 / healCooldown * Time.deltaTime;

            if (healImage.fillAmount <= 0)
            {
                healImage.fillAmount = 0;
                isHealCooldown = false;
            }
        }
    }
}
