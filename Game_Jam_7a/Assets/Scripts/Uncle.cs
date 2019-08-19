using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncle : MonoBehaviour {

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _furnitureBump = null;
    [SerializeField]
    private AudioClip _barBump = null;
    private Animator _anim;


	void Start ()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
	}

    public void WakeUp()
    {
        StopAllCoroutines();
        _anim.SetBool("WakeUp", true);
        _audioSource.PlayOneShot(_furnitureBump);
        _audioSource.PlayOneShot(_barBump);
        StartCoroutine(WakeUpOff());

    }

    IEnumerator WakeUpOff()
    {
        yield return new WaitForSeconds(3);
        _anim.SetBool("WakeUp", false);
    }

    public void Idle()
    {
        StopAllCoroutines();
        _anim.SetBool("Idle", true);
        StartCoroutine(IdleOff());

    }

    IEnumerator IdleOff()
    {
        yield return new WaitForSeconds(3);
        _anim.SetBool("Idle", false);
    }

    public void Drink()
    {
        StopAllCoroutines();
        _anim.SetBool("Drink", true);
        StartCoroutine(DrinkOff());
    }

    IEnumerator DrinkOff()
    {
        yield return new WaitForSeconds(3);
        _anim.SetBool("Drink", false);
    }

    public void Lean()
    {
        StopAllCoroutines();
        _anim.SetBool("Lean", true);
        StartCoroutine(LeanOff());
    }

    IEnumerator LeanOff()
    {
        yield return new WaitForSeconds(3);
        _anim.SetBool("Lean", false);
    }
}
