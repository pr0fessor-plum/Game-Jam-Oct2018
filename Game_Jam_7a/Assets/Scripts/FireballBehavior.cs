using UnityEngine;
using System.Collections;

public class FireballBehavior : MonoBehaviour
{

    public int strength;
    public Vector3 direction;
    [SerializeField]
    private float _speed = 10;
    [SerializeField]
    private GameObject _explosion = null;
    [SerializeField]
    private GameObject _wolf;
    [SerializeField] private Animator _anim;

    protected Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        StartCoroutine(ShootFireball());
        _wolf = GameObject.Find("Wolf");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wand" || other.tag == "Player" || other.tag == "Fireball" || other.tag == "Trigger")
        {
            return;
        }

        else if (other.tag == "Enemy")
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            other.GetComponent<Enemy>().DamageHealth();
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("Collision with " + other.name + " @ " + Time.time);
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

    IEnumerator ShootFireball()
    {
        yield return new WaitForSeconds(0.25f);
        rb.velocity = transform.forward * _speed;

    }
    
}
