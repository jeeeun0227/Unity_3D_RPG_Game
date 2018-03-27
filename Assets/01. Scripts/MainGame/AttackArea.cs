using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check " + other);
    }

    public void Enable()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }

    public void Disable()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
