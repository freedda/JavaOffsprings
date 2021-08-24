    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//We must have always a navmeshagent
[RequireComponent(typeof(NavMeshAgent))]
public class FocusWithClick : MonoBehaviour
{
    //Create a NavMesh Agent Component
    private NavMeshAgent navmesh;
    
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void movementTarget(Vector3 target)
    {
        navmesh.SetDestination(target);
    }
}
