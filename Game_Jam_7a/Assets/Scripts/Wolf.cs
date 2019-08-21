using UnityEngine;
using UnityEngine.AI;


public class Wolf : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _uiManager;
    [SerializeField] private GameObject _voice;

    private bool _isPlaying;
    private Animator _anim;
    private NavMeshAgent _agent;

    public float speed;
  
    private void Start()
    {
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
  
        
    }


    void Update()
    {


        if (Vector3.Distance(_player.transform.position, transform.position) < 30)
        {
            _anim.SetBool("idle", false);
            _agent.SetDestination(_player.transform.position);
            _anim.SetBool("run", true);

        }

        if (Vector3.Distance(_player.transform.position, transform.position) < 15 && !_isPlaying)
        {
            _isPlaying = true;
            _voice.GetComponent<Voice>().Scream();

        }




    }

   

}
