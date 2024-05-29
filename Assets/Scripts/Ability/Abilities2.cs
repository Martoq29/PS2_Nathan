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

    [Header("Melee Attack Ability")]
    public KeyCode meleeKey = KeyCode.Q;
    public float meleeCooldown = 2f;
    public Image meleeImage;
    private bool isMeleeCooldown = false;
    public float meleeRange = 1.5f; // Range of the melee attack
    public int meleeDamage = 30; // Damage of the melee attack

    void Start()
    {
        shootImage.fillAmount = 0;
        meleeImage.fillAmount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingAbility();
        HandleMeleeAbility(); // Call HandleMeleeAbility in Update
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

    void HandleMeleeAbility()
    {
        if (Input.GetKeyDown(meleeKey) && !isMeleeCooldown)
        {
            isMeleeCooldown = true;
            meleeImage.fillAmount = 1;

            // Trigger "Attack" animation
            animator.SetTrigger("Attack");

            // Perform melee attack logic here
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeRange);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    // Apply damage to the enemy if EnemyHealth component exists
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(meleeDamage);
                    }
                }
            }
        }

        if (isMeleeCooldown)
        {
            meleeImage.fillAmount -= 1 / meleeCooldown * Time.deltaTime;

            if (meleeImage.fillAmount <= 0)
            {
                meleeImage.fillAmount = 0;
                isMeleeCooldown = false;
            }
        }
    }

    void OnDrawGizmosSelected() // Optional: Visualize melee range in the editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}
