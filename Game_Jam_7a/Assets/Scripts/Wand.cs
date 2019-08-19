using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    
    [SerializeField]
    private AudioClip _pickupSound = null;

   

    public void PlayPickupSound()
    {
        AudioSource.PlayClipAtPoint(_pickupSound, transform.position, 1.0f);
        Destroy(gameObject);
    }
   

}
