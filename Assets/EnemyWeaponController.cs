using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Managers;

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
        Shoot();
        Shoot();
        Shoot();
        Shoot();
        Shoot();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            if (!startedTimer)
            {
                TimerManager.Instance.CreateTimer(gunCooldown, CanShoot, true);
                startedTimer = true;
            }

            foreach (GameObject gun in guns)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
                bullet.GetComponent<Bullet>().forward = transform.forward;
            }
        }

        //if (context.canceled)
        //{
        //    shootHeld = false;
        //}
        //if (context.performed)
        //{
        //    shootHeld = true;
        //    if (!startedTimer)
        //    {
        //        TimerManager.Instance.CreateTimer(gunCooldown, CanShoot, true);
        //        startedTimer = true;
        //    }
        //}
    }

    private void Update()
    {
        Shoot();

        //if (shootHeld && canShoot)
        //{
        //    canShoot = false;
        //    foreach (GameObject gun in guns)
        //    {
        //        Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        //    }
        //}
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}
