using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundSpawner : MonoBehaviour
{
    [Header("Outside Compenents")]
    [SerializeField] private Transform newGround;
    [SerializeField] private GameObject gold;

    [Header("Ground Variables")]
    private Vector3 _direction;
    private int _leftCount, _forwardCount;

    private void Awake()
    {
        for (int i = 1; i <= 1; i++)
        {
            CreateGround();
        }
    }

    public void CreateGround()
    {
        if (Random.Range(0, 2) == 0 && _leftCount <= 2)
        {
            _direction = Vector3.left;
            _leftCount++;
        }
        else
        {
            _leftCount = 0;
            _direction = Vector3.forward;
        }

        if (Random.Range(0, 2) == 1 && _forwardCount <= 2)
        {
            _direction = Vector3.forward;
            _forwardCount++;
        }
        else
        {
            _forwardCount = 0;
            _direction = Vector3.left;
        }

        newGround = Instantiate(newGround, newGround.position + _direction, newGround.rotation, newGround.parent);
        newGround.name = "Ground";

        CreateGoldRandom(newGround);
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

    private void CreateGoldRandom(Transform newGround)
    {
        int rand = Random.Range(0, 3);

        if (rand == 1)
        {
            Instantiate(gold, newGround);
        }
    }
} //Class