using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;   //2Pi라디안 = 6정도 된다. 즉 방향을 바꾸는데 0.5초정도 걸린다.
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;    //회전값의 기본값. 제로쿼터니언임.
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //플레이어 움직임 인식 관련
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();

        //플레이어 이동 애니메이션
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); //Approximately() : 두 값이 유사한지를 검사함.
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); 
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();

            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //플레이어 회전 관련
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f); //forward를 m_Movement까지 회전시킴
        m_Rotation = Quaternion.LookRotation(desiredForward);   //해당 파라미터 방향으로 보는 회전을 생성
    }

    private void OnAnimatorMove()
    {
        //루트모션을 이용해 플레이어를 움직임.
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude); //deltaposition : 루트모션으로 인한 프레임당 위치 이동량.
        m_Rigidbody.MoveRotation(m_Rotation);
    }


}
