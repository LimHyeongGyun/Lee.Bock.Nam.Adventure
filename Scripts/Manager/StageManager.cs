using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageManager : MonoBehaviour
{

    public void ClickBtn()
    {
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;
        if (nowbutton == "Leebtn") SceneChangeManager.charactorNum = 2;
        else if (nowbutton == "Bockbtn") SceneChangeManager.charactorNum = 3;
        else if (nowbutton == "Nambtn") SceneChangeManager.charactorNum = 4;
    }
    public void Stagebtn(GameObject obj)
    {
        if (obj.gameObject.name == "1-1") { SceneChangeManager.mapnum = "1-1"; SceneChangeManager.selectNum = 11; }
        else if (obj.gameObject.name == "1-2") { SceneChangeManager.mapnum = "1-2"; SceneChangeManager.selectNum = 12; }
        else if (obj.gameObject.name == "1-3") { SceneChangeManager.mapnum = "1-3"; SceneChangeManager.selectNum = 13; }
        else if (obj.gameObject.name == "1-4") { SceneChangeManager.mapnum = "1-4"; SceneChangeManager.selectNum = 14; }
        else if (obj.gameObject.name == "1-5") { SceneChangeManager.mapnum = "1-5"; SceneChangeManager.selectNum = 15; }

        else if (obj.gameObject.name == "2-1") { SceneChangeManager.mapnum = "2-1"; SceneChangeManager.selectNum = 21; }
        else if (obj.gameObject.name == "2-2") { SceneChangeManager.mapnum = "2-2"; SceneChangeManager.selectNum = 22; }
        else if (obj.gameObject.name == "2-3") { SceneChangeManager.mapnum = "2-3"; SceneChangeManager.selectNum = 23; }
        else if (obj.gameObject.name == "2-4") { SceneChangeManager.mapnum = "2-4"; SceneChangeManager.selectNum = 24; }
        else if (obj.gameObject.name == "2-5") { SceneChangeManager.mapnum = "2-5"; SceneChangeManager.selectNum = 25; }

        else if (obj.gameObject.name == "3-1") { SceneChangeManager.mapnum = "3-1"; SceneChangeManager.selectNum = 31; }
        else if (obj.gameObject.name == "3-2") { SceneChangeManager.mapnum = "3-2"; SceneChangeManager.selectNum = 32; }
        else if (obj.gameObject.name == "3-3") { SceneChangeManager.mapnum = "3-3"; SceneChangeManager.selectNum = 33; }
        else if (obj.gameObject.name == "3-4") { SceneChangeManager.mapnum = "3-4"; SceneChangeManager.selectNum = 34; }
        else if (obj.gameObject.name == "3-5") { SceneChangeManager.mapnum = "3-5"; SceneChangeManager.selectNum = 35; }

        else if (obj.gameObject.name == "4-1") { SceneChangeManager.mapnum = "4-1"; SceneChangeManager.selectNum = 41; }
        else if (obj.gameObject.name == "4-2") { SceneChangeManager.mapnum = "4-2"; SceneChangeManager.selectNum = 42; }
        else if (obj.gameObject.name == "4-3") { SceneChangeManager.mapnum = "4-3"; SceneChangeManager.selectNum = 43; }
        else if (obj.gameObject.name == "4-4") { SceneChangeManager.mapnum = "4-4"; SceneChangeManager.selectNum = 44; }
        else if (obj.gameObject.name == "4-5") { SceneChangeManager.mapnum = "4-5"; SceneChangeManager.selectNum = 45; }

        else if (obj.gameObject.name == "5-1") { SceneChangeManager.mapnum = "5-1"; SceneChangeManager.selectNum = 51; }
        else if (obj.gameObject.name == "5-2") { SceneChangeManager.mapnum = "5-2"; SceneChangeManager.selectNum = 52; }
        else if (obj.gameObject.name == "5-3") { SceneChangeManager.mapnum = "5-3"; SceneChangeManager.selectNum = 53; }
        else if (obj.gameObject.name == "5-4") { SceneChangeManager.mapnum = "5-4"; SceneChangeManager.selectNum = 54; }
        else if (obj.gameObject.name == "5-5") { SceneChangeManager.mapnum = "5-5"; SceneChangeManager.selectNum = 55; }
    }
}
