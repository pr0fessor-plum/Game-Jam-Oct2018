using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiManager;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiManager.GetComponent<UIManager>().RegainHealth(1.0f);
            other.GetComponent<Player>().RestoreHealth(1.0f);
        }
    }
}
