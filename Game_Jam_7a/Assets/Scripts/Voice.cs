﻿using UnityEngine;

public class Voice : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _scream = null;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Scream()
    {
        _audioSource.PlayOneShot(_scream, 1.0f);
    }

   
}
