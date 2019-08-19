using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page1 : MonoBehaviour {

    [SerializeField]
    private AudioClip _pagePickup = null;
    [SerializeField]
    private GameObject _player = null;
    [SerializeField]
    private GameObject _uiManager = null;

 

    public void PickUp()
    {
    _player.GetComponent<Player>().pageCount++;
    AudioSource.PlayClipAtPoint(_pagePickup, transform.position, 0.25f);
    _uiManager.GetComponent<UIManager>().CollectedPage1();
    Destroy(this.gameObject);
        
    }
}
