using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTeeth : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _blood = null;
    [SerializeField]
    private GameObject _wolf;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _wolfSnarl = null;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().health = 0;
            _audioSource.PlayOneShot(_wolfSnarl, 1.0f);
            _blood.Play();
        }
    }
}
