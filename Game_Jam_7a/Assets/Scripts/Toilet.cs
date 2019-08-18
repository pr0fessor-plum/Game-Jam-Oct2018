using UnityEngine;

public class Toilet : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _flush;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Flush()
    {
        _audioSource.PlayOneShot(_flush, 1.0f);
    }
}
