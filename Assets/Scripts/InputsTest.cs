using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsTest : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    
    public float Speed = 5;

    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newMovement = new Vector3(movement.x, 0 , movement.y);
        transform.position += newMovement * Speed * Time.deltaTime;
    }
}
