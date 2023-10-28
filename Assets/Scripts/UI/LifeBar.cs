using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LifeBar : MonoBehaviour
{

    [SerializeField] private PlayerHealth _playerHealth;
    public GameObject myPrefab;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        CreateUI();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void CreateUI()
    {
        for (int i = 0; i < _playerHealth._health; i++)
        {
            Instantiate(myPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
        }
    }

    public void Damage()
    {
        Transform child = transform.GetChild(transform.childCount-1);
        Destroy(child.gameObject);
    }

   
}
