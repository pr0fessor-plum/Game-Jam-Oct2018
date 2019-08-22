using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    [SerializeField]    private GameObject _toilet = null;
    [SerializeField]    private GameObject _continueButton;
    [SerializeField]    private GameObject _wolf;
    [SerializeField]    private float _speed = 6.5f;
    [SerializeField]    private bool _isWandEquipped = false;
    [SerializeField]    private bool _hasWand;
    [SerializeField]    private GameObject _missile = null;
    [SerializeField]    private GameObject _wand = null;
    [SerializeField]    private GameObject _tip = null;
    [SerializeField]    private GameObject _uncle = null;
    [SerializeField]    private GameObject _crossHair = null;
    [SerializeField]    private AudioSource _audioSource;
    [SerializeField]    private AudioSource _audioSourceWand;
    [SerializeField] private AudioSource _audioSourceVoice;
    [SerializeField] private AudioSource _audioSourceLamp;
    [SerializeField] private AudioClip _evilLaugh;
    [SerializeField]    private AudioClip _fireballShoot = null;
    [SerializeField]    private AudioClip _wandDud = null;
    [SerializeField] private AudioClip _die = null;
    [SerializeField]    private GameObject _uiManager = null;
    [SerializeField]    private GameObject _page1 = null;
    [SerializeField]    private GameObject _page2 = null;
    [SerializeField]    private GameObject _page3 = null;
    [SerializeField]    private GameObject _page4 = null;
    [SerializeField]    private GameObject _page5 = null;
    [SerializeField]    private GameObject _allPages = null;
    [SerializeField]    private GameObject _firstAid = null;
    [SerializeField]    private GameObject _manaCrystal = null;
    [SerializeField] private SpawnManager _spawnManager;
    private int _uncleDialogCount = 1;
    private bool _plateHasMoved = false;
    private bool _sheetHasMoved = false;
    private bool _pillowHasMoved = false;
    private bool _plantHasMoved = false;
    private bool _spellBookFirstTime = true;
    private bool _firstWakeUncle = true;
    private CharacterController _controller;
    private float _gravity = 9.81f;

    public bool _isAlive = true;
    public bool _inDialogue = false;
    public float health = 1.0f;
    [SerializeField]    private float mana = 1.0f;
   

    public int pageCount = 0;
  

	void Start ()
    {
        _controller = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
        _audioSourceWand = _wand.GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
            //SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isWandEquipped == false && _hasWand == true)
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
                            if (pageCount == 5)
                            {
                                EnterDialog();
                                _allPages.GetComponent<DialogueTrigger>().TriggerDialogue();
                                _uncleDialogCount = 2;
                            }

                            return;
                        case ("Page2"):
                            if (_pillowHasMoved == true)
                            {
                                Debug.Log("Hit Page2" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page2>().PickUp();
                                if (pageCount == 5)
                                {
                                    EnterDialog();
                                    _allPages.GetComponent<DialogueTrigger>().TriggerDialogue();
                                    _uncleDialogCount = 2;
                                }
                                return;
                            }
                            else return;
                            
                        case ("Page3"):
                            if (_plantHasMoved == true)
                            {
                                Debug.Log("Hit Page3" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page3>().PickUp();
                                if (pageCount == 5)
                                {
                                    EnterDialog();
                                    _allPages.GetComponent<DialogueTrigger>().TriggerDialogue();
                                    _uncleDialogCount = 2;
                                }
                                return;
                            }
                            else return;
                            
                        case ("Page4"):
                            if (_plateHasMoved == true)
                            {
                                Debug.Log("Hit Page4" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page4>().PickUp();
                                if (pageCount == 5)
                                {
                                    EnterDialog();
                                    _allPages.GetComponent<DialogueTrigger>().TriggerDialogue();
                                    _uncleDialogCount = 2;
                                }
                                return;
                            }
                            else return;
                            
                        case ("Page5"):
                            if (_sheetHasMoved == true)
                            {
                                Debug.Log("Hit Page5" + Time.time);
                                hitInfo.transform.gameObject.GetComponent<Page5>().PickUp();
                                if (pageCount == 5)
                                {
                                    EnterDialog();
                                    _allPages.GetComponent<DialogueTrigger>().TriggerDialogue();
                                    _uncleDialogCount = 2;
                                }
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
                            if (_firstWakeUncle)
                            {
                                _uncle.GetComponent<Uncle>().WakeUp();
                                _firstWakeUncle = false;
                                ActivatePages();
                            }

                            if (_uncleDialogCount == 1)
                            {
                                EnterDialog();
                                _uncle.GetComponent<DialogueTrigger>().TriggerDialogue();
                            }
                            return;

                        case ("Toilet"):
                            _toilet.GetComponent<Toilet>().Flush();
                            return;

                        case ("FirstAid"):
                            Debug.Log("Hit First Aid Kit" + Time.time);
                            EnterDialog();
                            _firstAid.GetComponent<DialogueTrigger>().TriggerDialogue();
                            return;

                        case ("Spellbook"):
                            Debug.Log("Hit Spellbook @ " + Time.deltaTime);
                            if (pageCount == 5 && _spellBookFirstTime)
                            {
                                _spellBookFirstTime = false;
                                _uiManager.GetComponent<UIManager>().TurnOffPages();
                                hitInfo.transform.GetComponent<Spellbook>().PlaySound();
                                EnterDialog();
                                hitInfo.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                                if (_hasWand)
                                {
                                    mana = 0.0f;
                                    _uiManager.GetComponent<UIManager>().ActivateManaMeter();
                                    _manaCrystal.GetComponent<SphereCollider>().enabled = true;                                   
                                }
                                return;
                            } else
                            return;

                        case ("ManaCrystal"):
                            Debug.Log("Hit ManaCrystal @ " + Time.time);
                            EnterDialog();
                            _manaCrystal.GetComponent<DialogueTrigger>().TriggerDialogue();
                            return;

                        case ("Wand"):
                            Debug.Log("Hit Wand @ " + Time.time);
                            hitInfo.transform.GetComponent<Wand>().PlayPickupSound();
                            _hasWand = true;
                            EnterDialog();
                            hitInfo.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                            if (!_spellBookFirstTime)
                            {
                                mana = 0.0f;
                                _uiManager.GetComponent<UIManager>().ActivateManaMeter();
                                _manaCrystal.GetComponent<SphereCollider>().enabled = true;

                            }
                            return;

                        case ("Lamp"):
                            Debug.Log("Hit Lamp @ " + Time.time);
                            _spawnManager.SpawnEnemy(new Vector3 (-1.0f, 1.0f, 20f));
                            _audioSourceLamp.PlayOneShot(_evilLaugh, 1.0f);
                            return;
                    }
                }
            }
            else if (_isWandEquipped == true && _inDialogue == false)
            {
                if (mana <= 0)
                {
                    _audioSourceWand.PlayOneShot(_wandDud);
                    return;
                }else
                Debug.Log("Fire Missile" + Time.time);
                Instantiate(_missile, _tip.transform.position, _tip.transform.rotation);
                _audioSourceWand.PlayOneShot(_fireballShoot, 1.0f);
                // call spendMana(cost of 1 shot) on UIManager script;
                _uiManager.GetComponent<UIManager>().SpendMana(0.05f);
                // decrease mana var on this script
                mana = mana - 0.05f;
            }
        }

       if (health <= 0 && _isAlive)
        {
            _isAlive = false;
            //_uiManager.GetComponent<UIManager>().LoseHealth(1.0f);
            _audioSourceVoice.PlayOneShot(_die, 0.5f);
            EnterDialog();
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

   
    public void EnterDialog()
    {
        _inDialogue = true;
        _controller.enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
        _crossHair.SetActive(false);
    }

    public void ReturnToGame()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        } else
        {
            _inDialogue = false;
            _controller.enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _crossHair.SetActive(true);
        }
        
    }

    public void RegainMana(float amount)
    {
        mana = Mathf.Clamp01(mana + amount);
    }

    public void RestoreHealth(float amount)
    {
        health = Mathf.Clamp01(health + amount);
    }

    public void DamageHealth(float amount)
    {
        health = Mathf.Clamp01(health - amount);
    }

    void ActivatePages()
    {
        _page1.SetActive(true);
        _page2.SetActive(true);
        _page3.SetActive(true);
        _page4.SetActive(true);
        _page5.SetActive(true);
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
