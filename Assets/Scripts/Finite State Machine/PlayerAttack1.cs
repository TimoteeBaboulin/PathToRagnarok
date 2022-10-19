using UnityEngine;

public class PlayerAttack1 : PlayerState
{
    public override void Update(InputsTest player, float timeElapsed)
    {
        Debug.Log("Updating PlayerAttack1");
    }
    
    public override void Start(InputsTest player)
    {
        player.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    
    public override void Exit(InputsTest player)
    {
        Debug.Log("Exiting PlayerAttack1");
    }

    public override bool LightAttack(out PlayerState state)
    {
        state = Attack2;
        return true;
    }
}