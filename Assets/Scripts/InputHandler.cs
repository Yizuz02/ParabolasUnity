using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Camera _mainCamera;
    private ShootProjectile _projectile;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;
        
        Debug.Log(rayHit.collider.gameObject.name);

        if (rayHit.collider.gameObject.tag == "LaunchButton"){
            Debug.Log("uwu");
            //_projectile = GameObject.FindWithTag("Projectile").GetComponent<ShootProjectile>();
            //_projectile.Launch();
        }
    }
}