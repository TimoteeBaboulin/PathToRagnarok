using UnityEngine;

public class PlayerAttack2 : PlayerState{
    private float _totalTime = 1.5f;

    private const int AnimationFrameCount = 80;

    public override void Start(Player player){
        base.Start(player);
        
        //player.Animator.SetBool("LightAttack", true);
        player.Animator.speed = (AnimationFrameCount / (float) 60) / _totalTime;
        player.LoseStamina(10);
    }

    public override bool InputLightAttack(out PlayerState state){
        AnimatorStateInfo info = _player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("AttackLightCombo1") && info.normalizedTime > 0.4f){
            state = Attack3;
            return true;
        }
        return base.InputLightAttack(out state);
    }

    public override bool CheckTransition(out PlayerState state){
        AnimatorStateInfo info = _player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("AttackLightCombo1") && info.normalizedTime >= 0.8f){
            state = Idle;
            _player.Animator.SetBool("LightAttack", false);
            return true;
        }
        
        state = null;
        return false;
    }
}