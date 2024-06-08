using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public KeyCode shootKey = KeyCode.Mouse0;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 5f;
    public Image shootImage;
    private bool isShootCooldown = false;

    [Header("Gun Settings")]
    [SerializeField] private GameObject gun;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    [Header("Player Status")]
    public bool isPlayer2 = false;
    private PlayerHealth playerHealth;
    private Animator animator;

    private static Abilities instance;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        healImage.fillAmount = 0;
        shootImage.fillAmount = 0;
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleGunRotation();
        HandleHealAbility();
        HandleShootAbility();
        HandleGunRotation(); // Ajoutez cette ligne ici pour appeler HandleGunRotation dans la fonction Update
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        gun.transform.localScale = localScale;
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

            // Play attack animation
            animator.SetTrigger("Attack");

            Instantiate(bulletPrefab, bulletSpawnPoint.position, gun.transform.rotation);
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
