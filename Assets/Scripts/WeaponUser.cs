using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    public LayerMask projectileLayer;
    
    public Weapon currentWeapon;
    public AimDirection aimDirection;
    public GameObject shootObject;

    public GameObject itemPickupPrefab;
    
    public void Attack()
    {
        currentWeapon.Attack(this);
    }

    public void Equip(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Equip(this);
    }

    public void Unequip()
    {
        if (currentWeapon == null) return;


        var itemPickupGO = Instantiate(itemPickupPrefab, transform.position, quaternion.identity);
        var itemPickup = itemPickupGO.GetComponent<ItemPickup>();
        Debug.Log($"Unequipped {currentWeapon.name}!", itemPickupGO);
        itemPickup.item = currentWeapon;
        itemPickup.itemCollider.enabled = false;
        itemPickup.DelayEnableCollider();
        
        currentWeapon.Unequip(this);
    }

    private void Update()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, aimDirection.Direction);
    }
}
