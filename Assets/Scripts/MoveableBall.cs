using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveableBall : MonoBehaviour
{
    private Ball_Script ball;

    private void Awake()
    {
        ball = GetComponent<Ball_Script>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(int newX, int newY)
    {
        ball.X = newX;
        ball.Y = newY;

        ball.transform.localPosition = ball.GridRef.GetWorldPosition(newX, newY);
    }
}
