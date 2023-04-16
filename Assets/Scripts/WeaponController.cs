using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OmnicatLabs.Managers;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> guns = new List<GameObject>();
    public float gunCooldown = 1f;

    private bool shootHeld = false;
    private bool canShoot = true;
    private bool startedTimer = false;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            shootHeld = false;
        }
        if (context.performed)
        {
            shootHeld = true;
            if (!startedTimer)
            {
                TimerManager.Instance.CreateTimer(gunCooldown, CanShoot, true);
                startedTimer = true;
            }
        }
    }

    private void Update()
    {
        if (shootHeld && canShoot)
        {
            canShoot = false;
            foreach (GameObject gun in guns)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
                bullet.GetComponent<Bullet>().forward = transform.forward;
            }
        }
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}
