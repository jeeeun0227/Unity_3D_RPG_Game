using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    public void Init(Character character)
    {
        _character = character;
    }


    // Character Info

    Character _character;

    public Character GetCharacter()
    {
        return _character;
    }
}