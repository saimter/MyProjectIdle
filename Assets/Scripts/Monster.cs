using UnityEngine;
using UnityEngine.UI;

public class Monster : Character
{
    //Animator animator;
    public float monster_speed;
    public float rate = 2.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    public void MonsterSample()
    {
        //Debug.Log("몬스터가 생성되었습니다.");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Vector3.zero);

        // 간격 설정
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);
        if(target_distance <= rate)  // 간격 거리와 가까워지면 이동 중지
        {
            SetMotionChange("isMove", false);
        }
        else  // 일반적인 경우에는 움직임을 진행한다.
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                Vector3.zero,
                Time.deltaTime * monster_speed
            );
            SetMotionChange("isMove", true);
        }
    }

    //protected override void SetMotionChange(string motion_name, bool param)
    //{
    //    base.animator.SetBool(motion_name, param);
    //}
}
