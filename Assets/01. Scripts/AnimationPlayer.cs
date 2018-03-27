using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Aniamtion Play

    System.Action _beginCallback = null;
    System.Action _preMidCallback = null;
    System.Action _afterMidCallback = null;
    System.Action _endCallback = null;

    public void Play(string triggerName,
        System.Action beginCallback,
        System.Action preMidCallback,
        System.Action afterMidCallback,
        System.Action endCallback)
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);
        _beginCallback = beginCallback;
        _preMidCallback = preMidCallback;
        _afterMidCallback = afterMidCallback;
        _endCallback = endCallback;
    }


    // Animation Event

    public void OnBeginEvent()
    {
        if (null != _beginCallback)
            _beginCallback();
    }

    public void OnPreMidEvent()
    {
        if (null != _preMidCallback)
            _preMidCallback();
    }

    public void OnAfterMidEvent()
    {
        if (null != _afterMidCallback)
            _afterMidCallback();
    }

    public void OnEndEvent()
    {
        if (null != _endCallback)
            _endCallback();
    }
}
