using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Manager : MonoBehaviour
{
    [SerializeField] public GameObject Credit1;
    [SerializeField] public GameObject Credit1con;
    [SerializeField] public GameObject Credit2;
    [SerializeField] public GameObject Credit2con;
    [SerializeField] public GameObject Credit3;
    [SerializeField] public GameObject Credit3con;
    [SerializeField] public GameObject Credit4;
    [SerializeField] public GameObject Credit4con;
    [SerializeField] public GameObject Credit5;
    [SerializeField] public GameObject Credit5con;
    [SerializeField] public GameObject Credit11;
    [SerializeField] public GameObject Credit11con;
    [SerializeField] public GameObject Credit12;
    [SerializeField] public GameObject Credit12con;
    [SerializeField] public GameObject Credit13;
    [SerializeField] public GameObject Credit13con;
    [SerializeField] public GameObject Credit14;
    [SerializeField] public GameObject Credit14con;
    [SerializeField] public GameObject Credit15;
    [SerializeField] public GameObject Credit15con;

    [SerializeField] public GameObject Credit_Manager2;

    float seconds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 0.5)
        {
            Credit1.transform.position = Credit1con.transform.position;
        }
        if(seconds >= 5.5)
        {
            Credit1.SetActive(false);
            Credit1con.SetActive(false);
        }
        if (seconds >= 0.8)
        {
            Credit2.transform.position = Credit2con.transform.position;
        }
        if (seconds >= 5.8)
        {
            Credit2.SetActive(false);
            Credit2con.SetActive(false);
        }
        if (seconds >= 3)
        {
            Credit3.transform.position = Credit3con.transform.position;
        }
        if (seconds >= 8)
        {
            Credit3.SetActive(false);
            Credit3con.SetActive(false);
        }
        if (seconds >= 5)
        {
            Credit4.transform.position = Credit4con.transform.position;
        }
        if (seconds >= 10)
        {
            Credit4.SetActive(false);
            Credit4con.SetActive(false);
        }
        if (seconds >= 6)
        {
            Credit5.transform.position = Credit5con.transform.position;
        }
        if (seconds >= 7)
        {
            Credit_Manager2.SetActive(true);
        }
        if (seconds >= 11)
        {
            Credit5.SetActive(false);
            Credit5con.SetActive(false);
        }
        if (seconds >= 12.5)
        {
            Credit11.transform.position = Credit11con.transform.position;
        }
        if (seconds >= 20)
        {
            Credit12.transform.position = Credit12con.transform.position;
        }
        if (seconds >= 20)
        {
            Credit13.transform.position = Credit13con.transform.position;
        }
    }
}
