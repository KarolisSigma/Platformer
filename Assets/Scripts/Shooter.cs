using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioClip shootSound;
    public AudioClip emptyshotSound;

    public float coolDown = 0.5f;

    private float lastShotTime;
    private AudioSource audioSource;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time - lastShotTime > coolDown){
                lastShotTime = Time.time;
                
                audioSource.PlayOneShot(shootSound);
                var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                var direction = (mousePos - transform.position).normalized;

                var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.transform.rotation).GetComponent<Bullet>();
                bullet.direction = direction;
            }
            else{
                audioSource.PlayOneShot(emptyshotSound);
            }
        }

    }
}
