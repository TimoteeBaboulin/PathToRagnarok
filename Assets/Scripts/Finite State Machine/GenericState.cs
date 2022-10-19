using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
    public abstract class GenericState
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public bool IsActive = true;
        
        protected GenericState(int id = 0, string name = "Unnamed State")
        {
            ID = id;
            Name = name;
        }
        
        public abstract void Start();
        public abstract void Update();
        public abstract void Exit();
    }
}
