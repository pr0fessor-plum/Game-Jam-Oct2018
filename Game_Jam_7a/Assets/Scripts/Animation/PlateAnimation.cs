using UnityEngine;

public class PlateAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _hasMoved = false;
    private Animator _anim;
  

    void Start()
    {
        _anim = GetComponent<Animator>();
    
    }


    public void ActivatePlate()
    {
        if (_hasMoved == false)
        {
            _anim.SetBool("movePlate", true);
      
            _hasMoved = true;
        }
        else
        {
            _anim.SetBool("movePlate", false);
          
            _hasMoved = false;
        }
    }
}
