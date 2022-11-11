using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }
    
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool movingPressed = (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.001) || (Mathf.Abs(Input.GetAxis("Vertical")) > 0.001);

        if (!isRunning && movingPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && !movingPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
