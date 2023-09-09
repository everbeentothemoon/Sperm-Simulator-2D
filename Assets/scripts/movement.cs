using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float boostSpeed = 12f;
    private float boostDuration = 0.5f; 
    private bool isBoosting = false; 
    private float boostTime = 0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            isBoosting = true;
            boostTime = Time.time;
        }

        if (isBoosting && Time.time - boostTime >= boostDuration)
        {
            isBoosting = false;
        }

        float speed = isBoosting ? boostSpeed : moveSpeed;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
