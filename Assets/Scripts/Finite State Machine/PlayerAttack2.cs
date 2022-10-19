using UnityEngine;

public class PlayerAttack2 : PlayerState
{
    public override void Update(InputsTest player, float timeElapsed)
    {
        Debug.Log("Updating PlayerAttack2");
    }
    
    public override void Start(InputsTest player)
    {
        player.GetComponent<MeshRenderer>().material.color = Color.cyan;
    }
    
    public override void Exit(InputsTest player)
    {
        Debug.Log("Exiting PlayerAttack2");
    }
    
    public override bool LightAttack(out PlayerState state)
    {
        state = Attack3;
        return true;
    }
}