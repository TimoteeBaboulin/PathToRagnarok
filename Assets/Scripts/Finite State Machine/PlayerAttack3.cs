using UnityEngine;

public class PlayerAttack3 : PlayerState
{
    public float Timer = 0;
    
    public override void Update(InputsTest player, float timeElapsed)
    {
        Timer += timeElapsed;
        Debug.Log("Updating PlayerAttack3");
    }
    
    public override void Start(InputsTest player)
    {
        Timer = 0;
        player.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    
    public override void Exit(InputsTest player)
    {
        Debug.Log("Exiting PlayerAttack3");
    }

    public override bool CheckTransition(out PlayerState state)
    {
        if (Timer > 3)
        {
            state = Idle;
            return true;
        }

        state = null;
        return false;
    }
}