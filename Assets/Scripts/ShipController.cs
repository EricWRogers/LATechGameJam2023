using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float tiltForce = 50f;
    public float maxTiltAcceleration = 5f;
    public float moveAcceleration = 500f;
    public float maxMoveAcceleration = 3f;

    private Vector3 inputDirection;
    private Vector3 inputRotation;
    private Vector3 inputMovement;
    private Rigidbody rb;
    private bool canRotate = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTilt(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            inputDirection = context.ReadValue<Vector2>();

            inputRotation = new Vector3(inputDirection.y,0.0f,-inputDirection.x);
        }

        if (context.canceled)
        {
            rb.angularVelocity = Vector3.zero;
            inputRotation = Vector3.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            inputMovement = Vector3.forward * moveAcceleration * Time.deltaTime;
        }
    }

    private void LimitRotation()
    {
        Vector3 shipEulerAngles = transform.rotation.eulerAngles;

        shipEulerAngles.z = (shipEulerAngles.z < 180) ? shipEulerAngles.z - 360 : shipEulerAngles.y;
        shipEulerAngles.z = Mathf.Clamp(shipEulerAngles.z, -20f, 20f);

        transform.rotation = Quaternion.Euler(shipEulerAngles);
    }

    private void FixedUpdate()
    {
        if (inputRotation != Vector3.zero)
        {
            rb.AddTorque(inputRotation * tiltForce * Time.deltaTime);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(inputRotation), tiltForce * Time.deltaTime);

        LimitRotation();

        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, ClampAngle(transform.rotation.z, 340f, 20f));

        //if (rb.angularVelocity.magnitude >= maxAcceleration)
        //{
        //    rb.angularVelocity = rb.angularVelocity.normalized * maxAcceleration;
        //}

        //if (transform.rotation.eulerAngles.z > 20f)
        //{
        //    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 20f);
        //    canRotate = false;
        //}

        //else if (transform.rotation.eulerAngles.z < 340f)
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.eulerAngles.y, 340f);
        //    canRotate = false;
        //}
        //else canRotate = true;

        ////transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Clamp(transform.eulerAngles.z, 20f, 340f));

        ////if (transform.rotation.z >= 20f)
        ////{
        ////    transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 20f);
        ////}

        ////transform.eulerAngles = new Vector3(Mathf.Clamp(transform.rotation.x, -20f, 20f), 0.0f, Mathf.Clamp(transform.rotation.z, -20f, 20f));

        //Debug.Log(transform.eulerAngles);
    }
}
