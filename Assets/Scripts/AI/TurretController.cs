using UnityEngine;

public class TurretController : MonoBehaviour
{
    public BaseState currentState;

    private void Start()
    {
        ChangeState(new IdleState());
    }

    void Update()
    {

        if (currentState != null)
        {
            currentState.OnStateRun();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;
        currentState.controller = this;


        currentState.OnStateEnter();

    }


}
