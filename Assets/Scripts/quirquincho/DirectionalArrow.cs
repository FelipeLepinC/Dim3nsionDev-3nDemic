using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{

    [SerializeField]
    public Transform target;
    private GameObject[] madriguera;

    private void Awake()
    {
        madriguera = GameObject.FindGameObjectsWithTag("Madrigera");
    }

    private void Update()
    {
        Vector3 targetPosition = madriguera[0].transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
}
