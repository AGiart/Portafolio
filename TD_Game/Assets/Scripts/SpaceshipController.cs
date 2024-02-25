
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpaceshipController : MonoBehaviour
{

    [SerializeField]
    float speed = 9.0F;
    [SerializeField]
    Transform torret;

    [SerializeField]
    HealthBarController healthController;

    Rigidbody2D _rigidbody;

    Vector2 _direction;
    Vector2 _mousePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInputMousePosition();
        HandleInputDirection();
    }
    
    private void FixedUpdate()
    {
        HandleTorretRotation();
        if (_direction.sqrMagnitude == 0.0F) 
        {
            return;
        }
        _direction.Normalize();
        _rigidbody.MovePosition(_rigidbody.position + _direction * speed * Time.fixedDeltaTime);

        HandleRotation();
        

    }

    private void HandleInputDirection()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void HandleInputMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void HandleTorretRotation()
    {
        Vector2 up = new Vector2(_mousePosition.x - torret.position.x, _mousePosition.y - torret.position.y);
        torret.up = up;
    }

    private void HandleRotation()
    {
        float angle = 
            _direction.x > 0.0F && _direction.y == 0.0F 
            ? 90.0F // Derecha
            : _direction.x < 0.0F && _direction.y == 0.0F                
                ? 270.0F // Izquierda
                : _direction.x > 0.0F && _direction.y > 0.0F                    
                    ? 45.0F // Diagonal Superior Derecha
                    : _direction.x < 0.0F && _direction.y > 0.0F                        
                        ? 315.0F // Diagonal Superior Izquierda
                        : _direction.x == 0 && _direction.y > 0                            
                            ? 0.0F // Superior
                            : _direction.x == 0 && _direction.y < 0                                
                                ? 180.0F // Inferior
                                : _direction.x > 0.0F && _direction.y < 0.0F                                    
                                    ? 135.0F // Diagonal Inferior Derecha
                                    : 225.0F; // Diagonal Inferior Izquierda
        transform.rotation = Quaternion.Euler(0.0F, 0.0F, -angle);}

    public void takeDamage(float damage)
    {
        healthController.UpdateHealth(-Mathf.Abs(damage));
    }
}
