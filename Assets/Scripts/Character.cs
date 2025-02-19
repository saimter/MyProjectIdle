using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start() // �ڽ��� start()�� �����ص� virtual�� �����߱� ������ �����ϴ�.
    {
        animator = GetComponent<Animator>();
     }


    public double hp;   
    public double atk;          //  ���ݷ�
    public float attack_speed;  // ���� �ӵ�

    protected float attack_range = 3.0f;  // ���� ����
    protected float target_range = 5.0f;   // Ÿ�ٿ� ���� ����

    protected Transform target;

    //  �ִϸ��̼ǿ� ���� ȣ��� �Լ�
    protected virtual void Thrown()
    {
        Debug.Log("����!");
    }



    protected void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);
    }


    // Ÿ���� ã�� ���
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets;        // ���� ���� ���� ���� �Ҵ�.
        Transform closet = null;            // ���� ����� ���� ���� null
        float max_distance = target_range;  // �ִ� �Ÿ� == Ÿ���� �Ÿ�

        // Ÿ���� ��ü�� ������� �Ÿ��� üũ
        foreach (var unit in units)
        {
            // �Ÿ�üũ
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            //  Ÿ�� �Ÿ����� ������ ���� ����� ��
            if (distance < max_distance)
            {
                closet = unit.transform;
                max_distance = distance;
            }
        }
        // Ÿ�� ����
        target = closet;

        if(target != null)
        {
            transform.LookAt(target.position);
        }
    }
}
