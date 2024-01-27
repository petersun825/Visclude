using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpotMover : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float time;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        targetPosition = new Vector2(-5f, -5f); // Start moving towards (-2, -2)
    }

    void Update()
    {
        // Update time
        time += Time.deltaTime * speed;

        // Move back and forth between startPosition and targetPosition
        rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(2f, 2f), new Vector2(-2f, -2f), Mathf.PingPong(time, 1));

        // Check if we need to switch target
        if (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) < 0.01f)
        {
            // Swap start and target positions
            (startPosition, targetPosition) = (targetPosition, startPosition);
            time = 0; // Reset time
        }
    }
}
