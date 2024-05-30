using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial position and rotation of the camera
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Lock the camera's position and rotation to its initial values
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
