using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _page1;
    [SerializeField]
    private GameObject _page2;
    [SerializeField]
    private GameObject _page3;
    [SerializeField]
    private GameObject _page4;
    [SerializeField]
    private GameObject _page5;

    [SerializeField]
    private Slider _healthMeter;
    [SerializeField]
    private Slider _manaMeter;



    private void Start()
    {
        _healthMeter.value = 1f;
        _manaMeter.value = 1f;
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
}
