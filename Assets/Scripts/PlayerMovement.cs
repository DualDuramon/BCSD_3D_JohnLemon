using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;   //2Pi���� = 6���� �ȴ�. �� ������ �ٲٴµ� 0.5������ �ɸ���.
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;    //ȸ������ �⺻��. �������ʹϾ���.
    Animator m_Animator;
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�÷��̾� ������ �ν� ����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();

        //�÷��̾� �̵� �ִϸ��̼�
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); //Approximately() : �� ���� ���������� �˻���.
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); 
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        //�÷��̾� ȸ�� ����
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f); //forward�� m_Movement���� ȸ����Ŵ
        m_Rotation = Quaternion.LookRotation(desiredForward);   //�ش� �Ķ���� �������� ���� ȸ���� ����
    }

    private void OnAnimatorMove()
    {
        //��Ʈ����� �̿��� �÷��̾ ������.
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude); //deltaposition : ��Ʈ������� ���� �����Ӵ� ��ġ �̵���.
        m_Rigidbody.MoveRotation(m_Rotation);
    }


}