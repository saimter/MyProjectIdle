using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start() // 자식이 start()를 수정해도 virtual을 선언했기 때문에 가능하다.
    {
        animator = GetComponent<Animator>();
     }


    public double hp;   
    public double atk;          //  공격력
    public float attack_speed;  // 공격 속도

    protected float attack_range = 3.0f;  // 공격 범위
    protected float target_range = 5.0f;   // 타겟에 대한 범위

    protected Transform target;

    //  애니메이션에 의해 호출된 함수
    protected virtual void Thrown()
    {
        Debug.Log("공격!");
    }



    protected void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);
    }


    // 타겟을 찾는 기능
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets;        // 전달 받은 값을 통해 할당.
        Transform closet = null;            // 가장 가까운 값은 현재 null
        float max_distance = target_range;  // 최대 거리 == 타겟의 거리

        // 타겟을 전체를 대상으로 거리를 체크
        foreach (var unit in units)
        {
            // 거리체크
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            //  타겟 거리보다 작으면 가장 가까운 값
            if (distance < max_distance)
            {
                closet = unit.transform;
                max_distance = distance;
            }
        }
        // 타겟 적응
        target = closet;

        if(target != null)
        {
            transform.LookAt(target.position);
        }
    }
}
