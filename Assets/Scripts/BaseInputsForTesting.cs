using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseInputsForTesting : MonoBehaviour
{
    public float Speed = 5;

    [SerializeField] private float _heavyAttackDelay = 0.5f;
   [SerializeField] private GameObject _cameraAnchor = null;
    private Vector2 _movement = Vector2.zero;
    private Vector2 _cameraMovement = Vector2.zero;
    private bool _block = false;
    private bool _heavy = false;

    public void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    public void OnCameraMovement(InputValue value)
    {
        _cameraMovement = value.Get<Vector2>();
    }

    public void OnBlock()
    {
        _block = !_block;

        if (_block)
        {
            Debug.Log("Blocking");
            GetComponent<MeshRenderer>().material.color = Color.red;
            return;
        }
        Debug.Log("Not blocking");
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void OnLightAttack()
    {
        LightAttack();
    }

    public void OnHeavyAttack(InputValue value)
    {
        bool isPressed = value.Get<float>() > 0;

        if (isPressed && !_heavy)
        {
            StartCoroutine(HeavyAttackCoroutine());
        }
        else if (!isPressed && _heavy)
        {
            StopAllCoroutines();
            HeavyAttack();
        }

        _heavy = isPressed;
    }

    public void OnDodge()
    {
        Dodge();
    }

    public void OnConsumable()
    {
        UseConsumable();
    }

    public void OnRune()
    {
        UseRune();
    }

    public void OnRage()
    {
        Rage();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newMovement = _cameraAnchor.transform.forward * _movement.y + _cameraAnchor.transform.right * _movement.x;
        newMovement.y = 0;
        newMovement.Normalize();
        transform.position += newMovement * Speed * Time.deltaTime;

        /* if (_cameraAnchor == null) return;
         Vector3 cameraRotation = _cameraAnchor.transform.rotation.eulerAngles;
         cameraRotation.x += _cameraMovement.y;
         cameraRotation.y += _cameraMovement.x;
         _cameraAnchor.transform.rotation = Quaternion.Euler(cameraRotation);*/
    }

    private void HeavyAttack()
    {
        Debug.Log("Heavy Attack");
    }

    private void LightAttack()
    {
        Debug.Log("Light Attack");
    }

    private void Dodge()
    {
        Debug.Log("Dodge");
    }

    private void UseConsumable()
    {
        Debug.Log("Consumable");
    }

    private void UseRune()
    {
        Debug.Log("Rune");
    }

    private void Rage()
    {
        Debug.Log("Rage");
    }

    IEnumerator HeavyAttackCoroutine()
    {
        yield return new WaitForSeconds(_heavyAttackDelay);
        
        if (_heavy)
            Debug.Log("Charged Heavy Attack");
        
        _heavy = false;
    }
}
