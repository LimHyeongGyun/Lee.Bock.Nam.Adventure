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
            Debug.Log("������ �����մϴ�.");
            StartCoroutine(FadeoutSet());
        }

    }

    public IEnumerator FadeoutSet()
    {
        Color color = black.color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime; //deltaTime�� �������̶� �ݺ�� ��� ��ǻ�Ϳ��� ���� �������� ������ ����

            black.color = color;

            yield return new WaitForSeconds(Time.deltaTime); //��ȣ �� �ð����� �ڵ尡 ��� ����
        }

        SceneManager.LoadScene("CharactorPage");
        Debug.Log("ĳ���� ����â���� �̵�");
    }
}
