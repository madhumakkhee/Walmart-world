using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get the camera's forward direction
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // ignore vertical component
        cameraForward = cameraForward.normalized;

        // Calculate movement direction based on camera direction and input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = cameraForward * movement.z + Camera.main.transform.right * movement.x;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Rotate with mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime);
    }
}