using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{


    public GameObject avatar1, avatar2;


    int whichAvatarIsOn = 1;


    public float speedAvatar1 = 2f;
    public float speedAvatar2 = 15f;


    float currentSpeed;


    void Start()
    {

        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        currentSpeed = speedAvatar1;
    }


    public void SwitchAvatar()
    {

        switch (whichAvatarIsOn)
        {

            case 1:

                whichAvatarIsOn = 2;

                avatar1.gameObject.SetActive(false);
                avatar2.transform.position = avatar1.transform.position;
                avatar2.gameObject.SetActive(true);

                currentSpeed = speedAvatar2;
                break;


            case 2:

                whichAvatarIsOn = 1;

                avatar2.gameObject.SetActive(false);
                avatar1.transform.position = avatar2.transform.position;
                avatar1.gameObject.SetActive(true);

                currentSpeed = speedAvatar1;
                break;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchAvatar();
        }


        if (whichAvatarIsOn == 1)
        {
            MoveAvatar(avatar1);
        }
        else
        {
            MoveAvatar(avatar2);
        }
    }


    void MoveAvatar(GameObject avatar)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        avatar.transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
    }
}