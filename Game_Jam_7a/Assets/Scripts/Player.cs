using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

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
    [SerializeField]
    private GameObject _uncle;
    [SerializeField]
    private GameObject _crossHair;
    private bool _plateHasMoved = false;
    private bool _sheetHasMoved = false;
    private bool _pillowHasMoved = false;
    private bool _plantHasMoved = false;
    public bool _inDialogue = false;
   

    public int pageCount = 0;
  

	void Start ()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	void Update ()
    {
        //Movement();
      

        if (Input.GetKey(KeyCode.Alpha1))
        {
            
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            _uncle.GetComponent<Uncle>().Idle();
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            _uncle.GetComponent<Uncle>().Drink();
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            _uncle.GetComponent<Uncle>().Lean();
        }

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
            if (_isWandEquipped == false && _inDialogue == false)
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
                            _plateHasMoved = true;
                            return;
                        case ("Pillow"):
                            Debug.Log("Hit Pillow" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<PillowAnimation>().ActivatePillow();
                            _pillowHasMoved = true;
                            return;
                        case ("Plant"):
                            Debug.Log("Hit Plant" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<PlantAnimation>().MovePlant();
                            _plantHasMoved = true;
                            return;
                        case ("Page1"):
                            Debug.Log("Hit Page1" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<Page1>().PickUp();
                            return;
                        case ("Page2"):
                            if (_pillowHasMoved == true)
                            {
                                Debug.Log("Hit Page2" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page2>().PickUp();
                                return;
                            }
                            else return;
                            
                        case ("Page3"):
                            if (_plantHasMoved == true)
                            {
                                Debug.Log("Hit Page3" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page3>().PickUp();
                                return;
                            }
                            else return;
                            
                        case ("Page4"):
                            if (_plateHasMoved == true)
                            {
                                Debug.Log("Hit Page4" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page4>().PickUp();
                                return;
                            }
                            else return;
                            
                        case ("Page5"):
                            if (_sheetHasMoved == true)
                            {
                                Debug.Log("Hit Page5" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page5>().PickUp();
                                return;
                            }
                            else return;
                            
                        case ("Sheet"):
                            Debug.Log("Hit Sheet" + Time.time);
                            hitInfo.transform.gameObject.GetComponent<MusicSheetAnimation>().ActivateSheet();
                            _sheetHasMoved = true;
                            return;

                        case ("Uncle"):
                            Debug.Log("Hit Uncle" + Time.time);
                            _uncle.GetComponent<Uncle>().WakeUp();
                            _inDialogue = true;
                            _controller.enabled = false;
                            GetComponent<FirstPersonController>().enabled = false;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            _crossHair.SetActive(false);
                            _uncle.GetComponent<DialogueTrigger>().TriggerDialogue();
                            return;
                    }
                }
            }
            else if (_isWandEquipped == true && _inDialogue == false)
            {
                Debug.Log("Fire SHot" + Time.time);
                _fireShot.Play();
            }
        }
    }

    public void ReturnToGame()
    {
        _inDialogue = false;
        _controller.enabled = true;
        GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _crossHair.SetActive(true);
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
