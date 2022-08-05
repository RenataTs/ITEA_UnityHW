using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemEnd : MonoBehaviour
{
    [SerializeField] private GameObject rotate;

    public void OnCollisionEnter(Collision collision)
    {
        rotate.GetComponent<LeverRotation>().enabled = true;
    }
}
