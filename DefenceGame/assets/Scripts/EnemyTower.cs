using UnityEngine;
using System.Collections;

public class EnemyTower : MonoBehaviour
{
    public GameObject enemy = null; //enemy 프리팹 주소값 만들기위해서 만듬 

    //2d ui는 해상도설정 



    void Start ()
    {
        InvokeRepeating("CreateEnemy",0,5);//3초마다 이함수 호출 반복할떄 사용 // 에너미 재생성 
	}
	void CreateEnemy()
    {
      GameObject obj = Instantiate(enemy);  //obj에 함수 주소값 담고
                                            //함수안에 만들어진 변수는 지역변수
        obj.transform.SetParent(transform ,true);// EnemyTower 자식으로 등록  , 스크립트하고 컴포넌트가 자체적으로 등록되어있어서 자신의 트랜스폼을 입력,false는 부모의 영향을 

        //자식입장에서 부모를 선택하는 기능
      obj.transform.position = transform.position; //위치 기록 

    }
	

}
