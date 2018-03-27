using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Singleton

    static InputManager _instance;
    static public InputManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new InputManager();
                _instance.Init();
            }

            return _instance;
        }
    }

    void Init()
    {
    }


    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (eButtonState.UP == _buttonState)
                ButtonDown();
            else if (eButtonState.DOWN == _buttonState)
                ButtonHold();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ButtonUp();
        }

        if (Input.GetMouseButton(1))
        {
            if (eButtonState.UP == _attackButtonState)
                AttackButtonDown();
            else if (eButtonState.DOWN == _attackButtonState)
                AttackButtonHold();
        }
        if (Input.GetMouseButtonUp(1))
        {
            AttackButtonUp();
        }
    }

    // Mouse Input

    enum eButtonState
    {
        DOWN,
        HOLD,
        UP,
    }
    eButtonState _buttonState = eButtonState.UP;

    void ButtonDown()
    {
        _buttonState = eButtonState.DOWN;
    }

    void ButtonHold()
    {
        _buttonState = eButtonState.HOLD;
    }

    void ButtonUp()
    {
        _buttonState = eButtonState.UP;
    }

    public bool IsMouseDown()
    {
        return (eButtonState.DOWN == _buttonState);
    }

    public bool IsMouseHold()
    {
        return (eButtonState.HOLD == _buttonState);
    }

    public Vector3 GetCursorPosition()
    {
        return Input.mousePosition;
    }


    // Attack

    eButtonState _attackButtonState = eButtonState.UP;

    public bool IsAttackButtonDown()
    {
        return (eButtonState.DOWN == _attackButtonState);
    }

    void AttackButtonDown()
    {
        _attackButtonState = eButtonState.DOWN;
    }

    void AttackButtonHold()
    {
        _attackButtonState = eButtonState.HOLD;
    }

    void AttackButtonUp()
    {
        _attackButtonState = eButtonState.UP;
    }
}
