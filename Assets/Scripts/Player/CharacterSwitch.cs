using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1; // Référence au premier personnage
    public GameObject player2; // Référence au deuxième personnage
    public CameraFollow cameraFollow; // Référence au script de suivi de la caméra

    private GameObject activePlayer; // Référence au personnage actuellement actif

    void Start()
    {
        // Initialiser le premier personnage comme actif
        activePlayer = player1;
        player1.SetActive(true);
        player2.SetActive(false);

        // Initialiser la cible de la caméra
        cameraFollow.target = player1.transform;
    }

    void Update()
    {
        // Vérifier si la touche "X" est pressée
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Sauvegarder la position de l'actif actuel
        Vector3 currentPosition = activePlayer.transform.position;

        // Changer l'état actif des personnages et mettre à jour leur position
        if (activePlayer == player1)
        {
            activePlayer = player2;
            player1.SetActive(false);
            player2.transform.position = currentPosition;
            player2.SetActive(true);

            // Mettre à jour la cible de la caméra
            cameraFollow.target = player2.transform;
        }
        else
        {
            activePlayer = player1;
            player2.SetActive(false);
            player1.transform.position = currentPosition;
            player1.SetActive(true);

            // Mettre à jour la cible de la caméra
            cameraFollow.target = player1.transform;
        }
    }
}
