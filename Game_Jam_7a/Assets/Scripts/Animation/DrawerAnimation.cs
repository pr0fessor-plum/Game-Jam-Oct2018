using UnityEngine;

public class DrawerAnimation : MonoBehaviour
{
    private bool _isOpen = false;
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _open;
    [SerializeField]
    private AudioClip _close;


	void Start ()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
	}

    public void ActivateDrawer()
    {
        Debug.Log("Method called" + Time.time);

        if (_isOpen == false)
        {
            _anim.SetBool("open", true);
            _audioSource.PlayOneShot(_open, 1.0f);
            _isOpen = true;
        }
        else
        {
            _anim.SetBool("open", false);
            _audioSource.PlayOneShot(_close, 1.0f);
            _isOpen = false;
        }
    }
}
