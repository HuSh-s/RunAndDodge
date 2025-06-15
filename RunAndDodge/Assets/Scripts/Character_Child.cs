using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character_Child : MonoBehaviour
{
    NavMeshAgent _Navmesh;
    public GameManager _GameManager;
    public GameObject Target;

    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    Vector3 GivePosition()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpikeBox"))
        {
            _GameManager.DestroyEffect_Create(GivePosition());
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Saw"))
        {
            _GameManager.DestroyEffect_Create(GivePosition());
            gameObject.SetActive(false);
        }
        
        else if (other.CompareTag("PropellerSpikes"))
        {
            _GameManager.DestroyEffect_Create(GivePosition());
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Hammer"))
        {
            _GameManager.DestroyEffect_Create(GivePosition(), true);
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Enemy"))
        {
            _GameManager.DestroyEffect_Create(GivePosition(), false, false);
            gameObject.SetActive(false);
        }
    }
}
