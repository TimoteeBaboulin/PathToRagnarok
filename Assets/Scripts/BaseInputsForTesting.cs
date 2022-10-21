using UnityEngine;
using UnityEngine.InputSystem;

public class BaseInputsForTesting : MonoBehaviour{
    public float Speed = 5;
    private Vector2 movement = Vector2.zero;

    // Update is called once per frame
    private void Update(){
        var newMovement = new Vector3(movement.x, 0, movement.y);
        transform.position += newMovement * Speed * Time.deltaTime;
    }

    public void OnMovement(InputValue value){
        movement = value.Get<Vector2>();
    }
}