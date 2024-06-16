using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //페이드인 발생에 드는 시간
    public float displayImageDuration = 1f; //페이드인 후 이미지 확인하는데 걸리는 시간
    public GameObject player;   
    public CanvasGroup exitBackgroundImageCanvasGroup;


    bool m_IsPlayerAtExit;  //페이드인 발생 여부
    float m_Timer;  //페이드인이 끝나기 전에 게임이 종료되지 않게 체크하는 변수

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration) 
        {
            Application.Quit();
        }
    }
}
