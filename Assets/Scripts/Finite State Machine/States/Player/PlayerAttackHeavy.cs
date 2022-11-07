using UnityEngine;

public class PlayerAttackHeavy : PlayerState{
    
    private readonly float _totalTime = 2.5f;

    private const int AnimationFrameCount = 104;
    
    public override void Start(Player player){
        base.Start(player);
        
        player.Animator.SetBool("HeavyAttack", true);
        player.Animator.speed = (AnimationFrameCount / (float) 60) / _totalTime;
        
        player.LoseStamina(25);
    }
    
    public override bool CheckTransition(out PlayerState state){
        AnimatorStateInfo info = _player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("AttackHeavy") && info.normalizedTime >= 0.8f){
            _player.Animator.SetBool("HeavyAttack", false);
            state = Idle;
            return true;
        }
        
        state = null;
        return false;
    }
}