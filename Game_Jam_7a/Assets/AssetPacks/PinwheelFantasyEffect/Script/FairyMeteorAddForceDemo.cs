using UnityEngine;
using System.Collections;

public class FairyMeteorAddForceDemo : MonoBehaviour {

    public int strength;
    public Vector3 direction;
    [SerializeField]
    private float _speed = 50;

    protected Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        rb.velocity = transform.forward * _speed;
    }
}
