using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    [SerializeField] private GameObject[] _helps;
    [SerializeField] private int _currectHelp;

    [SerializeField] private GameObject _taskObj;

    private void Start()
    {
        _taskObj.SetActive(true);
    }

    public void Next()
    {
        foreach(GameObject help in _helps)
        {
            help.SetActive(false);
        }

        if(_currectHelp >= _helps.Length)
        {
            return;
        }
        _currectHelp++;
        _helps[_currectHelp].SetActive(true);
    }

    public void Confirm()
    {
        Time.timeScale = 1;
        _taskObj.SetActive(false);
        _currectHelp = 0;
        foreach(GameObject help in _helps)
        {
            help.SetActive(false);
        }
        _helps[_currectHelp].SetActive(true);
    }

    public void Cancel()
    {
        Time.timeScale = 1;
        _taskObj.SetActive(false);
        enabled = false;
    }
}
