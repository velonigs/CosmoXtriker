using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Manager2 : MonoBehaviour
{
    [SerializeField] public GameObject Credit6;
    [SerializeField] public GameObject Credit6con;
    [SerializeField] public GameObject Credit7;
    [SerializeField] public GameObject Credit7con;
    [SerializeField] public GameObject Credit8;
    [SerializeField] public GameObject Credit8con;
    [SerializeField] public GameObject Credit9;
    [SerializeField] public GameObject Credit9con;
    [SerializeField] public GameObject Credit10;
    [SerializeField] public GameObject Credit10con;

    float seconds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (seconds >= 1)
        {
            Credit6.transform.position = Credit6con.transform.position;
        }
        if (seconds >= 6)
        {
            Credit6.SetActive(false);
            Credit6con.SetActive(false);
        }
        if (seconds >= 1.3)
        {
            Credit7.transform.position = Credit7con.transform.position;
        }
        if (seconds >= 6.3)
        {
            Credit7.SetActive(false);
            Credit7con.SetActive(false);
        }
        if (seconds >= 2.2)
        {
            Credit8.transform.position = Credit8con.transform.position;
        }
        if (seconds >= 7.2)
        {
            Credit8.SetActive(false);
            Credit8con.SetActive(false);
        }
        if (seconds >= 3)
        {
            Credit9.transform.position = Credit9con.transform.position;
        }
        if (seconds >= 8)
        {
            Credit9.SetActive(false);
            Credit9con.SetActive(false);
        }
        if (seconds >= 5)
        {
            Credit10.transform.position = Credit10con.transform.position;
        }
        if (seconds >= 10)
        {
            Credit10.SetActive(false);
            Credit10con.SetActive(false);
        }
    }
}
