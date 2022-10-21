using UnityEngine;

[CreateAssetMenu(order = 51, fileName = "NewSharedFloat", menuName = "Shared Values/New Shared Float")]
public class SharedFloat : ScriptableObject{
    [SerializeField] private float _value;

    public float Value => _value;
}