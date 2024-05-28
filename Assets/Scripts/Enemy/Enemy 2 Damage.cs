using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Damage : MonoBehaviour
{
    public int damage;
    private List<PlayerHealth> playerHealths = new List<PlayerHealth>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && !playerHealths.Contains(playerHealth))
        {
            playerHealths.Add(playerHealth);
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && playerHealths.Contains(playerHealth))
        {
            playerHealths.Remove(playerHealth);
        }
    }
}
