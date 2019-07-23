using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
