using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;     //�÷��̾ �����Ÿ��� ���Դ°�
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
            Vector3 direction = player.position - transform.position + Vector3.up;  //�÷��̾ ���ϴ� ����.
            Ray ray = new Ray(transform.position, direction);                       //�߹��� ����Ű�� �ǹǷ� ��¦ ���� �ø������� vector3.up�� ���
            RaycastHit rayCastHit;  

            if (Physics.Raycast(ray, out rayCastHit))   //rayCastHit�� ������ outŰ���带 �̿��� ��ȯ. and ray�� ���� ��ҳ� �˻�
            {
                if(rayCastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
