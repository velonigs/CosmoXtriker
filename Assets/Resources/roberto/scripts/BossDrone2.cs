using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone2 : MonoBehaviour
{

    BossMove boss;
    float x = 0, y = 0, z = 0;
    bool start;
    float timer = 1;
    Vector3 dir = new Vector3();
    [SerializeField]
    float speed = 1f;
    Transform player;
    [SerializeField]
    float attackDistance = 5;
    [SerializeField]
    GameObject bullet;
    [SerializeField] float fireDelay = 2f;
    float fireCounter;
    [SerializeField] Transform spawnpoint;
    float changemovemente = 5;
    GameObject orbit;
    [SerializeField]
    float BossDist = 5;
    DroneManager dronemanager;


    // Start is called before the first frame update
    void Start()
    {
        fireCounter = fireDelay;
        x = Random.Range(-BossDist, BossDist);
        y = Random.Range(-BossDist, BossDist);


        while (x > -2 && x < 2)
        {
            x = Random.Range(-BossDist, BossDist);
        }
        while (y > -2 && y < 2)
        {
            y = Random.Range(-BossDist, BossDist);
        }

        dronemanager = FindObjectOfType<DroneManager>();
        start = true;
        player = PlayerController.instance.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer -= Time.deltaTime;
            dir = new Vector3(x, y, z);
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            if (timer <= 0)
            {
                start = false;
            }
        }
        else
        {
            
            //player 
            Vector3 loocktarget = player.position;
            Vector3 direction = loocktarget - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 1.2f);
            if (direction.magnitude >dronemanager.transform.position.z- player.position.z )
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else
            {
                changemovemente -= Time.deltaTime;
                if (changemovemente <= 0)
                {
                    changemovemente = 5;
                    changeMove();
                }
                dir = new Vector3(x, y, 0);
                Vector3 newDirec = Vector3.Slerp(transform.localPosition, dir, speed);

               

                Bounds b = new Bounds(dronemanager.transform.position, dronemanager.Limits);
                
                    if (!b.Contains(transform.position)){
                    newDirec = dronemanager.transform.position;
                }
                transform.Translate(newDirec.normalized * Time.deltaTime, Space.Self);
            }
           

        }

            fireCounter -= Time.deltaTime;
            if (fireCounter <= 0)
            {
                fireCounter = fireDelay;
                Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
            }
        }
        



    


    public void changeMove()
    {
        x = Random.Range(-BossDist, BossDist);
        y = Random.Range(-BossDist, BossDist);
        z = Random.Range(-0.1f, 0.1f);

    }
}
