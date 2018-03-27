using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamra : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (null != _lookTarget)
        {
            Vector3 startLookPosition = _lookTarget.GetPosition() + _offset;
            Vector3 relativePos = Quaternion.Euler(_verticalAngle, _horizontalAngle, 0.0f) * new Vector3(0.0f, 0.0f, -_distance);
            //Vector3 relativePos = _lookTarget.GetRotation() * new Vector3(0.0f, 0.0f, -_distance);
            transform.position = startLookPosition + relativePos;

            Vector3 endLookPosition = _lookTarget.GetPosition() + _offset;
            transform.LookAt(endLookPosition);
        }
    }


    // Camera

    public Player _lookTarget = null;
    Vector3 _offset = new Vector3(0.0f, 5.5f, -8.0f);
    float _verticalAngle = 10.0f;
    float _horizontalAngle = 0.0f;
    float _distance = 5.0f;
}
