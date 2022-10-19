using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float speed = .01f;
    //void Update()
    //{
    //    float xDirection = Input.GetAxis("Horizontal");
    //    float zDirection = Input.GetAxis("Vertical");

    //    Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
    //    transform.position += moveDirection * speed; 
    //}


    public float speed;
    public float rotationSpeed;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();
        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

/*Reference:
 * https://www.youtube.com/watch?v=t6e2MvEG0Tc
 * https://www.youtube.com/watch?v=Z2KmfduirfU
 */
