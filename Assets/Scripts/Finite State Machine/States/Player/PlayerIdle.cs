using UnityEngine;

public class PlayerIdle : PlayerState{
    public override void Start(Player player){
        base.Start(player);
        player.Animator.speed = 1;
    }

    public override bool InputDodge(out PlayerState state){
        if (_player.Stamina < 5){
            return base.InputDodge(out state);
        }
        state = Dodge;
        return true;
    }

    public override bool InputLightAttack(out PlayerState state){
        if (_player.Stamina < 5){
            return base.InputLightAttack(out state);
        }
        state = Attack1;
        return true;
    }

    public override bool InputHeavyAttack(out PlayerState state){
        if (_player.Stamina < 25){
            return base.InputHeavyAttack(out state);
        }
        state = AttackHeavy;
        return true;
    }

    public override bool InputConsumable(out PlayerState state){
        state = Consumable;
        return true;
    }

    public override bool InputRune(out PlayerState state){
        state = Rune;
        return true;
    }

    public override bool InputRage(out PlayerState state){
        state = Rage;
        return true;
    }

    public override bool InputBlock(out PlayerState state){
        state = Block;
        return true;
    }
}