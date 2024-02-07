using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    private const int STARTING_LEVEL_PARTS = 5;
    private const float PLAYER_DISTANCE_SPAWN_LVEL_PART = 200f;


    public GameObject startingGround;
    public List<GameObject> levelPartList;
    public GameObject player;
    private Vector3 lastEndPosition;

    public void Awake()
    {
        lastEndPosition = startingGround.transform.Find("End").position;

        for (int count = 0; count < STARTING_LEVEL_PARTS; count++)
        {
            SpawnLevelPart();
        }
    }

    public void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        GameObject levelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPart = SpawnLevelPart(levelPart, lastEndPosition);
        lastEndPosition = lastLevelPart.Find("End").position;
    }

    public Transform SpawnLevelPart(GameObject levelPart, Vector3 position)
    {
        Transform lastLevelPart = Instantiate(levelPart.transform, position, Quaternion.identity);
        return lastLevelPart;
    }
}
