using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    Vector3 start_pos;
    Quaternion rotation;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        // zoflrxj zmffotmdml ,start tlwkr
        base.Start();
        start_pos = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            // ����� Ÿ�� ����
            TargetSearch(Spawner.monster_list.ToArray());
            // ����Ʈ��.ToArray()�� ���� list -> array

            float pos = Vector3.Distance(transform.position, start_pos);
            if(pos > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, start_pos, Time.deltaTime);
                transform.LookAt(start_pos);
                SetMotionChange("isMove",true);
            }
            else
            {
                transform.rotation = rotation;
                SetMotionChange("isMOve", false);
            }
            return; // �۾� ����, ���� �ڵ���� �������� �ʴ´�.
        }
        
        //  Ÿ�� �������� ������ ����
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= target_range && distance > attack_range)
        {
            SetMotionChange("isMove", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        else if(distance < attack_range)
        {
            SetMotionChange("isATTACK", true);
        }
    }
}
