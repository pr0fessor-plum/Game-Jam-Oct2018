using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeRightDrawerAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    public void ActivateWardrobe()
    {
        if (_isOpen == false)
        {
            _anim.SetBool("open", true);

            _isOpen = true;
        }
        else
        {
            _anim.SetBool("open", false);

            _isOpen = false;
        }
    }
}
