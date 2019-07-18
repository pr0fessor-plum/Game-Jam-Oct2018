using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 6.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private bool _isWandEquipped = false;
    [SerializeField]
    private ParticleSystem _fireShot;
    [SerializeField]
    private GameObject _wand;
  

	void Start ()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update ()
    {
        Movement();

    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isWandEquipped == false)
            {
                _isWandEquipped = true;
                _wand.SetActive(true);
            }
            else
            {
                _isWandEquipped = false;
                _wand.SetActive(false);
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (_isWandEquipped == false)
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 4.0f))
                {
                    switch (hitInfo.transform.tag)
                    {
                        case ("Door"):
                            Debug.Log("Hit Door" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<DoorAnimation>().ActivateDoor();
                            return;
                        case ("Drawer"):
                            Debug.Log("Hit Drawer" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<DrawerAnimation>().ActivateDrawer();
                            return;
                        case ("WardrobeLeftDoor"):
                            Debug.Log("Hit Wardrobe - Left Door" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<WardrobeLeftDoorAnimation>().ActivateWardrobe();
                            return;
                        case ("WardrobeRightDoor"):
                            Debug.Log("Hit Wardrobe - Right Door" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<WardrobeRightDoorAnimation>().ActivateWardrobe();
                            return;
                        case ("CabinetTopLeft"):
                            hitInfo.transform.gameObject.GetComponent<CabinetTopLeftAnimation>().ActivateTopLeft();
                            return;
                        case ("CabinetTopRight"):
                            hitInfo.transform.gameObject.GetComponent<CabinetTopRightAnimation>().ActivateTopRight();
                            return;
                        case ("CabinetBottomLeft"):
                            hitInfo.transform.gameObject.GetComponent<CabinetBottomLeftAnimation>().ActivateBottomLeft();
                            return;
                        case ("CabinetBottomRight"):
                            hitInfo.transform.gameObject.GetComponent<CabinetBottomRightAnimation>().ActivateBottomRight();
                            return;
                        case ("Plate"):
                            Debug.Log("Hit Plate" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<PlateAnimation>().ActivatePlate();
                            return;
                        case ("Pillow"):
                            Debug.Log("Hit Pillow" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<PillowAnimation>().ActivatePillow();
                            return;
                        case ("Plant"):
                            Debug.Log("Hit Plant" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<PlantAnimation>().MovePlant();
                            return;
                    }
                }
            }
            else
            {
                Debug.Log("Fire SHot" + Time.time);
                _fireShot.Play();
            }
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}
