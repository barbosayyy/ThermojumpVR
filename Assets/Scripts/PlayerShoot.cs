using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject pivot;
    public bool hasShot = false;
    public bool canShoot;
    public bool hasWeapon;
    public bool isPaused;
    public PlayerData playerData;
    public Animator rocketLauncherAnimator;
    public InputManager inputManager;
    public GameObject _rocketPrefab;

    private float _cooldownValue;
    private Vector3 _pivotPosition;

    void Start()
    {
        _cooldownValue = playerData.weaponCooldown;
        canShoot = false;

        inputManager.fire.performed += Fire;
    }

    void Update()
    {
        if (hasShot == true)
        {
            playerData.weaponCooldown += Time.deltaTime;
        }

        if (playerData.weaponCooldown >= _cooldownValue)
        {
            hasShot = false;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
        Shoot();
    }

    public void Shoot() //Accessed by Input System
    {
        if (hasShot == false)
        {
            rocketLauncherAnimator.Play("Fire");
            GameObject rocket = GameObject.Instantiate(_rocketPrefab, pivot.transform.position, Quaternion.identity);
            rocket.GetComponent<Rocket>().pivot = pivot;
            playerData.weaponCooldown = 0;
            hasShot = true;
        }
    }
}
