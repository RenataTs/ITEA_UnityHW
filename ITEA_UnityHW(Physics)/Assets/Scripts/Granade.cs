using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] GameObject explodeEffect;

    [SerializeField] LayerMask layerToHit;

    [SerializeField] float _radius = 5f;
    [SerializeField] float _force = 700f;

    private bool hasExploded = false;

    public void Explode()
    {
        Instantiate(explodeEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, layerToHit);

        foreach (Collider nerbyObject in colliders)
        {
            Rigidbody rb = nerbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_force, transform.position, _radius);
            }
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
        hasExploded = true;
    }
}
