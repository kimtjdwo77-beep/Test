using UnityEngine;

public class playeranime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //애니메이션 작동방법은 FSM을 따른다  / 유한 상태 머신 , 컨디션, 상태변환처리
    // 몬스터 AI의 가장 기본이 되고 FSM은 디자인 패턴 중 하나이다.
    Animator anime;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed = 1.0f;
    bool isground = false;

    void Start()
    {
        // 애니메이션 방식 레거시 / 메카님 레거시 : 옛날 그대로 ㅇㅇ 메카님: 요즘도 씀 대세 --> 잘 만들면 캐릭터 바꿔도 상관 없다

        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isground = true;
        print("현재 지면에 있음");
    }

    // Update is called once per frame
    void Update()
    {
        //Animetest();
        float moveInput = Input.GetAxis("Horizontal");
        //moveInput 0이 아니라면 움직여.
        bool ismove = (moveInput != 0);
        

        //Setbool("키값", bool 변수);

        anime.SetBool("Grounded", isground);

        if(moveInput > 0)
        {
            rb.linearVelocityX = moveInput * speed;

        }
        else if (moveInput < 0)
        {
            rb.linearVelocityX = moveInput * speed;
            sr.flipX = true;

        }


        if(Input.GetKeyDown(KeyCode.Space) && isground == true)
        {

            rb.linearVelocityY = 9.0f;
            anime.SetTrigger("JUMP");
            isground = false;

        }
        if (Input.GetMouseButtonDown(0))
        {

            anime.SetTrigger("Attack");
        }



    }

    void Animetest()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {

            //anim.Setbool("Iswalking", true);

        }

        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            //비슷하게 다른 트리고 false;

        }

    }
}
