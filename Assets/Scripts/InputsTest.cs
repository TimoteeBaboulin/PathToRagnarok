using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsTest : MonoBehaviour
{
    private Vector2 _movement = Vector2.zero;
    private bool _block = false;
    
    public float Speed = 5;

    public void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    public void OnBlock(InputValue value)
    {
        _block = !_block;

        if (_block)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            return;
        }
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newMovement = new Vector3(_movement.x, 0 , _movement.y);
        transform.position += newMovement * Speed * Time.deltaTime;
    }
}
