using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Script;

public class big : MonoBehaviour
{
    [SerializeField]

    public Map map;

    public GameObject[] WordPrefaps;

    public GameObject[] BlockPrefaps;
    public big()
    {
        map = new Map();
        WordPrefaps = new GameObject[2];

        BlockPrefaps = new GameObject[2];
    }

    public void Awake()
    {   
        var NewMap = map.Generate();
        var rand = new  System.Random();
 
        for (int i = 0; i < Map.Width; i++)
        {
            for (int j = 0; j < Map.Height; j++)
            {
                /*
                if (rand.Next(1, 4) == 1) Instantiate(Word1Prefap, new Vector3(i, j,0), Quaternion.identity);
                else if (rand.Next(1, 4) == 2) Instantiate(Word2Prefap, new Vector3(i, j,0), Quaternion.identity);
                else if (rand.Next(1, 4) == 3) Instantiate(Word3Prefap, new Vector3(i, j,0), Quaternion.identity);
                else Instantiate(BlockPrefap, new Vector3(i, j,0), Quaternion.identity);*/
                Instantiate(BlockPrefaps [rand.Next(1, 2)], new Vector3(i, j, 0), Quaternion.identity);
                if (NewMap[i, j] == '#')
                    Instantiate(WordPrefaps[rand.Next(1, 2)], new Vector3(i, j,-1), Quaternion.identity);
            }
        }
        for (int i = 0; i < Map.Width+1; i++)
        {
            Instantiate(WordPrefaps[rand.Next(1, 2)], new Vector3(0, i,-1), Quaternion.identity);
            Instantiate(WordPrefaps[rand.Next(1, 2)], new Vector3(i, 0,-1), Quaternion.identity);
            Instantiate(WordPrefaps[rand.Next(1, 2)], new Vector3(Map.Width, i,-1), Quaternion.identity);
            Instantiate(WordPrefaps[rand.Next(1, 2)], new Vector3(i, Map.Width,-1), Quaternion.identity);
        }
    }
}
