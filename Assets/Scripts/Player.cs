using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed;


    Rigidbody m_rigibBody;

    void Start()
    {
        m_rigibBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveVector;

        moveVector = GetMovementVector();
        MovePlayer(moveVector, _speed);
    }

    void MovePlayer(Vector3 moveVector, float speed){
        
        float gravity = m_rigibBody.velocity.y;
        Vector3 gravityVec = new Vector3(0,gravity,0);

        Vector3 outVelocity = moveVector*speed + gravityVec;

        m_rigibBody.velocity = outVelocity;


    }

    Vector3 GetMovementVector(){

        Vector3 move = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
            move += Vector3.forward;

        if(Input.GetKey(KeyCode.S))
            move -= Vector3.forward;

        if(Input.GetKey(KeyCode.D))
            move += Vector3.right;

        if(Input.GetKey(KeyCode.A))
            move -= Vector3.right;

        return move.normalized;

    }
}
