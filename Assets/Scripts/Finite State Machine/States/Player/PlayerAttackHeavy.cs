using UnityEngine;

public class PlayerAttackHeavy : PlayerState{
    public override void Start(Player player){
        base.Start(player);
        player.LoseStamina(25);
    }
}