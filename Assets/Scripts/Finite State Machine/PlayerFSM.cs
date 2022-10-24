public class PlayerFSM{
    private readonly Player _player;

    public PlayerFSM(Player player){
        _player = player;
        CurrentState = PlayerState.Idle;
        CurrentState.Start(_player);
    }

    public PlayerState CurrentState{ get; private set; }

    public void ChangeState(PlayerState state){
        if (state == null || state == CurrentState) return;
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Start(_player);
    }

    public void Update(float timeElapsed){
        CurrentState.Update(timeElapsed);
        if (CurrentState.CheckTransition(out var state))
            ChangeState(state);
    }

    public void LightAttack(){
        if (CurrentState.InputLightAttack(out var state))
            ChangeState(state);
    }

    public void Block(){
        if (CurrentState.InputBlock(out var state))
            ChangeState(state);
    }

    public void Rage(){
        if (CurrentState.InputRage(out var state))
            ChangeState(state);
    }

    public void Dodge(){
        if (CurrentState.InputDodge(out var state))
            ChangeState(state);
    }
    
    public void HeavyAttack(){
        if (CurrentState.InputHeavyAttack(out var state))
            ChangeState(state);
    }
    
    public void UseConsumable(){
        if (CurrentState.InputConsumable(out var state))
            ChangeState(state);
    }
    
    public void UseRune(){
        if (CurrentState.InputRune(out var state))
            ChangeState(state);
    }
}