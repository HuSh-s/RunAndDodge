using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character_Child : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;

    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestinationPoint;
    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpikeBox"))
        {
            GameManager.CurrentCharacterCount--;
            gameObject.SetActive(false);
        }
    }
}
