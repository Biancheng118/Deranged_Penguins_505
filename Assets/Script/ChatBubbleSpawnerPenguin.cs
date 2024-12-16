using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI; // For LayoutRebuilder


public class ChatBubbleSpawnerPenguin : MonoBehaviour
{
    public GameObject chatBubblePrefab; // Prefab for the chat bubble
    public Transform bubbleSpawnPoint; // Position where the bubble spawns (e.g., above the model)
    public float bubbleDisplayDuration = 3f; // How long each bubble stays visible
    public float bubbleSpawnInterval = 3f; // Time interval between bubble spawns

    [TextArea]
    public string[] chatMessages = new string[10] // Array of chat messages
    {
       "The snow feels nice today, doesn't it?",
"Life is good when you’re surrounded by friends!",
"This spot is perfect! No worries, just fish.",
"Did you see that? I caught the biggest fish!",
"I love it here – warm shelter and full bellies.",
"No need to rush, there’s plenty for everyone!",
"Stay close, the flock keeps us safe and warm.",
"Fish, shelter, friends… What more could we need?",
"Isn’t this the best day ever?",
"Nothing to worry about – we’ve got each other!"

    };

    private void Start()
    {
        // Start spawning chat bubbles repeatedly
        StartCoroutine(SpawnChatBubble());
    }

    private System.Collections.IEnumerator SpawnChatBubble()
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
        bubble.transform.SetParent(bubbleSpawnPoint, false); // Parent to bubbleSpawnPoint


        // Find the TextMeshPro component inside the prefab
        TMP_Text bubbleText = bubble.GetComponentInChildren<TMP_Text>();
        if (bubbleText != null)
        {
            bubbleText.text = chatMessages[Random.Range(0, chatMessages.Length)];
        }

        // Adjust the background size to fit the text content
        RectTransform textboxRect = bubbleText.transform.parent.GetComponent<RectTransform>();
        if (textboxRect != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(textboxRect);
        }

        // Make the bubble a child of this GameObject for better positioning
        bubble.transform.SetParent(transform, false);

        // Destroy the bubble after the specified duration
        Destroy(bubble, bubbleDisplayDuration);
    }
}

