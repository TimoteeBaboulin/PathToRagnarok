using System.Collections;
using System.Collections.Generic;
using FiniteStateMachine;
using UnityEngine;

public class GameFiniteStateMachine
{
    private GenericState _currentState = null;
    private List<GenericState> _states = new List<GenericState>();

    public void AddState(GenericState state)
    {
        _states.Add(state);
        if (_currentState == null) _currentState = state;
    }

    public void RemoveState(GenericState state)
    {
        _states.Remove(state);
    }

    public GenericState GetState(int ID)
    {
        if (_states.Count > ID) return _states[ID];
        return null;
    }

    public GenericState GetCurrentState()
    {
        return _currentState;
    }

    public void Update()
    {
        if (_currentState.IsActive)
        {
            _currentState.Update();
            return;
        }

        foreach (var state in _states)
        {
            if (_currentState != state)
            {
                ChangeState(state);
                break;
            }
        }
    }

    public void ChangeState(GenericState state)
    {
        if (!_states.Contains(state)) return;
        if (_currentState == state) return;
        
        _currentState.Exit();
        _currentState = state;
        _currentState.Start();
    }
}
