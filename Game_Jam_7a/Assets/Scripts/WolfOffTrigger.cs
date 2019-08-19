using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfOffTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _wolf = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(_wolf);
        }
    }
}
