using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCrystal : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
