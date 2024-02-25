using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if (IsMoveable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (IsMoveable())
            {
                y = value;
            }
        }
    }

    private Grid_Script.BallType type;
    public Grid_Script.BallType Type
    {
        get { return type; }
    }

    private Grid_Script grid;
    public Grid_Script GridRef
    {
        get { return grid; }
    }

    private MoveableBall moveableComponent;
    public MoveableBall MoveableComponent
    {
        get { return moveableComponent; }
    }

    private void Awake()
    {
        moveableComponent = GetComponent<MoveableBall>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init(int _x, int _y, Grid_Script _grid, Grid_Script.BallType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    public bool IsMoveable()
    {
        return moveableComponent != null;
    }
}
