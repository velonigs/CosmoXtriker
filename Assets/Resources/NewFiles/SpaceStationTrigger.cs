using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTrigger : MonoBehaviour
{
    [SerializeField] GameObject drone;
    
    //偽物のドローン
    [SerializeField] GameObject fakeDrone;
    //ドローンの画像
    MeshRenderer REND;

    bool isTheFirstTime;
    // Start is called before the first frame update
    void Start()
    {
        isTheFirstTime = true;
        REND = fakeDrone.gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isTheFirstTime)
            {
                isTheFirstTime = false;
                //偽物の画像を消して、おっもののドローンを作成する
                REND.enabled = false;
                Instantiate(drone, fakeDrone.transform.position, fakeDrone.transform.rotation);
            }
        }
    }
}
