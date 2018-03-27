using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargIdleState : IdleState
{
    override public void Update()
    {
        // 늑대는 일정 시간이 지나면 순찰 상태로 전환된다.
        if (_character.GetRefreshTime() <= _duration)
        {
            _character.Patrol();
        }
        _duration += Time.deltaTime;
    }

    float _duration = 0.0f;
}
