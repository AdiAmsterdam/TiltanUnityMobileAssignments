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
        
    }
}
