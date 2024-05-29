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

    [Header("Healing Ability")]
    public KeyCode healKey = KeyCode.E; // Key for healing ability
    public int healAmount = 30; // Amount of health restored by healing ability
    public float healCooldown = 5f; // Cooldown for healing ability
    public Image healImage;
    private bool isHealCooldown = false;

    private Animator animator;

    void Start()
    {
        shootImage.fillAmount = 0;
        healImage.fillAmount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingAbility();
        HandleHealingAbility();
    }

    void HandleShootingAbility()
    {
        if (Input.GetKeyDown(shootKey) && !isShootCooldown)
        {
            isShootCooldown = true;
            shootImage.fillAmount = 1;

            // Trigger "Attack" animation
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

    void HandleHealingAbility()
    {
        if (Input.GetKeyDown(healKey) && !isHealCooldown)
        {
            isHealCooldown = true;
            healImage.fillAmount = 1;

            // Perform healing logic here
            // For example, you could increase the player's health by healAmount
            // You need to implement your own health management system

            // Start cooldown
            Invoke("ResetHealCooldown", healCooldown);
        }

        if (isHealCooldown)
        {
            healImage.fillAmount -= 1 / healCooldown * Time.deltaTime;
        }
    }

    void ResetHealCooldown()
    {
        isHealCooldown = false;
        healImage.fillAmount = 0;
    }
}
