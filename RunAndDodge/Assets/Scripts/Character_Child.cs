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
            Vector3 newPos = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect_Create(newPos);
            gameObject.SetActive(false);
        }
    }
}
