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
    private GameObject activePlayer;
    private bool isSwitching = false;
    private bool canSwitchBackToPlayer2 = true;
    private bool canPressSwitchKey = true;
    private float switchCooldownTimer = 0f;
    private float switchKeyCooldownTimer = 0f;

    void Start()
    {
        activePlayer = player1;
        player1.SetActive(true);
        player2.SetActive(false);
        cameraFollow.target = player1.transform;

        player1AbilitiesUI.SetActive(true);
        player2AbilitiesUI.SetActive(false);
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
    }
}
