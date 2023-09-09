using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public float maxSpeed = 10f;
    public float acceleration = 2f;

    private Vector3 currentVelocity;
    private bool reachedMaxSpeed = false;

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned!");
            return;
        }

        Vector3 newPosition = transform.position;
        newPosition.z = -0.60f;
        transform.position = newPosition;

        Vector3 direction = (target.position - transform.position).normalized;

        float desiredSpeed = Mathf.Clamp(currentVelocity.magnitude + acceleration * Time.deltaTime, 0f, maxSpeed);

        currentVelocity = direction * desiredSpeed;

        transform.Translate(currentVelocity * Time.deltaTime);

        if (!reachedMaxSpeed && currentVelocity.magnitude >= maxSpeed)
        {
            reachedMaxSpeed = true;
        }
    }
}
