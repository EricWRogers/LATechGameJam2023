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
    private Vector3 previousAVelocity;
    private bool didLock = false;

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
            //rb.angularVelocity = Vector3.zero;
            //inputRotation = Vector3.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            inputMovement = transform.forward * moveAcceleration * Time.deltaTime;
        }
    }

    //private bool LimitZRotation()
    //{
    //    Vector3 shipEulerAngles = transform.rotation.eulerAngles;

    //    shipEulerAngles.z = (shipEulerAngles.z > 180) ? shipEulerAngles.z - 360 : shipEulerAngles.z;

    //    float tempZ = shipEulerAngles.z;

    //    shipEulerAngles.z = Mathf.Clamp(shipEulerAngles.z, -20f, 20f);

    //    transform.rotation = Quaternion.Euler(shipEulerAngles);

    //    return (tempZ != shipEulerAngles.z);
    //}

    //private bool LimitXRotation()
    //{
    //    Vector3 shipEulerAngles = transform.rotation.eulerAngles;

    //    shipEulerAngles.x = (shipEulerAngles.x > 180) ? shipEulerAngles.x - 360 : shipEulerAngles.x;

    //    float tempX = shipEulerAngles.x;

    //    shipEulerAngles.x = Mathf.Clamp(shipEulerAngles.x, -20f, 20f);

    //    transform.rotation = Quaternion.Euler(shipEulerAngles);

    //    return (tempX != shipEulerAngles.x);
    //}

    //private bool LimitYRotation()
    //{
    //    Vector3 shipEulerAngles = transform.rotation.eulerAngles;

    //    shipEulerAngles.y = (shipEulerAngles.y > 180) ? shipEulerAngles.y - 360 : shipEulerAngles.y;

    //    float tempY = shipEulerAngles.y;

    //    shipEulerAngles.y = Mathf.Clamp(shipEulerAngles.y, 0.0f, 0.1f);

    //    transform.rotation = Quaternion.Euler(shipEulerAngles);

    //    return (tempY != shipEulerAngles.y);
    //}

    //private void Update()
    //{
    //    if (LimitXRotation())
    //        rb.angularVelocity = new Vector3(previousAVelocity.x, rb.angularVelocity.y, rb.angularVelocity.z);
    //    if (LimitYRotation())
    //        rb.angularVelocity = new Vector3(rb.angularVelocity.x, previousAVelocity.y, rb.angularVelocity.z);
    //    if(LimitZRotation())
    //        rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, previousAVelocity.z);

    //    previousAVelocity = rb.angularVelocity;
    //}

    private void FixedUpdate()
    {
        if (inputRotation != Vector3.zero)
        {
            rb.AddTorque(inputRotation * tiltForce * Time.deltaTime);
        }

        if (inputMovement != Vector3.zero)
        {
            rb.AddForce(inputMovement * moveAcceleration * Time.deltaTime);
        }

        //LimitRotation();


        if (rb.angularVelocity.magnitude >= maxTiltAcceleration)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxTiltAcceleration;
        }

        if (rb.velocity.magnitude >= maxMoveAcceleration)
        {
            rb.velocity = rb.velocity.normalized * maxMoveAcceleration;
        }
    }
}
