using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;
    private Animator _anim;

    void Start()
    {
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _agent.SetDestination(_player.transform.position);
        

        if (Vector3.Distance(transform.position, _player.transform.position) < 2)
        {
            _agent.SetDestination(transform.position);
            Vector3 direction = _player.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.5f);
         
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _anim.SetBool("attack_short_001", true);

        }

    }

  
}
