using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boostSpeed = 10f;
    public float boostDuration = 1.0f; 
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
