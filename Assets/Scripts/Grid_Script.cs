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

    public int xRow;
    public int yRow;

    private Dictionary<BallType, GameObject> ballPrefabDict;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
