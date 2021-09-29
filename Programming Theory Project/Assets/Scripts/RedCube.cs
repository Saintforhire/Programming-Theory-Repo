using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : Block
{
    private float speedMultiplier = 2;

    void Start()
    {
        isMovingRight = Random.value > 0.5f;
    }

    void Update()
    {
        Move();
        MovingRightOrLeft();
    }

    public override void Move()
    {
        transform.Translate(Vector3.back * (speed * speedMultiplier) * Time.deltaTime, Space.World);
    }

    private void MovingRightOrLeft()
    {
        if (isMovingRight && transform.position.x > maxXPos)
        {
            isMovingRight = !isMovingRight;
        }
        if (!isMovingRight && transform.position.x < -maxXPos)
        {
            isMovingRight = !isMovingRight;
        }

        if (isMovingRight)
        {
            transform.Translate(Vector3.right * (speed * rightAndLeftMultiplier) * Time.deltaTime, Space.World);
        }
        if (!isMovingRight)
        {
            transform.Translate(Vector3.left * (speed * rightAndLeftMultiplier) * Time.deltaTime, Space.World);
        }
    }
}
