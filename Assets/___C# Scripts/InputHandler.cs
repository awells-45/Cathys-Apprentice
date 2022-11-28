using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// References: https://gamedevbeginner.com/events-and-delegates-in-unity/
// Note: Put this script onto EventSystem in a scene where you
// want to get input, and subscribe/unsubscribe to the event

public class InputHandler : MonoBehaviour
{
    public delegate void OnInput();
    public static OnInput OnLeftClick;
    public static OnInput OnRightClick;
    public static OnInput OnPPress;
    public static OnInput OnBPress;
    public static OnInput OnMPress;
    public static OnInput OnHPress;
    public static OnInput OnUpPress;
    public static OnInput OnDownPress;
    public static OnInput OnLeftPress;
    public static OnInput OnRightPress;
    public static OnInput OnEscPress;
    public static OnInput AnyKeyPress;

    void Update()
    {
        if (Input.anyKey)
        {
            AnyKeyPress?.Invoke();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            OnUpPress?.Invoke();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            OnDownPress?.Invoke();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            OnLeftPress?.Invoke();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            OnRightPress?.Invoke();
        }
        
        if (Input.GetKey(KeyCode.P))
        {
            OnPPress?.Invoke();
        }
        
        if (Input.GetKey(KeyCode.B))
        {
            OnBPress?.Invoke();
        }
        
        if (Input.GetKey(KeyCode.M))
        {
            OnMPress?.Invoke();
        }
        
        if (Input.GetKey(KeyCode.H))
        {
            OnHPress?.Invoke();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            OnEscPress?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) // left-click
        {
            OnLeftClick?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1)) // right-click
        {
            OnRightClick?.Invoke();
        }
    }
}
