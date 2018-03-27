using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.NameToLayer("CharacterCtrl") == other.gameObject.layer)
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (eCharacterType.PLAYER == character.GetCharacterType())
            {
                _targetObject = other.gameObject;
                ChangeState(eState.CHASE);
            }
        }
    }

    override public void Init()
    {
        base.Init();
        _characterType = eCharacterType.MONSTER;
    }

    protected override void InitState()
    {
        base.InitState();

        State IdleState = new WargIdleState();

        IdleState.Init(this);

        _stateList[eState.IDLE] = IdleState;
    }

    public List<WayPoint> _wayPointList;
    int _wayPointIndex = 0;

    override public void ArriveDestination()
    {
        // WayPoint에 도착하면 다음 WayPoint로 목적지 변경
        WayPoint wayPpoint = _wayPointList[_wayPointIndex];
        _wayPointIndex = (_wayPointIndex + 1) % _wayPointList.Count;

        _targetPosition = wayPpoint.GetPosition();
    }
}
