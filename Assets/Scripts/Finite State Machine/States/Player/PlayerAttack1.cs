using UnityEngine;

public class PlayerAttack1 : PlayerState{
    private float _timer;

    public override void Update(float timeElapsed){
        _timer += timeElapsed;
    }

    public override void Start(Player player){
        base.Start(player);
        player.LoseStamina(5);
        _timer = 0;
        player.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    
    public override bool InputLightAttack(out PlayerState state){
        if (_player.Stamina < 10){
            return base.InputLightAttack(out state);
        }
        state = Attack2;
        return true;
    }

    public override bool CheckTransition(out PlayerState state){
        if (_timer > 3){
            state = Idle;
            return true;
        }

        state = null;
        return false;
    }
}