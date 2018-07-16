using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{




    public GameObject ball = null;

    Animator ani = null; // 애니매이터 컴포넌트에 접근 
    Vector3 enemyPos; //클릭된 몬스터 위치 저장 값 ,멤버변수

    //지역변수와 멤버변수의 차이 
    

    public void OnShot() //애니메이션 이벤트 호출 
    {    //1.볼생성 
        GameObject obj = Instantiate(ball); //생성 
        obj.transform.position = transform.position;

        Vector3 dir = enemyPos - transform.position;  //방향 벡터 계산
        // -1.0~1.0까지 방향벡터

        dir.Normalize(); //벡터자체를 방향벡터로 만들어준다.(5->1)
        // dir = dir.normalized;  대입을 해야 값이 나오고 왼쪽값이 있어야한다.


         Rigidbody rig =  obj.GetComponent<Rigidbody>(); //obj 볼 있는 rigidbody  ,,리지드바디 물리엔진을 이용해 속도 함수 사용
        rig.velocity = dir * 20; //물리 속도 값 세팅 





    }


    public void Shot(Vector3 pos) // 공격 애니메이션 동작 작동  , 위치가 필요하므로 벡터3사용하고 pos는 x,y,z값
    {
        //int a = 10; 지역변수 함수 호출시시작해서 끝날때 끝난다
        // 벡터에너미 포스는 멤버변수ㅏ

         enemyPos = pos; //Vector3 값을 복사한다. 지역변수 
         ani.SetTrigger("Attack");// attack trigger 호출 함수 
    }

	
	void Start ()
    {
       ani = GetComponent<Animator>(); //시작시에 애니매이터 컴포넌트 가져오기 
	}
	
	
	
}
