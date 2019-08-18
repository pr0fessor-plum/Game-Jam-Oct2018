using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _squawk;



    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audioSource.PlayOneShot(_squawk, 1.0f);
        }
    }
}
