using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private float smooth = 5.0f;
    private float tiltAngle = 60.0f;
    private float tiltAround;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            Rotation();
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            Rotation();
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            Rotation();
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            Rotation();
            anim.SetBool("Walking", true);
            anim.SetBool("Standing", false);
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Standing", true);
        }
    }

    private void Rotation()
    {
        tiltAround = Input.GetAxis("Horizontal") * tiltAngle;

        Quaternion target = Quaternion.Euler(0f, tiltAround, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }
}
