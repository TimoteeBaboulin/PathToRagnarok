using UnityEngine;

public class PlayerState{
    public static readonly PlayerAttack1 Attack1 = new();
    public static readonly PlayerAttack2 Attack2 = new();
    public static readonly PlayerAttack3 Attack3 = new();

    public static readonly PlayerAttackHeavy AttackHeavy = new();
    public static readonly PlayerAttackHeavyCharged AttackHeavyCharged = new();

    public static readonly PlayerBlock Block = new();
    public static readonly PlayerBlockLazy BlockLazy = new();
    public static readonly PlayerParry Parry = new();

    public static readonly PlayerConsumable Consumable = new();
    public static readonly PlayerRage Rage = new();
    public static readonly PlayerRune Rune = new();

    public static readonly PlayerDeath Death = new();
    public static readonly PlayerDodge Dodge = new();

    public static readonly PlayerHitStun HitStun = new();
    public static readonly PlayerIdle Idle = new();

    protected Player _player;

    public virtual void Update(float timeElapsed){ }

    public virtual void Start(Player player){
        _player = player;
    }

    public virtual void Exit(){ }

    public virtual bool InputDodge(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputLightAttack(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputHeavyAttack(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputConsumable(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputRune(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputRage(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool InputBlock(out PlayerState state){
        state = null;
        return false;
    }

    public virtual bool CheckTransition(out PlayerState state){
        state = null;
        return false;
    }
}