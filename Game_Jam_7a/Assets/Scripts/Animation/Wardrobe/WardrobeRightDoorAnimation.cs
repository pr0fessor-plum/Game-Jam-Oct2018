using UnityEngine;

public class WardrobeRightDoorAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private Animator _anim;
    public GameObject drawer;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    public void ActivateWardrobe()
    {
        if (drawer.GetComponent<DrawerAnimation>()._isOpen == true)
        {
            return;
        } else
        
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
