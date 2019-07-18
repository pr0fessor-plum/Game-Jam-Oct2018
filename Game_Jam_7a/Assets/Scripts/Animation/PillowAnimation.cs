using UnityEngine;

public class PillowAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _hasMoved = false;
    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();

    }



    public void ActivatePillow()
    {
        if (_hasMoved == false)
        {
            _anim.SetBool("move", true);

            _hasMoved = true;
        }
        else
        {
            _anim.SetBool("move", false);

            _hasMoved = false;
        }
    }
}
