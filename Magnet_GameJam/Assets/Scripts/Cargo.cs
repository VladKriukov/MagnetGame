using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{

    [SerializeField] AudioClip[] crateHitSounds;
    public int value;
    public GameManager.Colour colour;

    AudioSource audioSource;
    Rigidbody rb;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = crateHitSounds[Random.Range(0, crateHitSounds.Length)];
        audioSource.Play();
    }

}
