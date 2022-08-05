using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayCast : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    private GameObject hitCube;
    private Ray _ray;
    private RaycastHit _raycastHit;

    private LineRenderer lazerLine;

    private float lazerDuration = 0.5f;

    void Start()
    {
        lazerLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var mousePosition = Input.mousePosition;

        mousePosition.z = playerCamera.transform.position.z;
        _ray = playerCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            lazerLine.SetPosition(1, _raycastHit.point);
            StartCoroutine(LazerDuration());
            hitCube = _raycastHit.collider.gameObject;

            if (hitCube.GetComponent<Fling>() != null)
            {
                hitCube.GetComponent<Fling>().isActivate = true;
            }
        }

        IEnumerator LazerDuration()
        {
            lazerLine.enabled = true;
            yield return new WaitForSeconds(lazerDuration);
            lazerLine.enabled = false;
        }
    }
}
