using UnityEngine;

namespace FiniteStateMachine
{
    public class ConcreteState : GenericState
    {
        public ConcreteState(int ID = 0, string name = "Unnamed State") : base(ID, name)
        {
        }
        
        public override void Start()
        {
            IsActive = true;
            Debug.Log("My name is " + Name + ", My ID is " + ID + ", and I just started.");
        }

        public override void Update()
        {
            if (Random.Range(0f, 1f) > 0.7f)
                IsActive = !IsActive;
            
            if (!IsActive) return;
            //Debug.Log("My name is " + Name + ", My ID is " + ID + ", and I am updating.");
        }

        public override void Exit()
        {
            Debug.Log("My name is " + Name + ", My ID is " + ID + ", and I just exited.");
        }
    }
}