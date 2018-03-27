using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    override public void Init()
    {
        base.Init();
        _characterType = eCharacterType.PLAYER;

        // _attackRange = 2.0f;
    }

    override public void UpdateCharacter()
    {
        base.UpdateCharacter();
        UpdateInput();
    }

    override public void StopChase()
    {
        ChangeState(eState.IDLE);
    }

    override public bool IsSearchRange(float distance)
    {
        return false;
    }

    void UpdateInput()
    {
        if (InputManager.Instance.IsMouseDown())
        {
            Vector3 mousePosition = InputManager.Instance.GetCursorPosition();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;
            LayerMask layerMask = (1 << LayerMask.NameToLayer("Ground")) |
                                (1 << LayerMask.NameToLayer("Character"));
            if (Physics.Raycast(ray, out hitInfo, 100.0f, layerMask))
            {
                if (LayerMask.NameToLayer("Ground") == hitInfo.collider.gameObject.layer)
                {
                    _targetPosition = hitInfo.point;
                    _targetObject = null;
                    _isSetMovePosition = true;
                    // _stateList[_stateType].UpdateInput();
                }
                else if (LayerMask.NameToLayer("Character") == hitInfo.collider.gameObject.layer)
                {
                    HitArea hitArea = hitInfo.collider.gameObject.GetComponent<HitArea>();
                    Character character = hitArea.GetCharacter();
                    switch (character.GetCharacterType())
                    {
                        case eCharacterType.MONSTER:
                            // _targetPosition = hitInfo.collider.gameObject.transform.position;
                            _targetObject = hitInfo.collider.gameObject;
                            ChangeState(eState.CHASE);
                            Debug.Log("Monster");
                            break;
                    }
                }
            }
        }
        if (InputManager.Instance.IsAttackButtonDown())
        {
            ChangeState(eState.ATTACK);
        }
    }
}
