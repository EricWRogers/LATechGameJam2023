using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OmnicatLabs.Managers;

public class NewShipController : MonoBehaviour
{
    public MeshRenderer mesh;
    public float flashTime = .5f;

    [Header("Standard Movement")]
    public float yawTorque = 500f;
    public float pitchTorque = 1000f;
    public float rollTorque = 1000f;
    public float thrust = 100f;
    public float upThrust = 50f;
    public float strafeThrust = 50f;
    [Range(0.001f, 0.999f)]
    public float thrustGlideReduction = 0.999f;
    [Range(0.001f, 0.999f)]
    public float upDownGlideReduction = 0.111f;
    [Range(0.001f, 0.999f)]
    public float leftRightGlideReduction = 0.111f;

    [Header("Boost Movement")]
    public float maxBoostAmount = 2f;
    public float boostDeprecationRate = 0.25f;
    public float boostRechargeRate = 0.5f;
    public float boostMultiplier = 5f;

    private Rigidbody rb;
    private float thrustInput;
    private float upDownInput;
    private float strafeInput;
    private float rollInput;
    private Vector2 pitchYawInput;
    private float glide, verticalGlide, horizontalGlide = 0f;
    private bool boosting = false;
    private float currentBoostAmount = 0f;
    private List<Color> originalColors = new List<Color>();
    private bool menuIsOpen = false;

    private void Start()
    {
        foreach (Material mat in mesh.materials)
        {
            originalColors.Add(mat.color);
        }
        rb = GetComponent<Rigidbody>();
        currentBoostAmount = maxBoostAmount;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public float GetNormalizedBoost()
    {
        return currentBoostAmount / maxBoostAmount;
    }

    public void OnDamaged()
    {
        foreach (Material mat in mesh.materials)
        {
            mat.color = Color.red;
        }

        TimerManager.Instance.CreateTimer(flashTime, ResetFlash);
    }

    private void ResetFlash()
    {
        for (int i = 0; i < mesh.materials.Length; i++)
        {
            mesh.materials[i].color = originalColors[i];
        }
    }

    private void FixedUpdate()
    {
        HandleBoosting();
        HandleMovement();
    }

    private void HandleBoosting()
    {
        if (boosting && currentBoostAmount > 0f)
        {
            currentBoostAmount -= boostDeprecationRate;
            if (currentBoostAmount <= 0f)
            {
                boosting = false;
            }
        }
        else
        {
            if (currentBoostAmount < maxBoostAmount)
            {
                currentBoostAmount += boostRechargeRate;
            }
        }
    }

    private void HandleMovement()
    {
        //Roll
        rb.AddRelativeTorque(Vector3.back * rollInput * rollTorque * Time.deltaTime);

        //Pitch
        rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(-pitchYawInput.y, -1f, 1f) * pitchTorque * Time.deltaTime);

        //Yaw
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYawInput.x, -1f, 1f) * yawTorque * Time.deltaTime);

        //Thrust
        if (thrustInput > 0.1f || thrustInput < -0.1f)
        {
            float currentThrust;

            if (boosting)
                currentThrust = thrust * Stats.Instance.speedModifier * boostMultiplier;
            else currentThrust = thrust * Stats.Instance.speedModifier;

            rb.AddRelativeForce(Vector3.forward * thrustInput * currentThrust * Time.deltaTime);
            glide = thrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        //UpDown
        if (upDownInput > 0.1f || upDownInput < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDownInput * upThrust * Time.fixedDeltaTime);
            verticalGlide = upDownInput * upThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.up * verticalGlide * Time.fixedDeltaTime);
            verticalGlide *= upDownGlideReduction;
        }

        //Strafing
        if (strafeInput > 0.1f || strafeInput < -0.1f)
        {
            rb.AddRelativeForce(Vector3.right * strafeInput * strafeThrust * Time.fixedDeltaTime);
            horizontalGlide = strafeInput * strafeThrust;
        }    
        else
        {
            rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.fixedDeltaTime);
            horizontalGlide *= leftRightGlideReduction;
        }
    }

    #region Input Methods
    public void OnThrust(InputAction.CallbackContext context)
    {
        thrustInput = context.ReadValue<float>();
    }

    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafeInput = context.ReadValue<float>();
    }

    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDownInput = context.ReadValue<float>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        rollInput = context.ReadValue<float>();
    }

    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        pitchYawInput = context.ReadValue<Vector2>();
    }
    
    public void OnBoost(InputAction.CallbackContext context)
    {
        boosting = context.performed;
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if (!menuIsOpen && context.performed)
        {
            menuIsOpen = true;
            Navigator.Instance.OpenUpgradeMenu();
        }
        else if (menuIsOpen && context.performed)
        {
            menuIsOpen = false;
            Navigator.Instance.CloseUpgradeMenu();
        }

        //if (menuIsOpen && context.performed)
        //{
        //    menuIsOpen = false;
        //    Navigator.Instance.CloseUpgradeMenu();
        //    return;
        //}

        //if (context.performed && !menuIsOpen)
        //{
        //    Navigator.Instance.OpenUpgradeMenu();
        //    menuIsOpen = true;
        //    return;
        //}
    }
    #endregion
}
