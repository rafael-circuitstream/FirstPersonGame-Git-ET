using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform goal;

    void Start()
    {
        InvokeRepeating("UpdateDestination", 0.5f, 0.5f);
    }

    void UpdateDestination()
    {
        agent.SetDestination(goal.position);
    }

    private void Update()
    {
        if(Vector3.Distance(goal.position, transform.position) < 1f)
        {
            //ATTACK THE PLAYER;
        }
    }

}
