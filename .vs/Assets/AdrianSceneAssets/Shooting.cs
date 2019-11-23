using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPreFab;
    public Transform shotPoint1;
    public Transform shotPoint2;
    public Transform shotPoint3;
    public Transform shotPoint4;

    public bool hasShotgun = false;
    public bool hasFrenzy = false;
    public bool isReloading = false;
    

    public float BulletForce = 20f;
    public int ClipSize = 5;
    
    void Update()
    {
        if (ClipSize > 0 && isReloading==false) 
        {
            if (hasFrenzy == true)
            {
                
                if (Input.GetButton("Fire1"))
                {
                    Shoot();
                    if (ClipSize == 0)
                        hasFrenzy = false;
                }
            }
            else
            {
                if (hasShotgun == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Shotgun();
                        
                        if (ClipSize == 0)
                            hasShotgun = false;
                    }
                }
                else
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Shoot();
                        

                    }
                }

            }
        }
        else if (ClipSize == 0 && isReloading == false)
        {
            isReloading = true;
            StartCoroutine (ReloadTimer());
            
        }

        
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        ClipSize -= 1;
    }

    void Shotgun()
    {
        GameObject Bullet1 = Instantiate(BulletPreFab, shotPoint1.position, firePoint.rotation);
        GameObject Bullet2 = Instantiate(BulletPreFab, shotPoint2.position, firePoint.rotation);
        GameObject Bullet3 = Instantiate(BulletPreFab, firePoint.position, firePoint.rotation);
        GameObject Bullet4 = Instantiate(BulletPreFab, shotPoint3.position, firePoint.rotation);
        GameObject Bullet5 = Instantiate(BulletPreFab, shotPoint4.position, firePoint.rotation);

        Rigidbody2D rb1 = Bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = Bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = Bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = Bullet4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb5 = Bullet5.GetComponent<Rigidbody2D>();

        rb1.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        rb4.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        rb5.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
        ClipSize -= 1;
    }

    IEnumerator ReloadTimer()
    {
        
        yield return new WaitForSecondsRealtime(2);
        ClipSize = 5;
        isReloading = false;
        
    }
    IEnumerator FrenzyTimer()
    {
        ClipSize = 500;
        yield return new WaitForSecondsRealtime(5);
        ClipSize = 0;
        hasFrenzy = false;

    }



}
