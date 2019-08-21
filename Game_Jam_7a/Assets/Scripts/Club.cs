using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player takes damage to health
            _player.GetComponent<Player>().DamageHealth(0.1f);
            //health meter reduces
            _uiManager.LoseHealth(0.1f);
            //play blood splat particle
            //play impact sound
            //play victim sound
            

                int a = Random.Range(1, _audioClips.Length);
            _audioSource.clip = _audioClips[a];
            _audioSource.PlayOneShot(_audioSource.clip, 1.0f);
            // move picked sound to index 0 so it's not picked next time
            _audioClips[a] = _audioClips[0];
            _audioClips[0] = _audioSource.clip;
        }
    }
}
