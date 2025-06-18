using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class FreeChar : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material TargetMaterial;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameObject Target;
    public GameManager _GameManager;
    bool Touch;

    private void LateUpdate()
    {
        if(Touch)
            _Navmesh.SetDestination(Target.transform.position);
    }
    Vector3 GivePosition()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CharChild") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("FreeChar"))
            {
                ChangedMaterial_AnimationTrigger();
                Touch = true;
                GetComponent<AudioSource>().Play();
            }
        }

        else if (other.CompareTag("SpikeBox"))
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

    void ChangedMaterial_AnimationTrigger()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = TargetMaterial;
        _Renderer.materials = mats;

        _Animator.SetBool("Attack", true);
        GameManager.CurrentCharacterCount++;
        gameObject.tag = "CharChild";

    }
}
