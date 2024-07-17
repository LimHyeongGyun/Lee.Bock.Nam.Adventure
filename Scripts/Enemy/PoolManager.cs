using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Enemykind; //enemy프리펩들을 보관할 변수

    List<GameObject>[] pools; //풀 담당을 하는 리스트

    void Awake()
    {
        pools = new List<GameObject>[Enemykind.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    //게임 오브젝트를 반환하는 함수
    public GameObject Get(int index)
    {
        GameObject select = null;

        //선택한 풀의 비활성화 된 게임오브젝트 접근
        //발견하면 select 변수에 할당

        foreach (GameObject enemy in pools[index])
        {
            if (!enemy.activeSelf)
            {
                select = enemy;
                select.SetActive(true);
                break;
            }
        }

        //모든 오브젝트가 활성화 되었다면
        if (select == null)
        {
            //새롭게 생성하여 select 변수에 할당함
            select = Instantiate(Enemykind[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
