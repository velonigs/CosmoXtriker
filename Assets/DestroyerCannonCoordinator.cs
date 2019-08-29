using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCannonCoordinator : MonoBehaviour
{
    public Transform[] cannon;
    protected float RotationSpeed = 10;
    protected Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance != null)
        {
            player = PlayerController.instance.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (player.position.y >= cannon[0].position.y)
        {
            for (int i = 0; i < cannon.Length; i++)
            {

                Quaternion targetRot = Quaternion.LookRotation(player.position - cannon[i].position);
                cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, targetRot, RotationSpeed * Time.deltaTime);

            }
        }
      
    }
}
