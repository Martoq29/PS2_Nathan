using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Movement playerMovement = collision.gameObject.GetComponent<Movement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);
            }
        }
    }
}
