﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    //public Transform spawnObject;
    public GameObject[] treeObject;
    public GameObject treeParent;
    public GameObject player;
    public void SpawnGameObject(int[,] map)
    {
        float test = 0.0f;
        //좌상
        while (true)
        {
            int x = Random.Range(0, (int)(map.GetLength(0)*(0.3f+test)));
            int y = Random.Range(0, (int)(map.GetLength(1) * (0.3f + test)));
            while (x >50 || y > 50)
            {
                x = Random.Range(0, (int)(map.GetLength(0)*(0.3f+test)));
                y = Random.Range(0, (int)(map.GetLength(1) * (0.3f + test)));
            }
            if (map[x, y] == 0&& checkMap(map,x,y))
            {
                Vector3 spawnPos = new Vector3(x- map.GetLength(0)*0.5f, 0.3f, y- map.GetLength(1) * 0.5f);
                EnemyManager.Instance.spawn(spawnPos);
                DataManager.Instance.EnemyPosition.Add(spawnPos);
                break;
            }
            test += 0.00001f;
        }
        test = 0.0f;
        //우상
        while (true)
        {
            int x = Random.Range((int)(map.GetLength(0) * (0.7f + test)), map.GetLength(0) - 1);
            int y = Random.Range(0, (int)(map.GetLength(1) * (0.3f + test)));
            while (x > 50 || y > 50)
            {
                x = Random.Range((int)(map.GetLength(0) * (0.7f + test)), map.GetLength(0) - 1);
                y = Random.Range(0, (int)(map.GetLength(1) * (0.3f + test)));
            }
            if (map[x, y] == 0 && checkMap(map, x, y))
            {
                Vector3 spawnPos = new Vector3(x - map.GetLength(0) * 0.5f, 0.3f, y - map.GetLength(1) * 0.5f);
                EnemyManager.Instance.spawn(spawnPos);
                DataManager.Instance.EnemyPosition.Add(spawnPos);
                break;
            }
            test += 0.00001f;
        }
        test = 0.0f;
        //좌하
        while (true)
        {
            int x = Random.Range(0, (int)(map.GetLength(0) * (0.3f + test)));
            int y = Random.Range((int)(map.GetLength(1) * (0.7f + test)), map.GetLength(1));
            while (x > 50 || y > 50)
            {
                x = Random.Range(0, (int)(map.GetLength(0) * (0.3f + test)));
                y = Random.Range((int)(map.GetLength(1) * (0.7f + test)), map.GetLength(1));
            }
            if (map[x, y] == 0 && checkMap(map, x, y))
            {
                Vector3 spawnPos = new Vector3(x - map.GetLength(0) * 0.5f, 0.3f, y - map.GetLength(1) * 0.5f);
                EnemyManager.Instance.spawn(spawnPos);
                DataManager.Instance.EnemyPosition.Add(spawnPos);
                break;
            }
            test += 0.00001f;
        }
        test = 0.0f;
        //우하
        while (true)
        {
            int x = Random.Range((int)(map.GetLength(0) * (0.7f + test)), map.GetLength(0) - 1);
            int y = Random.Range((int)(map.GetLength(1) * (0.7f + test)), map.GetLength(1));
            while (x > 50 || y > 50)
            {
                x = Random.Range((int)(map.GetLength(0) * (0.7f + test)), map.GetLength(0) - 1);
                y = Random.Range((int)(map.GetLength(1) * (0.7f + test)), map.GetLength(1));
            }
            if (map[x, y] == 0 && checkMap(map, x, y))
            {
                Vector3 spawnPos = new Vector3(x - map.GetLength(0) * 0.5f, 0.3f, y - map.GetLength(1) * 0.5f);
                EnemyManager.Instance.spawn(spawnPos);
                DataManager.Instance.EnemyPosition.Add(spawnPos);
                //spawnObject = EnemyManager.Instance.RandomEnemy();
                //Instantiate(spawnObject, spawnPos, Quaternion.Euler(0, 0, 0));
                break;
            }
            test += 0.00001f;
        }
    }

    public void PlayerSpawn(int[,] map)
    {
        float test = 0.0f;
        //좌상
        while (true)
        {
            int x = Random.Range((int)(map.GetLength(0) * (0.3f + test)), (int)(map.GetLength(0) * (0.6f + test)));
            int y = Random.Range((int)(map.GetLength(1) * (0.3f + test)), (int)(map.GetLength(1) * (0.6f + test)));
            while (x > 50 || y > 50)
            {
                x = Random.Range((int)(map.GetLength(0) * (0.3f + test)), (int)(map.GetLength(0) * (0.6f + test)));
                y = Random.Range((int)(map.GetLength(1) * (0.3f + test)), (int)(map.GetLength(1) * (0.6f + test)));
            }
            if (map[x, y] == 0 && checkMap(map, x, y))
            {
                Vector3 spawnPos = new Vector3(x - map.GetLength(0) * 0.5f, 0f, y - map.GetLength(1) * 0.5f);
                player.transform.position = spawnPos;
                player.transform.rotation = new Quaternion(0,-110,0,0);
                break;
            }
            test += 0.00001f;
        }
    }

    bool checkMap(int[,] map,int x,int y)
    {
        for(int i=-1;i<=1;++i)
        {
            for(int j=-1;j<=1;++j)
            {
                if (i == 0 && j == 0) continue;
                if (x + i <= 0 || x + i >= map.GetLength(0) || y + i <= 0 || y + i >= map.GetLength(1)) return false;
                if (map[x+i, x+j] == 1) return false;
            }
        }
        return true;
    }

    public void TreeSpawn(int[,] map)
    {
        for (int i=0;i<map.GetLength(0);++i)
        {
            for(int j=0;j<map.GetLength(0);++j)
            {
                if(map[i,j]==1&&Random.Range(0,100)>88)
                {
                    GameObject newObject = Instantiate(treeObject[Random.Range(0,treeObject.Length)], new Vector3(i - map.GetLength(0) * 0.5f, 0.8f, j - map.GetLength(1) * 0.5f),Quaternion.Euler(0,0,0), treeParent.transform);
                    newObject.isStatic = true;
                }
            }
        }
    }

    public void PlayerEnemySpawn()
    {
        player.transform.position = DataManager.Instance.PlayerPosition;
        player.transform.rotation = new Quaternion(0, -110, 0, 0);
        DataManager.Instance.EnemyList.Clear();
        int index = DataManager.Instance.EnemyIdx;
        DataManager.Instance.chkEnemy[index] = true;
        for (int i = 0; i < DataManager.Instance.EnemyPosition.Count; ++i)
        {
            int shape = DataManager.Instance.EnemyShape[i];
            if (DataManager.Instance.chkEnemy[i]==false)
            {
                GameObject temp = EnemySpawn.Instance.selectType(i, shape);
                GameObject enemy = Instantiate(temp, DataManager.Instance.EnemyPosition[i], new Quaternion(0, -110, 0, 0));
                ENEMYTYPE type = (ENEMYTYPE)i;
                enemy.GetComponent<Enemy>().Initialize(type);
                DataManager.Instance.EnemyList.Add(enemy.GetComponent<Enemy>());
            }
            else
            {
                DataManager.Instance.EnemyList.Add(null);
            }
        }
    }

    public void DeleteChilds()
    {
        Transform[] child = treeParent.GetComponentsInChildren<Transform>();

        if(child != null)
        foreach(var iter in child)
        {
            if (iter != treeParent.transform) Destroy(iter.gameObject);
        }
    }
}
