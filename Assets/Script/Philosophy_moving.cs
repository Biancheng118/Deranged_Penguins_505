using UnityEngine;
using Vuforia;

public class ARObjectMover : MonoBehaviour
{
    public GameObject targetModel; // The model to display and move
    public float moveSpeed = 0.1f; // Movement speed along the x-axis

    private bool isTracking = false; // Tracks whether the target is being detected

    void Start()
    {
        // Ensure the model starts as inactive
        if (targetModel != null)
        {
            targetModel.SetActive(false);
        }

        // Register the target detection event
        var imageTarget = GetComponent<ObserverBehaviour>();
        if (imageTarget != null)
        {
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void Update()
    {
        // Move the model along the x-axis continuously if tracking started
        if (isTracking && targetModel != null)
        {
            Vector3 position = targetModel.transform.position;
            position.x -= moveSpeed * Time.deltaTime; // Decrease the x position to move left
            targetModel.transform.position = position;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Ensure the target model is only activated once and never hidden again
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            if (!isTracking && targetModel != null)
            {
                isTracking = true; // Set tracking flag
                targetModel.SetActive(true); // Show the model
            }
        }
    }

    void OnDestroy()
    {
        // Unregister the event to avoid memory leaks
        var imageTarget = GetComponent<ObserverBehaviour>();
        if (imageTarget != null)
        {
            imageTarget.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
