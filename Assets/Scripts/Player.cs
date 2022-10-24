using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{

    public static event Action<float> OnStaminaChange;
    
    //Player Stats
    public float Speed = 5;
    private float _stamina = 100;
    public float Stamina{
        get => _stamina;
    }

    [SerializeField] private float _heavyAttackDelay = 0.5f;
    [SerializeField] private GameObject _cameraAnchor;

    private Animator _animator;
    public Animator Animator{ get => _animator; }
    
    private bool _block = false;
    private Vector2 _cameraMovement = Vector2.zero;
    private bool _heavy;
    private Vector2 _movement = Vector2.zero;
    private PlayerFSM FSM;

    private void Start(){
        _animator = GetComponent<Animator>();
        FSM = new PlayerFSM(this);
    }

    // Update is called once per frame
    private void Update(){
        FSM.Update(Time.deltaTime);

        var newMovement =
            _cameraAnchor.transform.forward * _movement.y + _cameraAnchor.transform.right * _movement.x;
        newMovement.y = 0;
        newMovement.Normalize();
        transform.position += newMovement * Speed * Time.deltaTime;

        if (_cameraAnchor == null) return;
        var cameraRotation = _cameraAnchor.transform.rotation.eulerAngles;
        cameraRotation.x += _cameraMovement.y;
        cameraRotation.y += _cameraMovement.x;
        _cameraAnchor.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    public void LoseStamina(float staminaLoss){
        _stamina -= staminaLoss;
        if (_stamina < 0) _stamina = 0;
        OnStaminaChange?.Invoke(_stamina);
    }

    public void OnMovement(InputValue value){
        _movement = value.Get<Vector2>();
    }

    public void OnCameraMovement(InputValue value){
        _cameraMovement = value.Get<Vector2>();
    }

    public void OnBlock(){
        Debug.Log("Block");
        Block();
    }

    public void OnLightAttack(){
        LightAttack();
    }

    public void OnHeavyAttack(InputValue value){
        var isPressed = value.Get<float>() > 0;

        if (isPressed && !_heavy){
            StartCoroutine(HeavyAttackCoroutine());
        }
        else if (!isPressed && _heavy){
            StopAllCoroutines();
            HeavyAttack();
        }

        _heavy = isPressed;
    }

    public void OnDodge(){
        Dodge();
    }

    public void OnConsumable(){
        UseConsumable();
    }

    public void OnRune(){
        UseRune();
    }

    public void OnRage(){
        Rage();
    }

    private void HeavyAttack(){
        Debug.Log("Heavy Attack");
    }

    private void LightAttack(){
        FSM.LightAttack();
    }

    private void Dodge(){
        Debug.Log("Dodge");
    }

    private void UseConsumable(){
        Debug.Log("Consumable");
    }

    private void UseRune(){
        Debug.Log("Rune");
    }

    private void Rage(){
        FSM.Rage();
    }

    private void Block(){
        FSM.Block();
    }

    private IEnumerator HeavyAttackCoroutine(){
        yield return new WaitForSeconds(_heavyAttackDelay);

        if (_heavy)
            Debug.Log("Charged Heavy Attack");

        _heavy = false;
    }
}