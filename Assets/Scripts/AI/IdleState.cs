using UnityEngine;

public class IdleState : BaseState
{
    private PlayerInput player;
    public override void OnStateEnter()
    {
        player = GameManager.Instance.GetPlayer();

        Debug.Log("Play animation");
    }

    public override void OnStateRun()
    {
        if( Vector3.Distance(controller.transform.position, player.transform.position) < 6f)
        {
            controller.ChangeState( new AimingState( player.transform ) );
        }

        Debug.Log("Check for target nearby");
    }

    public override void OnStateExit()
    {
        Debug.Log("Nothing");
    }
}
