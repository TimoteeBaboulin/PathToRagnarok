using UnityEngine;

public class PlayerBlockLazy : PlayerState{
    private float _staminaLoss;
    
    public override void Start(Player player){
        base.Start(player);
        player.GetComponent<MeshRenderer>().material.color = Color.grey;
    }

    public override bool InputBlock(out PlayerState state){
        state = Idle;
        return true;
    }

    public override void Update(float timeElapsed){
        _player.LoseStamina(timeElapsed * _staminaLoss);
    }

    public override bool CheckTransition(out PlayerState state){
        if (_player.Stamina > 0){
            return base.CheckTransition(out state);
        }

        state = Idle;
        return true;
    }
}