using System.Collections;
using System.Collections.Generic;
//using System.Numerics; 지워야 Vector코드가 작동함
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*
        inputVec.x = Input.GetAxisRaw("Horizontal");//Raw를 붙이면 입력에 바로바로 반응하여 떼면 멈춤
        inputVec.y = Input.GetAxisRaw("Vertical");
        */
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //대각선의 속도도 직선의 속도와 같게 함 * 속도 * 프레임 한 번의 시간
        //Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        //움직이는 방법들
        // 1. 힘을 줌
        //rigid.AddForce(nextVec);

        // 2. 속도 제어
        //rigid.velocity = nextVec;

        // 3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
       inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {//프레임 종료 전 실행
        anim.SetFloat("Speed", inputVec.magnitude);//magnitude는 크기의 값을 가져옴

        if(inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }
    }
}
