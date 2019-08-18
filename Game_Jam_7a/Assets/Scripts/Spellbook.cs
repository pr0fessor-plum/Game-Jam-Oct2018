using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _pageSound;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_pageSound, 1.0f);
    }

}
