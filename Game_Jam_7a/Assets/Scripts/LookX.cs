using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    float _sensitivity = 3.0f;


	void Update ()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * _sensitivity;
        transform.localEulerAngles = newRotation;
	}
}
