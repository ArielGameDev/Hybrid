using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed;

    [SerializeField]
    Transform m_cursorHelper;


    [SerializeField]
    TransformEffects _onDisable, _onEnable;



    Rigidbody m_rigibBody;
    Camera m_camera;


    void Start()
    {
        m_rigibBody = GetComponent<Rigidbody>();
        m_camera = Camera.main;
    }

    void Update()
    {

        Vector3 rayHitPoint;

        rayHitPoint = GetCameraMouseProjection();

        if (m_cursorHelper != null)
            m_cursorHelper.position = rayHitPoint;

        transform.LookAt(rayHitPoint, transform.up);

    }

    void FixedUpdate()
    {
        Vector3 moveVector;

        moveVector = GetMovementVector();
        MovePlayer(moveVector, _speed);

    }

    void OnDisable()
    {
        // avoid sliding on switch
        m_rigibBody.velocity = Vector3.zero;

        if(_onDisable == null)
            return;

        List<Transform> trList = new List<Transform>();
        trList.Add(transform);
        _onDisable.Apply(trList);
    }

    void OnEnable()
    {
        if(_onEnable == null)
            return;
        List<Transform> trList = new List<Transform>();
        trList.Add(transform);
        _onEnable.Apply(trList);
    }

    void MovePlayer(Vector3 moveVector, float speed)
    {

        float gravity = m_rigibBody.velocity.y;
        Vector3 gravityVec = new Vector3(0, gravity, 0);

        Vector3 outVelocity = moveVector * speed + gravityVec;

        m_rigibBody.velocity = outVelocity;


    }

    Vector3 GetMovementVector()
    {

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            move -= Vector3.forward;

        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;

        if (Input.GetKey(KeyCode.A))
            move -= Vector3.right;

        return move.normalized;

    }

    Vector3 GetCameraMouseProjection()
    {

        Vector3 mouseOnScreen = Input.mousePosition;
        Ray cameraRay = m_camera.ScreenPointToRay(mouseOnScreen);

        Plane raycastPlane = new Plane(transform.up, transform.position);
        float rayEnterDistance;
        raycastPlane.Raycast(cameraRay, out rayEnterDistance);

        Vector3 rayHitPoint = cameraRay.origin + cameraRay.direction * rayEnterDistance;

        return rayHitPoint;
    }
}
