using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCollector : MonoBehaviour
{

    public delegate void OnCollectedCargo(int value);
    public static OnCollectedCargo collectedCargo;

    [SerializeField] GameManager.Colour colour;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>() != null)
        {
            Cargo cargo = other.GetComponent<Cargo>();
            if (cargo.colour == colour)
            {
                collectedCargo?.Invoke(cargo.value);
            }
            else
            {
                collectedCargo?.Invoke(-cargo.value);
            }

            cargo.gameObject.SetActive(false);
        }
    }

}
