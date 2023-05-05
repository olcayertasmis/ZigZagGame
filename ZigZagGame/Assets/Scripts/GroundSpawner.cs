using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private Transform lastGround;

    private Vector3 _direction;

    private void Start()
    {
        for(int i = 1; i <=10; i++)
        {
            CreateGround();
        }
    }

    private void CreateGround()
    {

        if(Random.Range(0,2) == 0) _direction = Vector3.left;

        else _direction = Vector3.forward;


        lastGround = Instantiate(lastGround, lastGround.position + _direction, lastGround.rotation);
    }

}//Class
