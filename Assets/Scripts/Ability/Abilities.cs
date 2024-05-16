using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    [Header("Heal Ability")]
    public KeyCode healKey = KeyCode.Q;
    public int healAmount = 2; // Change to int to match PlayerHealth
    public float healCooldown = 10f;
    public Image healImage;
    bool isHealCooldown = false;

    // Reference to the player's health component
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        healImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        HealAbility();
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void HealAbility()
    {
        if (Input.GetKey(healKey) && isHealCooldown == false)
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
}
