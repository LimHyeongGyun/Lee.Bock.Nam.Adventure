using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    public Transform cameraMove;
    public GameObject LeeBtn;
    public GameObject BockBtn;
    public GameObject NamBtn;
    public GameObject Developers;
    public GameObject Left;
    public GameObject Right;

    private void Start()
    {
        LeeBtn.SetActive(true);
        BockBtn.SetActive(false);
        NamBtn.SetActive(false);
        Developers.SetActive(false);
    }
    public void ClickLeft()
    {
        if (this.gameObject.name == "moveLeft")
        {
            cameraMove.transform.Rotate(new Vector3(0, -90, 0));
            if (cameraMove.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                LeeBtn.SetActive(true);
                BockBtn.SetActive(false);
                NamBtn.SetActive(false);
                Developers.SetActive(false);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(true);
                NamBtn.SetActive(false);
                Developers.SetActive(false);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, 180, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(false);
                NamBtn.SetActive(true);
                Developers.SetActive(false);
                Right.SetActive(true);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, -90, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(false);
                NamBtn.SetActive(false);
                Developers.SetActive(true);
                Left.SetActive(false);
            }
        }
    }
    public void ClickRight()
    {
        if (this.gameObject.name == "moveRight")
        {
            cameraMove.transform.Rotate(new Vector3(0, 90, 0));
            if (cameraMove.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                LeeBtn.SetActive(true);
                BockBtn.SetActive(false);
                NamBtn.SetActive(false);
                Developers.SetActive(false);
                Left.SetActive(true);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(true);
                NamBtn.SetActive(false);
                Developers.SetActive(false);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, 180, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(false);
                NamBtn.SetActive(true);
                Developers.SetActive(false);
            }
            else if (cameraMove.transform.rotation == Quaternion.Euler(0, 270, 0))
            {
                LeeBtn.SetActive(false);
                BockBtn.SetActive(false);
                NamBtn.SetActive(false);
                Developers.SetActive(true);
                Right.SetActive(false);
            }
        }
    }

}
