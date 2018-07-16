using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Tower : MonoBehaviour {

    public Image hp = null;
    public GameObject particle = null;
    bool isDead = false; //
   

	// Use this for initialization
	void Start ()
    {
       // hp.fillAmount = 0.5f; ,TEST 피가 반이되는 기능

        Time.timeScale = 0;//pause처리

	}

    public void DamageByEnemy()//enemy 호출
    { 
        if (isDead == true)
        {
            return; //Damageyenemy 함수를 나가라 
        }


       

        hp.fillAmount -= 0.01f; // -0.01f 만큼 감소 
        
        //<= 0이 크거나 같으면 
        if (hp.fillAmount <= 0)
        {
         isDead = true;
            //파티클 출력 
            GameObject obj = Instantiate(particle); // obj 지정 후 파티클생성값을 주소에 추가 
            obj.transform.position = transform.position; //오브젝트위치를 타워 위치로 
            

            
        }

    }


	public void OnGameStart() //Ui버튼 호출 
    {
        Time.timeScale = 1;//시간의흐름 1일경우 정상,2일경우 2배 
        
    }




	// Update is called once per frame
	
}
