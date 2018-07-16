using UnityEngine;
using System.Collections;

public enum State//작업순서 1번
{    
    Idle,
    Walk,
    Attack

}


public class Enemy : MonoBehaviour
{
    float interval = 0;//시간 누적 
    Animator ani = null;
    State state = State.Idle; // enum 지정 ,switch담는 저장소, Idle 
    GameObject tower = null;

    void OnMouseDown() //클릭시 호출 터치 
    {
        // Destroy(gameObject); 테스트용 파괴

     Player player =   GameObject.FindObjectOfType<Player>();
     player.Shot(transform.position);//자기위치 값 호출 플레이어 함수 연동 

    }



    public void OnAttack()//attack 애니매이션 컨트롤디로 복제한후 애니매이션창에서 통제 
    {
        //Tpwer GamaObject -> Tower Component -> 함수 DamageByEnemy
        Tower t = tower.GetComponent<Tower>();//타워 주소값 확인후 get.component로 가져오기
        t.DamageByEnemy(); //타워에있는 DamageByEnemy 호출 데미지 표시 


    }

    //작업순서 2번 이넘함수만들기 
    void Idle()//
    {     
        interval += Time.deltaTime;

        if (interval >3)
        {
            state = State.Walk; //상태를 저장하는기능
            ani.SetTrigger("Walk"); // walk 호출 
            interval = 0;//walk ani 호출 
        }    
    }
    void Walk() //이동처리 
    {

        Vector3 dir = tower.transform.position - transform.position;
        //dir = 타겟-내위치 = 방향값 +,-

        dir.Normalize(); // 방향값계산해주는 함수 //방향값 -1~1 ,  //-5/5
        
        // 방향 * 속력 * 시간 =속도
        //속력 (초당 이동거리) 1이라는 값은 초당 1m씩 가는것

        transform.position += dir * 1 * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
        //dir 바라보는 방향만알려주면 되는 변수 



        Vector3 towerPos = tower.transform.position;
        Vector3 enemyPos = transform.position;
        //거리를 구할때 정리한것 알고리즘은 피타고라스 정리 

      float distance =   Vector3.Distance(towerPos,enemyPos); //거리 계산  왼쪽으로 넘겨주는 타입

        if (distance <1.6f)//실수는 f추가 
        {
            state = State.Attack;
            interval = 5; //바로공격하도록 5초세팅 
        }

    }

    void Attack()
    {
        interval += Time.deltaTime;

        if (interval > 5)
        {
            ani.SetTrigger("Attack");
            interval = 0;
        }
      
        

    }
	

	void Start ()//시작한번만 호출
    {
        ani = GetComponent<Animator>(); //주소는 시작할떄 한번만 하기떄문에 스타트함수에 호출 
         tower = GameObject.Find("Tower");//게임오브젝트중에 타워를 찾아라 

        //tower.transform.position;
        //tower.GetComponent<Transform>().position;
	}
		
	void Update ()
    {
        switch (state )
        {
            case State.Idle:
                Idle();
                break;
            case State.Walk:
                Walk();
                break;
            case State.Attack:
                Attack();
                break;

        }

        
	}
}
