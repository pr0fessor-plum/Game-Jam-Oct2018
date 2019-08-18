using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _scream;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Scream()
    {
        _audioSource.PlayOneShot(_scream, 1.0f);
    }

   
}
