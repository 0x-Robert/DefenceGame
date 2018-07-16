using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{ 
    public GameObject particle = null; //파티클출력 



    /*
    void OnTriggerEnter(Collider other) //단순충돌적용,is trigger 체크 
    { }
    */

    void OnCollisionEnter(Collision other) //물리적충돌사용시에 사용 무너지거나 부딫치는거나 밀린는 작용은 

    {
        GameObject obj = Instantiate(particle); //생성
        obj.transform.position = transform.position;   //위치
        //this.gameObject;
       

        if(other.gameObject.tag== "Enemy") //태그값이 에너미일때만 파괴해라 
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject); //파괴기능 

       
        
    }


	
}
