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
        //Debug.Log("���Ͱ� �����Ǿ����ϴ�.");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Vector3.zero);

        // ���� ����
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);
        if(target_distance <= rate)  // ���� �Ÿ��� ��������� �̵� ����
        {
            SetMotionChange("isMove", false);
        }
        else  // �Ϲ����� ��쿡�� �������� �����Ѵ�.
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
