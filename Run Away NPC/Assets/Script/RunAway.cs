using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform chaser = null;
    [SerializeField] private float displacementDist = 5f;

    void Start()
    {
        if (agent == null)
            if (!TryGetComponent(out agent))
                Debug.LogWarning(name + " Needs a navmesh agent");
    }

    private void Update()
    {
        if (chaser == null)
            return;

        Vector3 normDir = (chaser.position - transform.position).normalized;

        normDir = Quaternion.AngleAxis(Random.Range(0,179), Vector3.up) * normDir;

        MoveToPos(transform.position - (normDir * displacementDist));

    }

    private void MoveToPos(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }


    /*private void Update()
    {
        Gizmos.color = Color.red;

        Vector3 direction = (chaser.position - transform.position).normalized; //dir

        float mag = direction.magnitude; //will be one
        print(mag);

        Gizmos.DrawLine(transform.position, transform.position + direction);
    }*/
}
