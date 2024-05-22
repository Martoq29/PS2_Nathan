using UnityEngine;
using UnityEngine.UI;

public class Abilities2 : MonoBehaviour
{

    [Header("Knockback Ability")]
    public KeyCode knockbackKey = KeyCode.Mouse0;
    public float knockbackCooldown = 5f;
    public Image knockbackImage;
    private bool isKnockbackCooldown = false;


    void Start()
    {
        knockbackImage.fillAmount = 0;
    }

    void Update()
    {
        HandleKnockbackAbility();
    }

    void HandleKnockbackAbility()
    {
        if (Input.GetKeyDown(knockbackKey) && !isKnockbackCooldown)
        {
            isKnockbackCooldown = true;
            knockbackImage.fillAmount = 1;

        }

        if (isKnockbackCooldown)
        {
            knockbackImage.fillAmount -= 1 / knockbackCooldown * Time.deltaTime;

            if (knockbackImage.fillAmount <= 0)
            {
                knockbackImage.fillAmount = 0;
                isKnockbackCooldown = false;
            }
        }
    }
}
