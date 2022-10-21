using UnityEngine;

public class PlayerBlockLazy : PlayerState{
    public override void Start(Player player){
        base.Start(player);
        player.GetComponent<MeshRenderer>().material.color = Color.grey;
    }

    public override bool InputBlock(out PlayerState state){
        state = Idle;
        return true;
    }
}