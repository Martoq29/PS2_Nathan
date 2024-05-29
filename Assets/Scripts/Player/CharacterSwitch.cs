using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CameraFollow cameraFollow;

    public GameObject player1AbilitiesUI;
    public GameObject player2AbilitiesUI;
    public float switchDuration = 15f;
    public float switchCooldown = 5f; // Cooldown before switching back to Player 2
    public float switchKeyCooldown = 5f; // Cooldown before pressing X again

    public Image switchCooldownImage; // Image representing the cooldown for character switch

    private GameObject activePlayer;
    private bool isSwitching = false;
    private bool canSwitchBackToPlayer2 = true;
    private bool canPressSwitchKey = true;
    private float switchCooldownTimer = 5f;
    private float switchKeyCooldownTimer = 5f;
    private PlayerHealth currentHealthScript;

    // Reference to the enemy behavior script
    public Enemy_Behaviour enemyBehaviour;

    void Start()
    {
        activePlayer = player1;
        player1.SetActive(true);
        player2.SetActive(false);
        cameraFollow.target = player1.transform;

        player1AbilitiesUI.SetActive(true);
        player2AbilitiesUI.SetActive(false);

        currentHealthScript = player1.GetComponent<PlayerHealth>();

        // Activate the cooldown image at the start for player 2 if needed
        if (activePlayer == player2)
        {
            UpdateSwitchCooldownImage();
        }
    }

    void Update()
    {
        if (canPressSwitchKey && Input.GetKeyDown(KeyCode.X) && !isSwitching)
        {
            StartCoroutine(SwitchCharacterTemporarily());
        }

        if (!canSwitchBackToPlayer2)
        {
            switchCooldownTimer -= Time.deltaTime;
            UpdateSwitchCooldownImage(); // Update switch cooldown image
            if (switchCooldownTimer <= 0)
            {
                canSwitchBackToPlayer2 = true;
            }
        }

        if (!canPressSwitchKey)
        {
            switchKeyCooldownTimer -= Time.deltaTime;
            if (switchKeyCooldownTimer <= 0)
            {
                canPressSwitchKey = true;
            }
        }
    }

    IEnumerator SwitchCharacterTemporarily()
    {
        if (activePlayer == player1)
        {
            SwitchCharacter(player2);
            yield return new WaitForSeconds(switchDuration);
            SwitchCharacter(player1);
            canSwitchBackToPlayer2 = false;
            switchCooldownTimer = switchCooldown;
            canPressSwitchKey = false;
            switchKeyCooldownTimer = switchKeyCooldown;
        }
        else if (canSwitchBackToPlayer2)
        {
            // Prevent switching back to player1 until the timer ends
            yield break;
        }
    }

    void SwitchCharacter(GameObject newActivePlayer)
    {
        if (newActivePlayer == null || activePlayer == null)
        {
            Debug.LogWarning("Attempted to switch to a null player.");
            return;
        }

        Vector3 currentPosition = activePlayer.transform.position;

        activePlayer.SetActive(false);
        newActivePlayer.transform.position = currentPosition;
        newActivePlayer.SetActive(true);

        cameraFollow.target = newActivePlayer.transform;

        if (newActivePlayer == player1)
        {
            player1AbilitiesUI.SetActive(true);
            player2AbilitiesUI.SetActive(false);
        }
        else
        {
            player1AbilitiesUI.SetActive(false);
            player2AbilitiesUI.SetActive(true);
        }

        activePlayer = newActivePlayer;
        currentHealthScript = activePlayer.GetComponent<PlayerHealth>();

        // Update the enemy's target to the new active player
        if (enemyBehaviour != null)
        {
            enemyBehaviour.target = activePlayer.transform;
            enemyBehaviour.Flip(); // Ensure the enemy faces the new target
        }
    }

    void UpdateSwitchCooldownImage()
    {
        if (switchCooldownTimer > 0)
        {
            switchCooldownImage.fillAmount = switchCooldownTimer / switchCooldown;
        }
        else
        {
            switchCooldownImage.fillAmount = 0f;
        }
    }

    public void DamageActivePlayer(int damage)
    {
        if (currentHealthScript != null)
        {
            currentHealthScript.TakeDamage(damage);
        }
    }
}
