using UnityEngine;

public class ContinuousXRotation : MonoBehaviour
{
    public float rotationSpeed = 3f; // Speed of rotation in degrees per second
    public float minX = -180f; // Minimum X rotation value
    public float maxX = -90f; // Maximum X rotation value

    private float currentX; // Current rotation angle

    void Start()
    {
        // Initialize the X rotation to the starting value (maxX)
        currentX = maxX;
    }

    void Update()
    {
        // Decrease the current X rotation value over time
        currentX -= rotationSpeed * Time.deltaTime;

        // If the rotation goes below the minimum value, reset to maximum value
        if (currentX <= minX)
        {
            currentX = maxX;
        }

        // Apply the rotation to the model
        Vector3 rotation = transform.eulerAngles;
        rotation.x = currentX; // Modify X rotation
        transform.eulerAngles = rotation;
    }
}
