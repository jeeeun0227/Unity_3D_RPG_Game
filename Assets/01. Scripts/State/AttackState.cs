using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    override public void Start()
    {
        _character.GetAnimationPlayer().Play("attack", null,
        () =>
        {
            // 충돌체를 켰다가
            _character.AttackStart();
        },
        () =>
        {
            // 충돌체를 끈다.
            _character.AttackEnd();
        },
        () =>
        {
            _character.ChangeState(Character.eState.IDLE);
        });
    }

    override public void Stop()
    {
    }

    override public void Update()
    {
    }
}
