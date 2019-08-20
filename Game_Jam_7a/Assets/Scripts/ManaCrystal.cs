using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCrystal : MonoBehaviour
{
   
    [SerializeField]
    private GameObject _uiManager = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiManager.GetComponent<UIManager>().RegainMana(0.1f * Time.deltaTime);
            other.GetComponent<Player>().RegainMana(0.1f * Time.deltaTime); 
        }
    }

    
}
