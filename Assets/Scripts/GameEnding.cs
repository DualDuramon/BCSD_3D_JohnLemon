using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //페이드인 발생에 드는 시간
    public float displayImageDuration = 1f; //페이드인 후 이미지 확인하는데 걸리는 시간
    public GameObject player;   
    public CanvasGroup exitBackgroundImageCanvasGroup;      //탈출 이미지 출력 캔버스그룹
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //잡혔다 이미지 출력 캔버스그룹
    public AudioSource caughtAudio;


    bool m_IsPlayerAtExit;  //탈출 시 페이드인 발생 여부
    float m_Timer;          //페이드인이 끝나기 전에 게임이 종료되지 않게 체크하는 변수
    bool m_IsPlayerCaught;  //잡혔을 시 페이드인 발생 여부
    bool m_HasAudioPlayed;  //오디오를 한번만 출력하기위한 변수


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
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
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
