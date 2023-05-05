using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private Transform lastGround;

    private Vector3 _direction;

    private void Awake()
    {
        for(int i = 1; i <=1; i++)
        {
            CreateGround();
        }
    }

    public void CreateGround()
    {

        if(Random.Range(0,2) == 0) _direction = Vector3.left;

        else _direction = Vector3.forward;


        lastGround = Instantiate(lastGround, lastGround.position + _direction, lastGround.rotation,lastGround.parent);
        lastGround.name = "Ground";
    }

    public void UnActiveGroundTask(Transform previousGround)
    {
        StartCoroutine(UnActiveGround(previousGround));
    }

    private IEnumerator UnActiveGround(Transform previousGround)
    {
        yield return new WaitForSeconds(.2f);

        previousGround.gameObject.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(1f);

        previousGround.gameObject.SetActive(false);
    }

}//Class
