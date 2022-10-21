using UnityEngine;

public class PlayerBlock : PlayerState{
    private float _timer;

    public override void Start(Player player){
        base.Start(player);
        _timer = 0;
        player.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public override void Update(float timeElapsed){
        _timer += timeElapsed;
    }

    public override bool InputBlock(out PlayerState state){
        state = Idle;
        return true;
    }

    public override bool CheckTransition(out PlayerState state){
        if (_timer >= 1){
            state = BlockLazy;
            return true;
        }

        return base.CheckTransition(out state);
    }
}