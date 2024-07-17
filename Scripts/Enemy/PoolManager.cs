using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Enemykind; //enemy��������� ������ ����

    List<GameObject>[] pools; //Ǯ ����� �ϴ� ����Ʈ

    void Awake()
    {
        pools = new List<GameObject>[Enemykind.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    //���� ������Ʈ�� ��ȯ�ϴ� �Լ�
    public GameObject Get(int index)
    {
        GameObject select = null;

        //������ Ǯ�� ��Ȱ��ȭ �� ���ӿ�����Ʈ ����
        //�߰��ϸ� select ������ �Ҵ�

        foreach (GameObject enemy in pools[index])
        {
            if (!enemy.activeSelf)
            {
                select = enemy;
                select.SetActive(true);
                break;
            }
        }

        //��� ������Ʈ�� Ȱ��ȭ �Ǿ��ٸ�
        if (select == null)
        {
            //���Ӱ� �����Ͽ� select ������ �Ҵ���
            select = Instantiate(Enemykind[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
