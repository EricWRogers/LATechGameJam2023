using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Scrap,
    GreenCrystal,
    BlueCrystal,
    RedCrystal
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int amount = 10;
    public float pullRange = 50f;
    public float pullSpeed = 500f;
    public float pullTorque = 100f;
    public float collectRadius = 10f;

    private GameObject ship;
    private Rigidbody rb;

    private void Start()
    {
        ship = FindObjectOfType<ShipController>().gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(ship.transform.position, transform.position) <= pullRange)
        {
            Vector3 dir = (ship.transform.position - transform.position).normalized;

            rb.AddForce(dir * pullSpeed * Time.deltaTime);

            rb.AddTorque(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)) * pullTorque * Time.deltaTime);

            Collider[] hits = Physics.OverlapSphere(transform.position, collectRadius);

            foreach(Collider hit in hits)
            {
                if (hit.CompareTag("Ship"))
                {
                    Destroy(gameObject);
                    Inventory.Instance.Add(type, amount);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pullRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }
}
