using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 1.0f;

  public void DamageHealth()
    {
        _health -= 0.2f;
        //call reduce health UI method
        Animator anim = GetComponent<Animator>();
     
        anim.SetBool("isHit", true);
    }
}
