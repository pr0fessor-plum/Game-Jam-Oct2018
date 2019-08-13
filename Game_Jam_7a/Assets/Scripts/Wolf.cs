using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public Transform _player;

    static Animator anim;
    [SerializeField]
    private GameObject _uiManager;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _wolfHowl;
    [SerializeField]
    private AudioClip _growl;
    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
       if (Vector3.Distance(_player.position, transform.position) < 25)
        {
            
            Vector3 direction = _player.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.5f);

            anim.SetBool("idle", false);
            if (direction.magnitude > 15)
            {
                speed = 0.1f;
                transform.Translate(0, 0, speed);
                anim.SetBool("run", false);
                anim.SetBool("creep", true);
                
            } else
            {

                speed = 0.6f;
                transform.Translate(0, 0, speed);

                anim.SetBool("creep", false);
                anim.SetBool("run", true);

                
            }
        } else
        {
            anim.SetBool("idle", true);
            anim.SetBool("creep", false);
            anim.SetBool("run", false);
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audioSource.PlayOneShot(_wolfHowl, 1.0f);
            //other.gameObject.GetComponent<Player>().EnterDialog();
            //GetComponent<DialogueTrigger>().TriggerDialogue();



        }
    }
}
