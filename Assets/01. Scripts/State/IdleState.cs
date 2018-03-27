using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    override public void Start()
    {
        _character.SetAnimationTrigger("idle");
    }

    override public void Update()
    {
        if (_character.IsSetMovePosition())
        {
            _character.ChangeState(Character.eState.MOVE);
        }
    }
}