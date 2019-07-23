using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page5 : MonoBehaviour
{

    [SerializeField]
    private AudioClip _pagePickup;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.pageCount++;
                    AudioSource.PlayClipAtPoint(_pagePickup, transform.position, 1f);
                    UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (uIManager != null)
                    {
                        uIManager.CollectedPage5();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
