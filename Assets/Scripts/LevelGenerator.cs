using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();
    public Transform levelInitialPoint;
 

    void Awake()
    {
        sharedInstance = this;
    }


    void Start()
    {
        AddLevelBlock();
        AddLevelBlock();
        AddLevelBlock();
    }


    void Update()
    {
        
    }

    public void AddLevelBlock()
    {
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);
        LevelBlock Block = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);
        Vector3 BlockPosition = Vector3.zero;
        if (currentLevelBlocks.Count == 0)
        {
            BlockPosition = levelInitialPoint.position;
        }
        else
        {
            BlockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPosition.position;
        }
        currentLevelBlocks.Add(Block);
        Block.transform.position = BlockPosition;
        Block.transform.SetParent(this.transform);
    }

    public void DeleteLevel()
    {
        LevelBlock Block = currentLevelBlocks[0];
        currentLevelBlocks.Remove(Block);
        Destroy(Block.gameObject);
    }

}
