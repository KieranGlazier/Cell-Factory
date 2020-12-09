using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float movementSpeed = 20;
    private float movementSpeedMultiplier = 2;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalBounds = 100;
    private float verticalBounds = 100;

    // Start is called before the first frame update
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        constrainCameraPosition();
        
    }

    void moveCamera()
    {
        // Move the camera
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime * movementSpeedMultiplier);
        }
        else
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime);
        }
    }

    void constrainCameraPosition()
    {
        // Clamp the camera to within the game bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -horizontalBounds, horizontalBounds);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -verticalBounds, verticalBounds);
        transform.position = clampedPosition;
    }
}
