using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class philoChatBubbleSpawner : MonoBehaviour
{
    public GameObject chatBubblePrefab; // Prefab for the chat bubble
    public Transform bubbleSpawnPoint; // Position where the bubble spawns (e.g., above the model)
    public float bubbleDisplayDuration = 3f; // How long each bubble stays visible
    public float bubbleSpawnInterval = 3f; // Time interval between bubble spawns

    [TextArea]
    public string[] chatMessages = new string[10] // Array of chat messages
    {
     "Why do you follow me?",
"Is solitude a burden or a gift?",
"Not all paths are meant to be followed.",
"Freedom comes at a cost.",
"Have you ever questioned the flock?",
"To wander is to find yourself.",
"Loneliness is the price of thought.",
"Look beyond the obvious.",
"The horizon is my only companion.",
"Will you choose your own path?"
    };

    private void Start()
    {
        // Start spawning chat bubbles repeatedly
        StartCoroutine(SpawnChatBubble());
    }

    private IEnumerator SpawnChatBubble()
    {
        while (true)
        {
            // Spawn a bubble with random content
            SpawnRandomBubble();

            // Wait for the spawn interval before creating the next bubble
            yield return new WaitForSeconds(bubbleSpawnInterval);
        }
    }

    private void SpawnRandomBubble()
    {
        if (chatBubblePrefab == null || bubbleSpawnPoint == null)
        {
            Debug.LogWarning("Chat bubble prefab or spawn point is not assigned!");
            return;
        }

        // Instantiate the chat bubble prefab
        GameObject bubble = Instantiate(chatBubblePrefab, bubbleSpawnPoint.position, Quaternion.identity);

        // Set the text to a random message from the array
        Text bubbleText = bubble.GetComponentInChildren<Text>();
        if (bubbleText != null)
        {
            bubbleText.text = chatMessages[Random.Range(0, chatMessages.Length)];
        }

        // Make the bubble a child of this GameObject for better positioning
        bubble.transform.SetParent(transform);

        // Destroy the bubble after the specified duration
        Destroy(bubble, bubbleDisplayDuration);
    }
}

