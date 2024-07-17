using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class objectbutton : MonoBehaviour
{
    public UnityEvent mapevent = new UnityEvent();
    public GameObject button;

    private void Start()
    {
        button = this.gameObject;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                mapevent.Invoke();
            }
        }
    }
}
