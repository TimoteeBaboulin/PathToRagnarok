using UnityEngine;

public class PlayerState
{
    public static PlayerAttack1 Attack1 = new PlayerAttack1();
    public static PlayerAttack2 Attack2 = new PlayerAttack2();
    public static PlayerAttack3 Attack3 = new PlayerAttack3();
    public static PlayerIdle Idle = new PlayerIdle();

    public virtual void Update(InputsTest player, float timeElapsed)
    {
        Debug.Log("Updating PlayerState");
    }
    
    public virtual void Start(InputsTest player)
    {
        Debug.Log("Starting PlayerState");
    }
    
    public virtual void Exit(InputsTest player)
    {
        Debug.Log("Exiting PlayerState");
    }

    //
    public virtual bool Dodge(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool LightAttack(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool HeavyAttack(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool Consumable(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool Rune(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool Rage(out PlayerState state)
    {
        state = null;
        return false;
    }

    public virtual bool CheckTransition(out PlayerState state)
    {
        state = null;
        return false;
    }
}

public class PlayerIdle : PlayerState
{
    public override void Update(InputsTest player, float timeElapsed)
    {
        Debug.Log("Idling");
    }

    public override void Start(InputsTest player)
    {
        player.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public override bool LightAttack(out PlayerState state)
    {
        state = Attack1;
        return true;
    }
}