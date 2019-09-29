using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;

    public bool isUpgraded;

    public float upgradeTime = 10.0f;

    private AudioSource audioSource;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //to shoot
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0)) //knows when user releases the mouse button to stop firing gun
        {
            CancelInvoke("fireBullet");
        }

        currentTime += Time.deltaTime; //increments time
        if (currentTime > upgradeTime && isUpgraded == true)
        {
            isUpgraded = false;
        }
    }

    private Rigidbody createBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        return bullet.GetComponent<Rigidbody>();
    }
    void fireBullet()
    {
        Rigidbody bullet = createBullet();
        bullet.velocity = transform.parent.forward * 100;

        /*
        // 1
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        // 2
        bullet.transform.position = launchPosition.position;
        // 3
        bullet.GetComponent<Rigidbody>().velocity =
        transform.parent.forward * 100;
        */

        audioSource.PlayOneShot(SoundManager.Instance.gunFire);

        if (isUpgraded)
        {
            Rigidbody bullet2 = createBullet();
            bullet2.velocity = (transform.right + transform.forward / 0.5f) * 100;
            Rigidbody bullet3 = createBullet();
            bullet3.velocity = ((transform.right * -1) + transform.forward / 0.5f) * 100;
        }
        if (isUpgraded)
        {
            audioSource.PlayOneShot(SoundManager.Instance.upgradedGunFire);
        }
        else
        {
            audioSource.PlayOneShot(SoundManager.Instance.gunFire);
        }
    }
    public void UpgradeGun()
    {
        isUpgraded = true;
        currentTime = 0;
    }
}
