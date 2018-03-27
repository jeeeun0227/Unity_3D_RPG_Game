using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Character _character;

    public void Init(Character character)
    {
        _character = character;
    }

    virtual public void Start()
    {
    }

    virtual public void Stop()
    {
        _character.SetMovePosition(false);
    }

    virtual public void Update()
    {
    }
}
