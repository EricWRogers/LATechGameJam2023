using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> guns = new List<GameObject>();
    public float gunCooldown = 1f;

    private bool shootHeld = false;
    private bool canShoot = true;
    private bool startedTimer = false;

    private void Start()
    {
        gameObject.GetComponent<SuperPupSystems.Helper.Timer>().CountDownTime = gunCooldown;
    }

    public void Shoot()
    {
        FireCannons();
    }

    private void FireCannons()
    {
        foreach (GameObject gun in guns)
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            bullet.GetComponent<Bullet>().forward = transform.forward;
        }
    }
}
