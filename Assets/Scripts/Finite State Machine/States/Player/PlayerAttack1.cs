using UnityEngine;

public class PlayerAttack1 : PlayerState{
    private readonly float _totalTime = 1.5f;

    private const int AnimationFrameCount = 100;

    public override void Start(Player player){
        base.Start(player);
        
        player.Animator.SetBool("LightAttack", true);
        player.Animator.speed = (AnimationFrameCount / (float) 60) / _totalTime;
        
        player.LoseStamina(5);
    }

    public override bool InputLightAttack(out PlayerState state){
        AnimatorStateInfo info = _player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("AttackLight") && info.normalizedTime > 0.4f){
            state = Attack2;
            return true;
        }
        return base.InputLightAttack(out state);
    }

    public override bool CheckTransition(out PlayerState state){
        AnimatorStateInfo info = _player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("AttackLight") && info.normalizedTime >= 0.8f){
            _player.Animator.SetBool("LightAttack", false);
            state = Idle;
            return true;
        }
        
        state = null;
        return false;
    }
}