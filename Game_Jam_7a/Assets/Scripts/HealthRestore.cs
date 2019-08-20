using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiManager = null;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiManager.GetComponent<UIManager>().RegainHealth(0.1f * Time.deltaTime);
            other.GetComponent<Player>().RestoreHealth(0.1f * Time.deltaTime);
        }
    }
}
