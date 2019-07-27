using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheetAnimation : MonoBehaviour {

    [SerializeField]
    private bool _hasMoved = false;
    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();

    }


    public void ActivateSheet()
    {
        if (_hasMoved == false)
        {
            _anim.SetBool("moveSheet", true);

            _hasMoved = true;
        }
        else
        {
            _anim.SetBool("moveSheet", false);

            _hasMoved = false;
        }
    }
}
