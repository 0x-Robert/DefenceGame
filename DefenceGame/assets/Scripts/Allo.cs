using UnityEngine;
using System.Collections;




public enum Alstate
{
    Idle,
    Walk,
    Attack

}





public class Allo : MonoBehaviour {
    float interval = 0; //시간누적 
    Animator ani = null;
    Alstate state = Alstate.Idle; //enum 지정 , switch담는 저장소, idle
    GameObject soldier = null;

    void OnMouseDown()
    {
        //  Destroy(gameObject);
       // Soldier soldier = GameObject.FindObjectOfType<Soldier>();
        //soldier.Shot(transform.position);

    }

    public void OnAttack()
    {
      //  Soldier s = soldier
    }
     
    void Idle()
    {
        interval += Time.deltaTime;
        //시간누적 

        if (interval > 3)
        {
            state = Alstate.Walk;
            ani.SetTrigger("Walk");// walk호출 
            interval = 0;//walk ani 호출 

        }
    }
    void Walk()
    {
        Vector3 dir = soldier.transform.position - transform.position;
        //dir = 타겟 -내위치 = 방향값 +,-

        dir.Normalize();//방향값 계산해주는 함수 // 방향값 -1~1

        transform.position += dir * 1 * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);

        Vector3 soldierPos = soldier.transform.position;
        Vector3 alloPos = transform.position;

        float distance = Vector3.Distance(soldierPos, alloPos);

        if (distance < 1.6f)
        {
            state = Alstate.Attack;
            interval = 5;
        }


    }
    void Attack()
    {
        interval += Time.deltaTime;

        if(interval > 5)
        {
            ani.SetTrigger("Attack");
            interval = 0;
        }


    }


    void Start ()
    {
        ani = GetComponent<Animator>();
        soldier = GameObject.Find("Solder");

	}
	
	
	void Update ()
    {

        switch (state)
        {
            case Alstate.Idle:
                Idle();
                break;

            case Alstate.Walk:
                Walk();
                break;
            case Alstate.Attack:
                Attack();
                break;
        }
	
	}
}
