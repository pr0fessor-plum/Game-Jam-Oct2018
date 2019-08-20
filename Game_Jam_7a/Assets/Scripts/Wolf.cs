using UnityEngine;
using UnityEngine.AI;


public class Wolf : MonoBehaviour
{

    private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;
    private Animator _anim;
    [SerializeField]
    private GameObject _uiManager;
    [SerializeField]
    private GameObject _voice;
    private bool _isPlaying;
   
   
  




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
