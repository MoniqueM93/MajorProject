using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (AmmoText.ammoAmount > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        AmmoText.ammoAmount -= 1;
        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;
    }
}
