using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_player.transform.position);
    }

    void Update()
    {
        
    }
}
