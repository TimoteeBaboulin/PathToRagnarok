using UnityEngine;

public class PlayerAttack3 : PlayerState{
    private float _timer;

    public override void Update(float timeElapsed){
        _timer += timeElapsed;
    }

    public override void Start(Player player){
        base.Start(player);
        player.LoseStamina(10);
        _timer = 0;
        player.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public override void Exit(){
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