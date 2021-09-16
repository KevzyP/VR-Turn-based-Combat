using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateActions : MonoBehaviour
{
    public float defaultSpeed;
    public float delayTime;
    
    private float _currentTime = 0;
    private bool _menuMoved;
    private bool _joystickMoved = false;

    public Transform gameobjectTransform;

    public InputActionReference rotateReference;

    
    // Start is called before the first frame update
    void Start()
    {
        gameobjectTransform.GetComponent<Transform>();
        rotateReference.action.started += JoystickRotate;

    }

    // Update is called once per frame
    void Update()
    {
        float movementAmount = rotateReference.action.ReadValue<float>();
        InputRotate(movementAmount);
        Debug.Log("Axis value = " + movementAmount);
    }

    private void JoystickRotate(InputAction.CallbackContext context)
    {
        rotateReference.action.started += ctx => _joystickMoved = true;
        rotateReference.action.canceled += ctx => _joystickMoved = false;
    }

    public void InputRotate(float absoluteSpeed)
    {
        if (_joystickMoved == true)
        {
            if (absoluteSpeed > 0.1f)
            {
                gameobjectTransform.transform.Rotate(0f, absoluteSpeed + 0.2f, 0f, Space.Self);
            }
            if (absoluteSpeed < -0.1f)
            {
                gameobjectTransform.transform.Rotate(0f, absoluteSpeed - 0.2f, 0f, Space.Self);
            }

            _menuMoved = true;
            
            if (_currentTime != 0)
            {
                _currentTime = 0;
            }
        }


        else if (_menuMoved == false)
        {
            AutoRotate();
        }

        else if (_menuMoved == true)
        {
            Delay();
        }
    }

    private void Delay()
    {
        if (_currentTime < delayTime)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }
        if (_currentTime >= delayTime)
        {
            _currentTime = 0;
            _menuMoved = false;
        }
    }

    public void AutoRotate()
    {
        gameobjectTransform.transform.Rotate(0f, defaultSpeed, 0f, Space.Self);
    }
}
