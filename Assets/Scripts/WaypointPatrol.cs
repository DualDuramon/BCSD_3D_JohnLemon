using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;   //�׺�޽ÿ�����Ʈ ������Ʈ. <- AI�ʿ� ����.
    public Transform[] waypoints;       //��������Ʈ �迭.
    int m_CurrentWaypointIndex;         //���� ��������Ʈ �ε���.


    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //�׺�޽ÿ�����Ʈ�� ���ʸ����� ����.
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) //��������Ʈ�� ����������
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; //�ε��� 1 ������
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);  //���� ��������Ʈ�� ����.
        }
    }
}
