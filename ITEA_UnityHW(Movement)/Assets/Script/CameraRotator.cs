using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour
{

    Quaternion originRotation;
    float angleHorizontal;
    public float mouseSens = 2;
    public float stopFactor = 5;
    Animator anim;

    private Quaternion Rotation()
    {
        originRotation = transform.rotation;

        return originRotation;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        angleHorizontal += Input.GetAxis("Mouse X") * mouseSens;

        Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);

        transform.rotation = Rotation() * rotationY;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward / stopFactor * Time.deltaTime;
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward / stopFactor * Time.deltaTime;
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right / stopFactor * Time.deltaTime;
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right / stopFactor * Time.deltaTime;
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Standing", true);
        }
    }
}