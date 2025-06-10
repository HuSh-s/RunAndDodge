using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameManager _GameManager;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
    }
    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Multiply") || other.CompareTag("Divide") || other.CompareTag("Add") || other.CompareTag("Sub"))
        {
            int number = int.Parse(other.name);
            _GameManager.ManManager(other.tag, number, other.transform);
        }
    }
}
