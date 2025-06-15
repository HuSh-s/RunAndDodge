using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    public GameManager _GameManager;
    public Camera_ Cam;
    public bool ReachEnd;
    public GameObject CharDestination;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!ReachEnd)
        {
            transform.Translate(Vector3.forward * 1f * Time.deltaTime);
        }
    }
    void Update()
    {
        if (ReachEnd)
        {
            transform.position = Vector3.Lerp(transform.position, CharDestination.transform.position, .015f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }

                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Multiply") || other.CompareTag("Divide") || other.CompareTag("Add") || other.CompareTag("Sub"))
        {
            int number = int.Parse(other.name);
            _GameManager.ManManager(other.tag, number, other.transform);
        }
        else if(other.CompareTag("FinishTrigger"))
        {
            Cam.ReachEnd = true;
            _GameManager.EnemyTrigger();
            ReachEnd = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Column") || collision.gameObject.CompareTag("SpikeBox") || collision.gameObject.CompareTag("PropellerSpikes"))
        {
            if(transform.position.x > 0)
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
        }
    }
}
