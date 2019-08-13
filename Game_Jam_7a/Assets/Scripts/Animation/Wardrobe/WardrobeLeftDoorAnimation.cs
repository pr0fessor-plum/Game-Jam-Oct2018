using UnityEngine;
using System.Collections;

public class WardrobeLeftDoorAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;
    public GameObject drawer;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _openDoor;
    [SerializeField]
    private AudioClip _closeDoor;



    void Start ()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    public void ActivateWardrobe()
    {
      if (drawer.GetComponent<DrawerAnimation>()._isOpen == true)
        {
            return;
        } else

        if (_isOpen == false)
        {
            _anim.SetBool("open", true);
            _audioSource.PlayOneShot(_openDoor);
        
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
        _audioSource.PlayOneShot(_closeDoor, 1.0f);
    }
}
