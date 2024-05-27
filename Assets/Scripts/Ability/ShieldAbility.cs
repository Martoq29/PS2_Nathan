using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShieldAbility : MonoBehaviour
{
    [Header("Shield Ability")]
    public KeyCode shieldKey = KeyCode.E; // Key to activate the shield
    public float shieldDuration = 5f; // Duration the shield stays active
    public float shieldCooldown = 15f; // Cooldown time after the shield is used
    public Image shieldImage;
    private bool isShieldActive = false;
    private bool isShieldCooldown = false;

    private void Start()
    {
        shieldImage.fillAmount = 0;
    }

    private void Update()
    {
        HandleShieldAbility();
    }

    void HandleShieldAbility()
    {
        if (Input.GetKeyDown(shieldKey) && !isShieldCooldown)
        {
            StartCoroutine(ActivateShield());
        }

        if (isShieldCooldown)
        {
            shieldImage.fillAmount -= 1 / shieldCooldown * Time.deltaTime;

            if (shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 0;
                isShieldCooldown = false;
            }
        }
    }

    IEnumerator ActivateShield()
    {
        isShieldActive = true;
        isShieldCooldown = true;
        shieldImage.fillAmount = 1;
        // Activate shield effect (e.g., visual effect, increase defense, etc.)
        // ...

        yield return new WaitForSeconds(shieldDuration);

        isShieldActive = false;
        // Deactivate shield effect
        // ...

        yield return new WaitForSeconds(shieldCooldown - shieldDuration);
    }
}
