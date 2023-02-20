using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Enemy"))
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }
}
