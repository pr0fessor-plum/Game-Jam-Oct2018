using UnityEngine;

public class Voice : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _scream;
    [SerializeField] private AudioClip[] _groans;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Scream()
    {
        _audioSource.PlayOneShot(_scream, 1.0f);
    }

    public void Groan()
    {
        int n = Random.Range(1, _groans.Length);
        _audioSource.clip = _groans[n];
        _audioSource.PlayOneShot(_audioSource.clip, 1.0f);
        // move picked sound to index 0 so it's not picked next time
        _groans[n] = _groans[0];
        _groans[0] = _audioSource.clip;
    }
   
}
