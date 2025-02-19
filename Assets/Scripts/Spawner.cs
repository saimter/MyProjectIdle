using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    //  몬스터를 맵에 특정 마리수를 몇초마다 반복해서 소환합니다.
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 5.0f;
    public float re_rate = 2.0f;

    public static List<Monster> monster_list = new List<Monster>();
    public static List<Player> player_list = new List<Player>();


    void Start()
    {
        StartCoroutine("SpwanMonsterPooling");
        //StartCoroutine("SpawnMonster");
    }

    IEnumerator SpawnMonster()
    {
        Vector3 pos;

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f;

            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonster");
    }

    IEnumerator SpwanMonsterPooling()
    {
        Vector3 pos;

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f;

            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            // 액션을 통해 기능 처리
            //var go = ScManagerGame.POOL.PoolObject("Monster").GetGameObject(); // 전달할 함수가 없는 경우(일반 생성)
            var go = ScManagerGame.POOL.PoolObject("SlimePBR").GetGameObject((result)=>
            {
                //result.GetComponent<Monster>().MonsterSample(); 디버그
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                monster_list.Add(result.GetComponent<Monster>());
            }); // 전달할 함수가 있는 경우(Action<GameObject>)
        }
        //StartCoroutine("ReturnMonsterPooling");

        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpwanMonsterPooling");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(1.0f);
        ScManagerGame.POOL.pool_dict["SlimePBR"].ObjectReturn(ob);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
