using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //���̵��� �߻��� ��� �ð�
    public float displayImageDuration = 1f; //���̵��� �� �̹��� Ȯ���ϴµ� �ɸ��� �ð�
    public GameObject player;   
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Ż�� �̹��� ��� ĵ�����׷�
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //������ �̹��� ��� ĵ�����׷�

    bool m_IsPlayerAtExit;  //Ż�� �� ���̵��� �߻� ����
    float m_Timer;          //���̵����� ������ ���� ������ ������� �ʰ� üũ�ϴ� ����
    bool m_IsPlayerCaught;  //������ �� ���̵��� �߻� ����


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
