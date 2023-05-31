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
        if (_isGrounded==true && _fallingTimer>0 && _end==false){
            Debug.Log("Tiempo=" + _fallingTimer);
            _fallingTimer = 0;
            _end = true;
            gameObject.tag = null;
            Invoke("ReturnCamera",2f);
        }
    }

    public void Launch()
    {
        initialVelocity = _cannon.GetComponent<ShootProjectile>().initialVelocity;
        angle = _cannon.GetComponent<ShootProjectile>().angle;
        Debug.Log("Velocidad Inicial: " + initialVelocity);
        Debug.Log("Angulo: " + angle);
        _angleRadians = angle * (Mathf.PI/180);
        _velocityX = Mathf.Cos(_angleRadians) * initialVelocity;
        _velocityY = Mathf.Sin(_angleRadians) * initialVelocity;
        Debug.Log("Velocidad en X:"+_velocityX);
        Debug.Log("Velocidad en Y:"+_velocityY);
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
