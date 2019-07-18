using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimation : MonoBehaviour {

    private Animator _anim;


	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}
	
    public void MovePlant()
    {
        Debug.Log("Method Called" + Time.time);
        _anim.SetBool("MovePlant", true);
        //scroll set active
    }
}
