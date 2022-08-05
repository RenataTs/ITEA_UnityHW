using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    public bool isActivate;

    private void Start()
    {
        isActivate = false;
    }

    private void Update()
    {
        if (isActivate)
        {
            timer.GetComponent<Timer>().Being();
            isActivate = false;
        }
    }

    public void Explode()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -10);
        StartCoroutine(StopArm());
    }

    IEnumerator StopArm()
    {
        yield return new WaitForSeconds(0.35f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 2);
    }
}
