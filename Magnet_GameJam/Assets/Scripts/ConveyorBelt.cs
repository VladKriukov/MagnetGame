using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    [SerializeField][Range(0, 10)] float conveyorSpeed = 1;
    [SerializeField] Vector3 direction;

    [SerializeField] List<Rigidbody> stuffOnConveyor = new List<Rigidbody>();
    //List<ContactPoint> contactPoints = new List<ContactPoint>();

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null) stuffOnConveyor.Add(other.GetComponent<Rigidbody>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null) stuffOnConveyor.Remove(other.GetComponent<Rigidbody>());
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Rigidbody>() != null) stuffOnConveyor.Add(collision.gameObject.GetComponent<Rigidbody>());
    }

    void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Rigidbody>() != null) stuffOnConveyor.Remove(collision.gameObject.GetComponent<Rigidbody>());
    }

    void FixedUpdate()
    {
        direction = this.transform.forward;
        foreach (Rigidbody item in stuffOnConveyor)
        {
            item.AddForce(this.transform.forward * conveyorSpeed, ForceMode.VelocityChange);
            //item.AddForceAtPosition
            //item.velocity = new Vector3();
        }
    }

}
