using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _page1 = null;
    [SerializeField]
    private GameObject _page2 = null;
    [SerializeField]
    private GameObject _page3 = null;
    [SerializeField]
    private GameObject _page4 = null;
    [SerializeField]
    private GameObject _page5 = null;

    [SerializeField]
    private GameObject _manaMeterObject = null;
    [SerializeField]
    private Slider _healthMeter = null;
    [SerializeField]
    private Slider _manaMeter = null;



    private void Start()
    {
        _healthMeter.value = 1.0f;
        _manaMeter.value = 0f;
    }

    public void ActivateManaMeter()
    {
        _manaMeter.value = 0f;
        _manaMeterObject.SetActive(true);
    }

    public void LoseHealth(float damage)
    {
        _healthMeter.value = Mathf.Clamp01(_healthMeter.value - damage);
    }

    public void RegainHealth(float amount)
    {
        _healthMeter.value = _healthMeter.value + amount;
    }

    public void SpendMana(float cost)
    {
        _manaMeter.value = Mathf.Clamp01(_manaMeter.value - cost);
    }

    public void RegainMana(float amount)
    {
        _manaMeter.value = Mathf.Clamp01(_manaMeter.value + amount);
    }

    public void CollectedPage1()
    {
        _page1.SetActive(true);
    }

    public void CollectedPage2()
    {
        _page2.SetActive(true);
    }

    public void CollectedPage3()
    {
        _page3.SetActive(true);
    }

    public void CollectedPage4()
    {
        _page4.SetActive(true);
    }

    public void CollectedPage5()
    {
        _page5.SetActive(true);
    }

    public void TurnOffPages()
    {
        _page1.SetActive(false);
        _page2.SetActive(false);
        _page3.SetActive(false);
        _page4.SetActive(false);
        _page5.SetActive(false);
    }
}
