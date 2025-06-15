using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FreeChar : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material TargetMaterial;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameObject Target;
    bool Touch;

    private void LateUpdate()
    {
        if(Touch)
            _Navmesh.SetDestination(Target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CharChild") || other.CompareTag("Player"))
        {
            ChangedMaterial_AnimationTrigger();
            Touch = true;
        }
    }

    void ChangedMaterial_AnimationTrigger()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = TargetMaterial;
        _Renderer.materials = mats;

        _Animator.SetBool("Attack", true);
    }
}
