using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHowl : MonoBehaviour
{
    [SerializeField]
    private AudioClip _wolfHowl = null;
    [SerializeField]
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audioSource.PlayOneShot(_wolfHowl, 1.0f);
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
