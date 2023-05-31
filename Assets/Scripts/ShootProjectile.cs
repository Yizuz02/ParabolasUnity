using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public GameObject shooter;
    public GameObject bulletPrefab;
    public InputField stringInitialVelocity;
    public InputField stringAngle;

    public float initialVelocity = 0f;
    public float angle = 0f; 
    private Transform _firePoint;
    
    void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null){
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
        }
        initialVelocity = float.Parse(stringInitialVelocity.text);
        angle = float.Parse(stringAngle.text);
    }
}
