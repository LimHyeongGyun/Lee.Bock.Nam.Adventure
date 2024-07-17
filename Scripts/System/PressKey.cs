using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressKey : MonoBehaviour
{
    public Image black;

    public void Update() 
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("게임을 시작합니다.");
            StartCoroutine(FadeoutSet());
        }

    }

    public IEnumerator FadeoutSet()
    {
        Color color = black.color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime; //deltaTime은 프레임이랑 반비례 모든 컴퓨터에서 같은 프레임이 나오게 해줌

            black.color = color;

            yield return new WaitForSeconds(Time.deltaTime); //괄호 안 시간동안 코드가 잠깐 멈춤
        }

        SceneManager.LoadScene("CharactorPage");
        Debug.Log("캐릭터 선택창으로 이동");
    }
}
