using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private bool IsMoving;
    private Rigidbody rb;
    private Vector3 dir = Vector3.zero;
    private BackPack backPack;

    private void Start()
    {
        backPack = FindObjectOfType<BackPack>();
        rb = GetComponent<Rigidbody>();
        State.SetState(State.Animation.Idle, true);
    }

    public void StartMove() 
    {
        IsMoving = true;
        backPack.StartShake();
        State.SetState(State.Animation.Idle, false);
    }

    public void EndMove()
    {
        IsMoving = false;
        backPack.EndShake();
        State.SetState(State.Animation.Idle, true);
    }

    public void Moving(Vector3 pos)
    {
        Vector3 v2 = pos - transform.position;
        dir = new Vector3(v2.x, 0f, v2.y);
    }

    private void Update()
    {
        if (IsMoving == false)
            return;

        Quaternion r = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = r;
    }

    private void FixedUpdate()
    {
        if (IsMoving == false)
            return;

        rb.velocity = dir * Speed * Time.fixedDeltaTime;
    }
}
