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
    private GameObject[,] balls;
    
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

        balls = new GameObject[xDim, yDim];
        for(int x = 0; x<xDim; x++)
        {
            for (int y = 0;y < yDim; y++)
            {
                balls[x, y] = (GameObject)Instantiate(ballPrefabDict[BallType.NORMAL], GetWorldPosition(x, y), Quaternion.identity);
                balls[x, y].name = "Ball(" + x + "," + y + ")";
                balls[x, y].transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(transform.position.x - xDim/2.0f + x, transform.position.y - yDim / 2.0f + y);
    }
}
