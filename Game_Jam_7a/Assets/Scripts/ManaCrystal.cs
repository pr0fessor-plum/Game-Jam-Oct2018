using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCrystal : MonoBehaviour
{
   
    [SerializeField]
    private GameObject _uiManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiManager.GetComponent<UIManager>().RegainMana(1.0f);
            other.GetComponent<Player>().RegainMana(1.0f); 
        }
    }

    
}
