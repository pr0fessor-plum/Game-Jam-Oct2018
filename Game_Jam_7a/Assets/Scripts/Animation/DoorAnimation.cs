using System.Collections;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;
    [SerializeField]
    private AudioClip _open;
    [SerializeField]
    private AudioClip _close;
    [SerializeField]
    private AudioSource _audioSource;


	void Start ()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
	}
	
	public void ActivateDoor()
    {
        if (_isOpen == false)
        {
            _anim.SetBool("open", true);
           //_anim.SetBool("close", false);
            _audioSource.PlayOneShot(_open, 1.0f);
            _isOpen = true;
        } else
        {
            _anim.SetBool("open", false);
            //_anim.SetBool("close", true);
            StartCoroutine(PlayCloseSound());
            _isOpen = false;
        }
    }

    IEnumerator PlayCloseSound()
    {
        yield return new WaitForSeconds(1.0f);
        _audioSource.PlayOneShot(_close, 1.0f);
    }

}
