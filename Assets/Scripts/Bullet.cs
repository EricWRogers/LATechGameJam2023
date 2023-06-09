using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Timer timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = GetComponent<Timer>();
        timer.TimeOut.AddListener(DestroyBullet);

        HandleMovement();
    }

    private void HandleMovement()
    {
        //Get a position from the target system

        rb.AddForce(forward * speed, ForceMode.Impulse);
        launched = true;
        timer.StartTimer(cullTime);
    }

    private void FixedUpdate()
    {
        if (Physics.Linecast(positionLastFrame, transform.position, out info, mask))
        {
            if (info.transform.CompareTag("Enemy") || info.transform.CompareTag("Destructables"))
            {
                info.transform.GetComponentInParent<Health>().Damage(Mathf.RoundToInt(damage * Stats.Instance.attackModifier));
                Destroy(gameObject);
            }

            if (info.transform.CompareTag("Player"))
            {
                info.transform.GetComponentInParent<ShipHealth>().Damage(Mathf.RoundToInt(damage * Stats.Instance.attackModifier));
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
