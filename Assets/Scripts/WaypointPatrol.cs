using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;   //네비메시에이전트 컴포넌트. <- AI쪽에 있음.
    public Transform[] waypoints;       //웨이포인트 배열.
    int m_CurrentWaypointIndex;         //현재 웨이포인트 인덱스.


    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //네비메시에이전트의 최초목적지 설정.
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) //웨이포인트에 도착했을때
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; //인덱스 1 증가후
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);  //다음 웨이포인트로 설정.
        }
    }
}
