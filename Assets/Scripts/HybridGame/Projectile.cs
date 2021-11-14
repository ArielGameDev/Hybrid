using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    string _harmTag;

    [SerializeField]
    string _ignoreTag;

    [SerializeField]
    Vector3 _move;


    Rigidbody m_rigidbody;
    void Start()
    {
        if (_harmTag == null)
        {
            this.enabled = false;
            Debug.LogError("Not all fields set! Disabling component");
            return;
        }

        m_rigidbody = GetComponent<Rigidbody>();
        Vector3 worldMove = transform.TransformVector(_move);
        m_rigidbody.velocity = worldMove;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == _ignoreTag)
            return;

        if (other.tag != _harmTag){
            Destroy(gameObject,0);
            return;
        }

        Destroy(other.gameObject, 0);
        Destroy(gameObject,0);

    }
}
