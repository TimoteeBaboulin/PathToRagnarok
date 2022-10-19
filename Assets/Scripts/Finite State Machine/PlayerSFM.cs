using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFM
{
    public PlayerState _currentState { get; private set; }
    private InputsTest _player = null;

    public PlayerSFM(InputsTest player)
    {
        _player = player;
        _currentState = PlayerState.Idle;
        _currentState.Start(_player);
    }
    
    public void ChangeState(PlayerState state)
    {
        if (state == null || state == _currentState) return;
        _currentState.Exit(_player);
        _currentState = state;
        _currentState.Start(_player);
    }

    public void Update(float timeElapsed)
    {
        _currentState.Update(_player, timeElapsed);
        if (_currentState.CheckTransition(out PlayerState state))
            ChangeState(state);
    }

    public void LightAttack()
    {
        if (_currentState.LightAttack(out PlayerState state))
            ChangeState(state);
    }
}
