using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Heal Ability")]
    public KeyCode healKey = KeyCode.Q;
    public int healAmount = 20;
    public float healCooldown = 10f;
    public Image healImage;
    private bool isHealCooldown = false;

    [Header("Shoot Ability")]
    public KeyCode shootKey = KeyCode.W;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 5f;
    public Image shootImage;
    private bool isShootCooldown = false;

    // Reference to the player's health component
    public PlayerHealth playerHealth;

    void Start()
    {
        healImage.fillAmount = 0;
        shootImage.fillAmount = 0;
    }

    void Update()
    {
        HandleHealAbility();
        HandleShootAbility();
    }

    void HandleHealAbility()
    {
        if (Input.GetKey(healKey) && !isHealCooldown)
        {
            isHealCooldown = true;
            healImage.fillAmount = 1;

            // Assuming you have a PlayerHealth script with a Heal method
            playerHealth.Heal(healAmount);
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

    void HandleShootAbility()
    {
        if (Input.GetKey(shootKey) && !isShootCooldown)
        {
            isShootCooldown = true;
            shootImage.fillAmount = 1;

            // Instantiate the bullet at the spawn point
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
