using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool isHeldDown = true;

    public LineRenderer lineRenderer;

    public Transform laserFirePoint;
    Transform transform1;

    public AudioSource LaserCannonSound;
    public AudioSource BulletImpactSound;
    public AudioSource BulletImpactSound2;

    public float damageOverTime = 10f;
    public float selfDamage = 0.00001f;
    public GameObject impactEffect;

    public bool press = false;

    private void Awake()
    {
        transform1 = GetComponent<Transform>();
    }

    void Start()
    {
        DisableLaser();
    }

    public void onPress()
    {
        isHeldDown = true;
        Debug.Log(isHeldDown);

        press = true;

        BulletImpactSound.Play();
        LaserCannonSound.loop = true;
        LaserCannonSound.Play();
    }

    void Update()
    {
        if (press == true)
        {
            EnableLaser();
        }
        else
        {
            DisableLaser();
        }
    }

    public void onRelease()
    {
        press = false;

        isHeldDown = false;
        Debug.Log(isHeldDown);

        LaserCannonSound.loop = false;
        LaserCannonSound.Stop();
        BulletImpactSound2.Play();

        DisableLaser();
    }

    void EnableLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, laserFirePoint.right);

        if (hit)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            BulletHealth bulletHealth = hit.transform.GetComponent<BulletHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageOverTime * Time.deltaTime * 5);
            }
            if (bulletHealth != null)
            {
                bulletHealth.TakeDamage(damageOverTime * Time.deltaTime * 5);
            }

            Instantiate(impactEffect, hit.point, Quaternion.identity);

            lineRenderer.SetPosition(0, laserFirePoint.position);
            lineRenderer.SetPosition(1, hit.point);
        }

        else
        {
            lineRenderer.SetPosition(0, laserFirePoint.position);
            lineRenderer.SetPosition(1, laserFirePoint.position + laserFirePoint.right * 100);
        }


        lineRenderer.enabled = true;
    }


    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
