using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{

    StateMachine stateMachine = null;
    NavMeshAgent agent = null;
    Drive seeking = Drive.Nothing;

    void Awake()
    {
        stateMachine = new StateMachine();

        agent = this.GetComponent<NavMeshAgent>();

        // search
        // randomTile
        // moveToTarget
        // consume
        // idle

    }

}
