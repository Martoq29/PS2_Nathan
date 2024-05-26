using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CameraFollow cameraFollow;

    public GameObject player1AbilitiesUI;
    public GameObject player2AbilitiesUI;

    private GameObject activePlayer;

    void Start()
    {
        activePlayer = player1;
        player1.SetActive(true);
        player2.SetActive(false);

        cameraFollow.target = player1.transform;

        player1AbilitiesUI.SetActive(true);
        player2AbilitiesUI.SetActive(false);

        SetPlayer2State(player1, false);
        SetPlayer2State(player2, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        Vector3 currentPosition = activePlayer.transform.position;

        if (activePlayer == player1)
        {
            activePlayer = player2;
            player1.SetActive(false);
            player2.transform.position = currentPosition;
            player2.SetActive(true);

            cameraFollow.target = player2.transform;

            player1AbilitiesUI.SetActive(false);
            player2AbilitiesUI.SetActive(true);

            SetPlayer2State(player1, true);
            SetPlayer2State(player2, false);
        }
        else
        {
            activePlayer = player1;
            player2.SetActive(false);
            player1.transform.position = currentPosition;
            player1.SetActive(true);

            cameraFollow.target = player1.transform;

            player1AbilitiesUI.SetActive(true);
            player2AbilitiesUI.SetActive(false);

            SetPlayer2State(player1, false);
            SetPlayer2State(player2, true);
        }
    }

    void SetPlayer2State(GameObject player, bool state)
    {
        Abilities abilities = player.GetComponent<Abilities>();
        if (abilities != null)
        {
            abilities.isPlayer2 = state;
        }
        else
        {
            Debug.LogWarning("Abilities component not found on player: " + player.name);
        }
    }
}
