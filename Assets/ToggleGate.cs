using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGate : MonoBehaviour
{
    public GameObject gate01;
    public GameObject gate02;

    private void Start()
    {
        if(Random.Range(0,100) > 50)
        {
            gate01.SetActive(false);
            gate02.SetActive(true);
        }
        else
        {
            gate02.SetActive(false);
            gate01.SetActive(true);
        }
    }

    public void Toggle()
    {
        gate01.SetActive(!gate01.activeSelf);
        gate02.SetActive(!gate02.activeSelf);
    }
}
