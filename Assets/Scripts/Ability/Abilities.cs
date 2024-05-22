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
    public KeyCode shootKey = KeyCode.Mouse0; // Utilise le clic gauche de la souris pour tirer
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 5f;
    public Image shootImage;
    private bool isShootCooldown = false;

    [Header("Shield Ability")]
    public KeyCode shieldKey = KeyCode.E;
    public float shieldDuration = 3f;
    public float shieldCooldown = 10f;
    public Image shieldImage;
    private bool isShieldCooldown = false;
    private Movement playerMovement;

    // Référence au composant de santé du joueur
    public PlayerHealth playerHealth;

    public bool isPlayer2; // Variable pour indiquer si le joueur actif est le joueur 2

    void Start()
    {
        healImage.fillAmount = 0;
        shootImage.fillAmount = 0;
        shieldImage.fillAmount = 0;
        playerMovement = GetComponent<Movement>();
    }

    void Update()
    {
        if (!isPlayer2)
        {
            HandleHealAbility();
            HandleShootAbility();
            HandleShieldAbility();
        }
        else
        {
            Destroy(healImage.gameObject);
            Destroy(shootImage.gameObject);
            Destroy(shieldImage.gameObject);
        }
    }

    void HandleHealAbility()
    {
        if (Input.GetKeyDown(healKey) && !isHealCooldown)
        {
            isHealCooldown = true;
            healImage.fillAmount = 1;

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
        if (Input.GetKeyDown(shootKey) && !isShootCooldown)
        {
            isShootCooldown = true;
            shootImage.fillAmount = 1;

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

    void HandleShieldAbility()
    {
        if (Input.GetKeyDown(shieldKey) && !isShieldCooldown)
        {
            isShieldCooldown = true;
            shieldImage.fillAmount = 1;

            playerMovement.ActivateShield(shieldDuration);
        }

        if (isShieldCooldown)
        {
            shieldImage.fillAmount -= 1 / shieldCooldown * Time.deltaTime;

            if (shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 0;
                isShieldCooldown = false;
            }
        }
    }
}
