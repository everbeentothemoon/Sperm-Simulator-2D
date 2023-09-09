using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float boostSpeed = 12f;
    private float boostDuration = 0.5f;
    private float speedDecayRate = 2f; // Rate at which speed decreases when not boosting
    private float currentSpeed = 8f; // Current speed
    private float boostTime = 0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && !IsBoosting())
        {
            AddSpeed(2f);
        }

        // Gradually decrease speed when not boosting
        if (!IsBoosting() && currentSpeed > moveSpeed)
        {
            currentSpeed -= speedDecayRate * Time.deltaTime;

            // Ensure speed doesn't go below moveSpeed
            currentSpeed = Mathf.Max(currentSpeed, moveSpeed);
        }

        // Apply movement with the current speed
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }

    // Check if currently boosting
    private bool IsBoosting()
    {
        return Time.time - boostTime < boostDuration;
    }

    // Add speed
    private void AddSpeed(float amount)
    {
        currentSpeed += amount;
        boostTime = Time.time;
    }
}
