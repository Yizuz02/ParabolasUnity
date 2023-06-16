using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
using TMPro;

public class ShootProjectile : MonoBehaviour
{
    public int numBullets = 3;
    public GameObject shooter;
    public GameObject bulletPrefab;
    public InputField stringInitialVelocity;
    public InputField stringAngle;
    public TextMeshProUGUI numBulletsText;

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
        numBulletsText.text = "X " + numBullets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void Shoot()
    {
        //Crea la bala adelante del cañon
        if (bulletPrefab != null && _firePoint != null && numBullets>0){
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            //Al crearse una nueva bala se resta el numero de balas del jugador y se actualiza el contador
            numBullets--;
            numBulletsText.text = "X " + numBullets;
        }
        // Obtiene los valoes de velocidad inicial y angulo que se encuentren en las cajas de texto
        initialVelocity = float.Parse(stringInitialVelocity.text);
        angle = float.Parse(stringAngle.text);
    }
}
