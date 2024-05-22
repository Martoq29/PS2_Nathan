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

        
        player1.GetComponent<Abilities>().isPlayer2 = false;
        player2.GetComponent<Abilities>().isPlayer2 = true;
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

            
            player1.GetComponent<Abilities>().isPlayer2 = true;
            player2.GetComponent<Abilities>().isPlayer2 = false;
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

            
            player1.GetComponent<Abilities>().isPlayer2 = false;
            player2.GetComponent<Abilities>().isPlayer2 = true;
        }
    }
}
