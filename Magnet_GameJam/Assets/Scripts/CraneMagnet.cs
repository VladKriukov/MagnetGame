using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMagnet : MonoBehaviour
{

    [SerializeField] float magnetRadius = 5;
    [SerializeField] float magnetForce = 10f;
    [SerializeField] bool isOn = false;

    Vector3 magnetPos;
    Collider[] colliders;

    void FixedUpdate()
    {
        isOn = InputManager.magnet;

        if (isOn)
        {
            Magnet();
        }
    }

    void Magnet ()
    {
        magnetPos = transform.position;
        colliders = Physics.OverlapSphere(magnetPos, magnetRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(-magnetForce, magnetPos, magnetRadius, 0);
        }
    }
}
