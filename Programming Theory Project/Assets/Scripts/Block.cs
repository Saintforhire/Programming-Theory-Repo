using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected float maxXPos = 8;
    protected int forward = 1;
    protected int right = 1;
    protected float rightAndLeftMultiplier = 3;

    protected bool isMovingRight;

    private void Start()
    {
        bool rndBool = (Random.value > 0.5f);
        isMovingRight = rndBool;
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    public virtual void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
