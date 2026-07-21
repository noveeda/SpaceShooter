using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Queue<GameObject> bulletPool;



    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int bulletCount = 30;

    
    
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject gameManager = GameObject.Find(typeof(GameManager).Name);
                if(gameManager == null)
                {
                    gameManager = new GameObject(typeof(GameManager).Name);
                    _instance = gameManager.AddComponent<GameManager>();
                }
                else
                {
                    _instance = gameManager.GetComponent<GameManager>();
                }
            }

            return _instance; 
        }
    }

    private void Start()
    {
        for(int i = 0; i < bulletCount; i++)
        {
            bulletPool = new Queue<GameObject>();
            GameObject obj = Instantiate<GameObject>(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject obj = bulletPool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void InputPool(GameObject obj)
    {
        obj.SetActive(false);
        bulletPool.Enqueue(obj);
    }

}
