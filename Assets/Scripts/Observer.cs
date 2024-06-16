using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;     //플레이어가 사정거리에 들어왔는가
    public GameEnding gameEnding;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;  //플레이어를 향하는 벡터.
            Ray ray = new Ray(transform.position, direction);                       //발밑을 가리키게 되므로 살짝 위로 올리기위해 vector3.up을 사용
            RaycastHit rayCastHit;  

            if (Physics.Raycast(ray, out rayCastHit))   //rayCastHit의 정보를 out키워드를 이용해 반환. and ray에 무언가 닿았나 검사
            {
                if(rayCastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
