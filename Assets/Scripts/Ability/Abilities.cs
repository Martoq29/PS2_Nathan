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
    public KeyCode shootKey = KeyCode.Mouse0;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 5f;
    public Image shootImage;
    private bool isShootCooldown = false;

    [Header("Player Status")]
    public bool isPlayer2 = false;
    private PlayerHealth playerHealth;
    private Animator animator;

    void Start()
    {
        healImage.fillAmount = 0;
        shootImage.fillAmount = 0;
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleHealAbility();
        HandleShootAbility();
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