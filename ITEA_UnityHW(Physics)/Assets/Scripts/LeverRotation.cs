using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotation : MonoBehaviour
{
    [SerializeField] private GameObject rayCastObject;

    private float degrees = 180;
    private float speed = 3;
    
    private void Update()
    {
        Vector3 to = new Vector3(0, degrees, 0);
        gameObject.transform.eulerAngles = Vector3.Lerp(gameObject.transform.rotation.eulerAngles, to, speed * Time.deltaTime);

        rayCastObject.GetComponent<RayCast>().enabled = true;
    }
}
