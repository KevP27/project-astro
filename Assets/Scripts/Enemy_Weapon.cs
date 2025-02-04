using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float CooldownTime;
    float cooldownUntilNextPress;
    bool press = false;

    void Update()
    {
        if (cooldownUntilNextPress < Time.time)
        {
            cooldownUntilNextPress = Time.time + CooldownTime;
            Shoot();
            press = false;
        }
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
