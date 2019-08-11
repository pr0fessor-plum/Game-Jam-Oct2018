using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] _fireballExplosions;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        int n = Random.Range(1, _fireballExplosions.Length);
        _audioSource.clip = _fireballExplosions[n];
        _audioSource.PlayOneShot(_audioSource.clip, 1.0f);
        
        StartCoroutine(DestroyObject());

    }

    void Update()
    {
        
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
