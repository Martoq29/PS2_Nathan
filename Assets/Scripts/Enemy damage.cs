using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    private bool canDamage = true;
    public float damageCooldown = 1f; // Temps de recharge entre chaque coup

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage && collision.gameObject.CompareTag("Player"))
        {
            Movement playerMovement = collision.gameObject.GetComponent<Movement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);
                canDamage = false; // D�sactive les d�g�ts pour un certain temps
                StartCoroutine(ResetDamageCooldown());
            }
        }
    }

    IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true; // R�active les d�g�ts apr�s le temps de recharge
    }
}
