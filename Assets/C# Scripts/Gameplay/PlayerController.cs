using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

/*References:
 * https://www.youtube.com/watch?v=t6e2MvEG0Tc
 * https://www.youtube.com/watch?v=Z2KmfduirfU
 */

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    // footsteps variables
    public float stepFrequency;
    public AudioSource footstepsSource;
    public AudioClip leftStep;
    public AudioClip rightStep;
    private uint _stepValue = 0;
    private bool _isLeftStep = true;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate() // this should be edited to use the input controller
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!isFloatZeroed(horizontalInput) || !isFloatZeroed(verticalInput)) // if there is direction input
        {
            IncrementFootstepSound();
            Debug.Log(_stepValue);
        }
        
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

    bool isFloatZeroed(float testFloat) // TODO - this might be better to put into some type of Math Utils class
    {
        return ((testFloat < 0.05) && (testFloat > -0.05));
    }

    void IncrementFootstepSound()
    {
        _stepValue++;
        uint stepLimit = (uint)(1.0f / stepFrequency);
        if (_stepValue > stepLimit)
        {
            _stepValue = 0;
            if (_isLeftStep)
                footstepsSource.clip = leftStep;
            else
                footstepsSource.clip = rightStep;
            _isLeftStep = !_isLeftStep;
            footstepsSource.Play(0);
        }
    }
}
