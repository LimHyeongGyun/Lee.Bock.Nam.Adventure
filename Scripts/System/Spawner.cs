using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int count;
    public int curcount = 0;
    float timer;

    BoxCollider area; //박스 콜라이더 사이즈 받아오기 위함

    void Start()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            if (count > curcount)
            {
                timer = 0;
                Spawn();
                curcount += 1;
            }
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,3)); 
        enemy.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(50 * -size.x / 2f, 50 * size.x / 2f);
        float posY = 0;
        float posZ = basePosition.z + Random.Range(50 * -size.z / 2f, 50 * size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        Debug.Log(spawnPos);
        return spawnPos;
    }
}
