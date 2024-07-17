using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 16, -15);
        if (SceneChangeManager.charactorNum == 2)
        {
            target = GameObject.Find("Lee").transform;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            target = GameObject.Find("Bock").transform;
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            target = GameObject.Find("Nam").transform;
        }
    }
    void Update()
    {
        transform.position = target.position + offset;
    }
}
