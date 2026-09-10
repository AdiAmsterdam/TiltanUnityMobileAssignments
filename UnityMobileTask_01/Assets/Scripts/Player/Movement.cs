using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private float speed = 200;
    void Start()
    {
        
    }
    
    void Update()
    {
        Move();
        MouseMove();
    }

    private void Move()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed) , Space.World);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.Translate(-Vector3.forward * (Time.deltaTime * speed) , Space.World);
        }
        
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed) , Space.World);
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(-Vector3.right * (Time.deltaTime * speed) , Space.World);
        }
    }
    
    private void MouseMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);

            Vector3 direction = mouseWorldPosition - transform.position;
            direction.y = 0f;

            transform.forward = direction;
        }
    }
}
