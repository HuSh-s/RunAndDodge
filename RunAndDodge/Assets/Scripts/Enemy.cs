using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Attack_Target;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    bool Attack_Start;
    public GameManager _GameManager;

    public void Animation_Trigger()
    {
        _Animator.SetBool("Attack", true);
        Attack_Start = true;
    }

    private void LateUpdate()
    {
        if (Attack_Start)
        {
            _Navmesh.SetDestination(Attack_Target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("CharChild"))
        {
            Vector3 newPos = new Vector3(transform.position.x, .23f, transform.position.z);

            _GameManager.DestroyEffect_Create(newPos, false, true);
            gameObject.SetActive(false);
        }
    }
}
