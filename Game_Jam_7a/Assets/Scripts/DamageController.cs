using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private ParticleSystem _blood;
    [SerializeField] private Voice _voice;


    private void Start()
    {
        _player = GameObject.Find("Player");
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        _voice = GameObject.Find("Player").GetComponentInChildren<Voice>();
    }


    public void EndAttack()
    {
        float distance = Vector3.Distance(_player.transform.position, transform.position);
        if (distance < 2.5f)
        {
            _audioSource.PlayOneShot(_hit, 1.0f);
            _blood.Play();


            if (_player.GetComponent<Player>()._isAlive == true)
            {
                _player.GetComponent<Player>().DamageHealth(0.2f);
                _uiManager.LoseHealth(0.2f);
                _voice.Groan();
                

            }

    

        }
    }

   
    

}
