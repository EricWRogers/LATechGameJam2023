using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Managers;
using SuperPupSystems.Helper;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed = 20f;
    public float cullTime = 10f;
    public LayerMask mask;
    [HideInInspector]
    public Vector3 forward;

    private Rigidbody rb;
    private bool launched = false;
    private bool hit = false;
    private Vector3 positionLastFrame;
    private RaycastHit info;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        HandleMovement();
    }

    private void HandleMovement()
    {
        //Get a position from the target system

        rb.AddForce(forward * speed, ForceMode.Impulse);
        launched = true;
        TimerManager.Instance.CreateTimer(cullTime, DestroyBullet);
    }

    private void FixedUpdate()
    {
        if (Physics.Linecast(positionLastFrame, transform.position, out info, mask))
        {
            if (info.transform.CompareTag("Enemy") || info.transform.CompareTag("Player"))
            {
                Debug.Log("Hit Enemy");
                info.transform.GetComponentInParent<Health>().Damage(damage);
                Destroy(gameObject);
            }
        }

        positionLastFrame = transform.position;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
