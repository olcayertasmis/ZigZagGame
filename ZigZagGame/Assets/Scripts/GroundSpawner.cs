using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private Transform lastGround;

    private void Start()
    {
        for(int i = 1; i <=10; i++)
        {
            CreateGround();
        }
    }

    private void CreateGround()
    {
        lastGround = Instantiate(lastGround, lastGround.position + Vector3.forward, lastGround.rotation);
    }

}//Class
