
using UnityEngine;

public class CabinetTopRightAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    public void ActivateTopRight()
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
