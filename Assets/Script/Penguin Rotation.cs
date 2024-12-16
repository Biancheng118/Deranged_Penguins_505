using UnityEngine;

public class ContinuousYRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second
    public float minY = -180f; // Minimum Y rotation value
    public float maxY = -90f; // Maximum Y rotation value

    private float currentY; // Current rotation angle

    void Start()
    {
        // Initialize the Y rotation to the starting value (maxY)
        currentY = maxY;
    }

    void Update()
    {
        // Decrease the current Y rotation value over time
        currentY -= rotationSpeed * Time.deltaTime;

        // If the rotation goes below the minimum value, reset to maximum value
        if (currentY <= minY)
        {
            currentY = maxY;
        }

        // Apply the rotation to the model
        Vector3 rotation = transform.eulerAngles;
        rotation.y = currentY;
        transform.eulerAngles = rotation;
    }
}
