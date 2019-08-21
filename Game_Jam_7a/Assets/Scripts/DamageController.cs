using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;


    private void Start()
    {
   
        _audioSource = GetComponent<AudioSource>();
    }


    public void EndAttack()
    {
        float distance = Vector3.Distance(_player.position, transform.position);
        if (distance < 2.5f)
        {
            _player.GetComponent<Player>().DamageHealth(0.2f);
            _uiManager.LoseHealth(0.2f);

            int a = Random.Range(1, _audioClips.Length);
            _audioSource.clip = _audioClips[a];
            _audioSource.PlayOneShot(_audioSource.clip, 1.0f);
            // move picked sound to index 0 so it's not picked next time
            _audioClips[a] = _audioClips[0];
            _audioClips[0] = _audioSource.clip;

        }
    }

   
    

}
