using UnityEngine;
using UnityEngine.UI;


public class ScManagerGame : MonoBehaviour
{
    public static ScManagerGame instance = null;

    public static ManagerPool pool_manager = new ManagerPool();
    public static ManagerPool POOL 
    {
        get {
            return pool_manager;
        }
    }

    public Text txtMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Resources 폴더가 반드시 필요한 코드
    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
