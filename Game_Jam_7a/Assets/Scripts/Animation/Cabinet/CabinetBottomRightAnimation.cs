using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBottomRightAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _open = null;
    [SerializeField]
    private AudioClip _close = null;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    public void ActivateBottomRight()
    {
        if (_isOpen == false)
        {
            _anim.SetBool("open", true);
            _audioSource.PlayOneShot(_open, 1.0f);

            _isOpen = true;
        }
        else
        {
            _anim.SetBool("open", false);
            StartCoroutine(PlayCloseSound());

            _isOpen = false;
        }
    }
    IEnumerator PlayCloseSound()
    {
        yield return new WaitForSeconds(0.75f);
        _audioSource.PlayOneShot(_close, 1.0f);
    }
}
