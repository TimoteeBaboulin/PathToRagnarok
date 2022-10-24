using UnityEngine;

public class PlayerAttack3 : PlayerState{
    private float _timer;
    private float _totalTime = 1.5f;
    private float _transitionTime = 0.2f;
    
    private const int _animationFrameCount = 80;

    public override void Update(float timeElapsed){
        _timer += timeElapsed;
    }

    public override void Start(Player player){
        base.Start(player);
        
        player.Animator.CrossFadeInFixedTime("AttackLightCombo2", _transitionTime);
        player.Animator.speed = (_animationFrameCount / (float) 60) / _totalTime;
        player.LoseStamina(10);
        
        _timer = 0;
    }

    public override bool InputLightAttack(out PlayerState state){
        if (_player.Stamina < 10){
            return base.InputLightAttack(out state);
        }
        state = Attack2;
        return true;
    }

    public override bool CheckTransition(out PlayerState state){
        if (_timer > _totalTime + _transitionTime){
            state = Idle;
            return true;
        }

        state = null;
        return false;
    }
}