using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingZone : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>(); // Assurez-vous que l'Enemy est le parent de la zone de tir
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(false);
        }
    }
}
