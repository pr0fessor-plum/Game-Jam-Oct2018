using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page1 : MonoBehaviour {

    [SerializeField]
    private AudioClip _pagePickup;


    public void PickUp()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player.pageCount++;
            AudioSource.PlayClipAtPoint(_pagePickup, transform.position, 1f);
            UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            if (uIManager != null)
            {
                uIManager.CollectedPage1();
            }
            Destroy(this.gameObject);
        }
    }
}
