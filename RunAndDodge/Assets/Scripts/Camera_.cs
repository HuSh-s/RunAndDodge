using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ : MonoBehaviour
{

    public Transform target;
    public Vector3 target_offset;
    public bool ReachEnd;
    public GameObject CamDestination;
    void Start()
    {
        target_offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (!ReachEnd)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, CamDestination.transform.position, .015f);
        }
    }
}
