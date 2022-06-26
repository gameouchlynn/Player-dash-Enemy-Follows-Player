using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makezombie : MonoBehaviour
{
    public GameObject zombie, newzombie;
    
     public float timer = 0;
    public float TimeDiff;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
        if (timer > TimeDiff)
        {
        newzombie = Instantiate(zombie);
        newzombie.transform.position = new Vector3(Random.Range(24.9f, -18.51f), -2.04f, 0f );
        timer = 0;
         }
    }

    
}
