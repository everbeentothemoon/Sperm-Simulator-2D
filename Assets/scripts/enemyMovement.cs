using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveDistance = 5f; // The distance to move left and right
    public float moveSpeed = 2f; // The speed of movement
    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingRight = true;

    void Start()
    {
        // Store the initial position of the GameObject
        startPos = transform.position;

        // Calculate the end position by moving to the right
        endPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Calculate the new position based on the movement direction
        Vector3 targetPos = movingRight ? endPos : startPos;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Check if the GameObject has reached the target position
        if (transform.position == targetPos)
        {
            // Toggle the movement direction
            movingRight = !movingRight;
        }
    }
}
