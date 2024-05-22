using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1; // R�f�rence au premier personnage
    public GameObject player2; // R�f�rence au deuxi�me personnage
    public CameraFollow cameraFollow; // R�f�rence au script de suivi de la cam�ra

    private GameObject activePlayer; // R�f�rence au personnage actuellement actif

    void Start()
    {
        // Initialiser le premier personnage comme actif
        activePlayer = player1;
        player1.SetActive(true);
        player2.SetActive(false);

        // Initialiser la cible de la cam�ra
        cameraFollow.target = player1.transform;
    }

    void Update()
    {
        // V�rifier si la touche "X" est press�e
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Sauvegarder la position de l'actif actuel
        Vector3 currentPosition = activePlayer.transform.position;

        // Changer l'�tat actif des personnages et mettre � jour leur position
        if (activePlayer == player1)
        {
            activePlayer = player2;
            player1.SetActive(false);
            player2.transform.position = currentPosition;
            player2.SetActive(true);

            // Mettre � jour la cible de la cam�ra
            cameraFollow.target = player2.transform;
        }
        else
        {
            activePlayer = player1;
            player2.SetActive(false);
            player1.transform.position = currentPosition;
            player1.SetActive(true);

            // Mettre � jour la cible de la cam�ra
            cameraFollow.target = player1.transform;
        }
    }
}
