using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Script : MonoBehaviour
{
    public enum BallType
    {
        NORMAL,
        COUNT,
    };

    [System.Serializable]
    public struct BallPrefabs
    {
        public BallType type;
        public GameObject prefab;
    }

    public BallPrefabs[] ballPrefabs;
    public GameObject backgroundPrefabs;

    public int xDim;
    public int yDim;

    private Dictionary<BallType, GameObject> ballPrefabDict;
    private Ball_Script[,] balls;
    
    void Start()
    {
        ballPrefabDict = new Dictionary<BallType, GameObject>();
        for(int i = 0; i < ballPrefabs.Length; i++)
        {
            if (!ballPrefabDict.ContainsKey(ballPrefabs[i].type))
            {
                ballPrefabDict.Add(ballPrefabs[i].type, ballPrefabs[i].prefab);
            }
        }

        for(int x = 0; x < xDim; x++)
        {
            for(int y = 0; y < yDim; y++)
            {
                GameObject gridBG = (GameObject)Instantiate(backgroundPrefabs, GetWorldPosition(x, y), Quaternion.identity);
                gridBG.transform.parent = transform;
            }
        }

        balls = new Ball_Script[xDim, yDim];
        for(int x = 0; x<xDim; x++)
        {
            for (int y = 0;y < yDim; y++)
            {
                GameObject newBall = (GameObject)Instantiate(ballPrefabDict[BallType.NORMAL], GetWorldPosition(x, y), Quaternion.identity);
                newBall.name = "Ball(" + x + "," + y + ")";
                newBall.transform.parent = transform;

                balls[x, y] = newBall.GetComponent<Ball_Script>();
                balls[x, y].Init(x, y, this, BallType.NORMAL);

                if (balls[x, y].IsMoveable())
                {
                    balls[x, y].MoveableComponent.Move(x, y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(transform.position.x - xDim/2.0f + x, transform.position.y - yDim / 2.0f + y);
    }
}
