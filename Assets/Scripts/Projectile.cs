using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private Camera _mainCamera;
    private GameObject _cannon;
    private float initialVelocity = 0f;
    private float angle = 0f; 
    private Rigidbody2D _rigidBody;
    private float _velocityX;
    private float _velocityY;
    private float _angleRadians;
    private float _fallingTimer;
    private bool _isGrounded;
    private bool _end = false;

    void Awake() {
        _cannon = GameObject.Find("Cannon");
        _rigidBody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Launch", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (_isGrounded==false && _end==false){
            _fallingTimer += Time.deltaTime;
            MoveCamera();
        }
        if (_fallingTimer>=5f){
            gameObject.tag = "Untagged";
            _end = true;
            _fallingTimer = 0;
            Invoke("ReturnCamera",2f);
        }
        if (_isGrounded==true && _fallingTimer>0 && _end==false){
            Debug.Log("Tiempo=" + _fallingTimer);
            Debug.Log("Pos2: " + transform.position.x);
            _fallingTimer = 0;
            _end = true;
            gameObject.tag = "Untagged";
            Invoke("ReturnCamera",2f);
        }
    }

    public void Launch()
    {
        //Se recuperan los valores de velocidad inicial y del angulo del otro script
        initialVelocity = _cannon.GetComponent<ShootProjectile>().initialVelocity;
        angle = _cannon.GetComponent<ShootProjectile>().angle;
        //Se imprimen los valores de velocidad inicial, angulo y su posicion inicial
        //en X, todo esto fue usado para pruebas y llevar control de estos valores
        Debug.Log("Velocidad Inicial: " + initialVelocity);
        Debug.Log("Angulo: " + angle);
        Debug.Log("Pos1: " + transform.position.x);
        //Se convierte el valor del angulo a radianes
        _angleRadians = angle * (Mathf.PI/180);
        //Se calcula la velocidad en X y en Y y se imprimen los valores en consola
        //(esto para pruebas)
        _velocityX = Mathf.Cos(_angleRadians) * initialVelocity;
        _velocityY = Mathf.Sin(_angleRadians) * initialVelocity;
        Debug.Log("Velocidad en X:"+_velocityX);
        Debug.Log("Velocidad en Y:"+_velocityY);
        //Se le suman estas velocidades a la bala
        _rigidBody.AddForce(Vector2.right * _velocityX, ForceMode2D.Impulse);
        _rigidBody.AddForce(Vector2.up * _velocityY, ForceMode2D.Impulse);
    }

    private void MoveCamera()
    {
        _mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -5); 
    }

    private void ReturnCamera()
    {
        _mainCamera.transform.position = new Vector3(0, 0, -10);
    }
}
