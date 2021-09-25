using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Photon.Pun;

public class BoardManager : MonoBehaviourPun
{
    [Serializable]
    public class Count
    {
        public int min;
        public int max;
        public Count(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public int cols = 100;
    public int rows = 100;
    public Count wallCount = new Count(100, 250);
    public Count BoxCount = new Count(10, 20);
    public GameObject[] floors;
    public GameObject[] walls;
    public GameObject[] wallsFront;



    public int a = 0;
    public int b = 0;


    public GameObject box;

    private int type;
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < cols + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {

                make_ovj(x, y);
            }
        }
    }
    void initList()
    {
        gridPositions.Clear();
        for (int x = 1; x < cols - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    Vector3 RandomPosition()
    {
        int index = Random.Range(0, gridPositions.Count);
        Vector3 position = gridPositions[index];
        gridPositions.RemoveAt(index);
        return position;
    }

    [PunRPC]
    void LayoutObject(GameObject[] tiles, int min, int max)
    {
        int count = Random.Range(min, max + 1);
        for (int i = 0; i < count; i++)
        {
            Vector3 blockPos = Vector3.zero;
            if (PhotonNetwork.IsMasterClient)
                blockPos = RandomPosition();
            Vector3 position = blockPos;
            GameObject tile = tiles[Random.Range(0, tiles.Length)];
            GameObject tile1 = wallsFront[Random.Range(0, wallsFront.Length)];

            position.y = position.y - 0.25f;
            Instantiate(tile1, position, Quaternion.identity);
            position.z = position.z - 1;
            position.y = position.y + 0.75f;
            Instantiate(tile, position, Quaternion.identity);
        }
    }

    

    public void SetupScenes()
    {
        BoardSetup();
        initList();
        LayoutObject(walls, wallCount.min, wallCount.max);
    }

    void make_ovj(int x, int y)
    {
        GameObject obj = floors[Random.Range(0, floors.Length)]; type = 1;
        GameObject obj1 = wallsFront[Random.Range(0, wallsFront.Length)];
        if (x == -1 || x == cols || y == -1 || y == rows)
        {
            obj = walls[Random.Range(0, walls.Length)]; type = 0;
            GameObject instance = Instantiate(obj, new Vector3(x, y + 0.5f, -1), Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);

            obj1 = wallsFront[Random.Range(0, wallsFront.Length)];
            GameObject instance1 = Instantiate(obj1, new Vector3(x, y - 0.25f, 0), Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
        else
        {
            GameObject instance = Instantiate(
            obj,
            new Vector3(x, y, 1f * type),
            Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}