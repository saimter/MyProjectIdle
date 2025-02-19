using System;
using System.Collections.Generic;
using UnityEngine;

//  Ǯ(������)
//  ������Ʈ�� Ǯ�� ����� �ΰ� �ʿ��� ������ Ǯ �ȿ� �ִ� ��ü�� ������ ����ϴ� ���
//  �Ź� �ǽð����� �ı��ϰ�, �����ϴ� �ͺ��� CPI�� �δ��� ���� �� �ִ�.
//  ��� �̸� �Ҵ��صδ� ����̱� ������ �޸𸮸� ����ؼ� ������ ���̴� ��� 
//  Ǯ�� ���� �۾��� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{ 
    // Property
    Transform parent { get; set; }
    Queue<GameObject> pool { get; set; }    // FIFO

    // Function
    //  default parameter : ���� ���� ���� �ʾ��� ��� ������ ������ �ڵ� ó���ȴ�.
    //  ex) var go = GetGameObject();
    //  ex) var go = GetGameObject(action);

    // ���͸� �������� ���
    GameObject GetGameObject(Action<GameObject> action = null);

    //  ���͸� �ݳ��ϴ� ���
    void ObjectReturn(GameObject gameObject, Action<GameObject> acton = null);
}
public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue();   // Ǯ�� �ִ°� �ϳ� �̾� ���ڴ�.
        obj.SetActive(true);        // ������Ʈ Ȱ��ȭ ����
        if(action != null)
        {
            // ���� ���� �׼��� ����
            //  ?�� null�� ���� ����
            action?.Invoke(obj);
        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);

        if(action != null)
        {
            action?.Invoke(ob);

        }
    }
}

public class ManagerPool : MonoBehaviour
{

    //  key : string
    //  Value : IPool
    public Dictionary<string, IPool> pool_dict = new Dictionary<string, IPool>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public IPool PoolObject(string path)
    {
        // �ش� Ű�� ���ٸ� �߰��� �����մϴ�.
        if(!pool_dict.ContainsKey(path))
        {
            Add(path);
        }
        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }
        return pool_dict[path];
    }
    public GameObject Add(string path)
    {
        // ���� ���� �̸����� Ǯ ������Ʈ ����
        var obj = new GameObject(path + "Pool");

        //  ������Ʈ Ǯ ����
        ObjectPool object_pool = new ObjectPool();

        pool_dict.Add(path, object_pool);

        // ��ο� ������Ʈ Ǯ�� ��ųʸ��� ����
        object_pool.parent = obj.transform;

        return obj;

    }
    
    public void AddQ(string path)
    {
        var go = ScManagerGame.instance.CreateFromPath(path);
        go.transform.parent = pool_dict[path].parent;
        pool_dict[path].ObjectReturn(go);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
