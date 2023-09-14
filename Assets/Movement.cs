using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpPow;
    public float mouseSens;

    Vector2 mouseMovement;
    Vector3 movement;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        movement = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(movement.x * speed * Time.deltaTime, rb.velocity.y, movement.z * speed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position - transform.up, -transform.up, 0.2f))
        {
            rb.AddForce(transform.up * jumpPow, ForceMode.Impulse);
        }

        // Camera movement
        mouseMovement.x += Input.GetAxis("Mouse X") * mouseSens;
        mouseMovement.y -= Input.GetAxis("Mouse Y") * mouseSens;
        mouseMovement.y = Mathf.Clamp(mouseMovement.y, -90, 90);
        transform.rotation = Quaternion.Euler(0, mouseMovement.x, 0);
        transform.GetChild(0).localRotation = Quaternion.Euler(mouseMovement.y, 0, 0);
    }
}
