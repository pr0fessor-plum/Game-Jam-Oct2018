using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page2 : MonoBehaviour {

    [SerializeField]
    private AudioClip _pagePickup = null;


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
                uIManager.CollectedPage2();
            }
            Destroy(this.gameObject);
        }
    }


}
