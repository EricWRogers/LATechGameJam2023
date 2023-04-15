using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> guns = new List<GameObject>();
    public float attackDamage = 10f;
    public float gunCooldown = .3f;

    public void OnShoot(InputAction.CallbackContext context)
    {
        foreach (GameObject gun in guns)
        {
            Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        }
    }
}
