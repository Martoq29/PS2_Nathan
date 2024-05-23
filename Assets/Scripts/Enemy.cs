using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    private bool isPlayerInRange = false;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>(); // Obtenir le Rigidbody2D attaché à l'ennemi
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Vector2 direction = Vector2.zero;

        if (distanceToPlayer > stoppingDistance)
        {
            // Se déplace vers le joueur
            direction = (player.position - transform.position).normalized;
        }
        else if (distanceToPlayer <= stoppingDistance && distanceToPlayer > retreatDistance)
        {
            // Reste sur place
            direction = Vector2.zero;
        }
        else if (distanceToPlayer < retreatDistance)
        {
            // S'éloigne du joueur
            direction = (transform.position - player.position).normalized;
        }

        rb.velocity = direction * speed;

        if (isPlayerInRange)
        {
            if (timeBtwShots <= 0)
            {
                // Tire un projectile
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void SetPlayerInRange(bool inRange)
    {
        isPlayerInRange = inRange;
    }
}
