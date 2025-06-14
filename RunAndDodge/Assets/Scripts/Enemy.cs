using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Attack_Target;
    NavMeshAgent _Navmesh;
    bool Attack_Start;

    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }

    public void Animation_Trigger()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Attack_Start = true;
    }

    private void LateUpdate()
    {
        if (Attack_Start)
        {
            _Navmesh.SetDestination(Attack_Target.transform.position);
        }
    }
}
