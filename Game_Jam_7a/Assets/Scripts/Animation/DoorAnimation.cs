using System.Collections;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private bool _isLocked;
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;
    [SerializeField]
    private AudioClip _open;
    [SerializeField]
    private AudioClip _close;
    [SerializeField]
    private AudioClip _locked;
    [SerializeField]
    private AudioSource _audioSource;


	void Start ()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
	}
	
	public void ActivateDoor()
    {
        if (_isLocked)
        {
            _audioSource.PlayOneShot(_locked, 1f);
            _player.GetComponent<Player>().EnterDialog();
            GetComponent<DialogueTrigger>().TriggerDialogue();
            return;
        }

        if (_isOpen == false)
        {
            _anim.SetBool("open", true);
            _audioSource.PlayOneShot(_open, 1.0f);
            _isOpen = true;
        } else
        {
            _anim.SetBool("open", false);
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
