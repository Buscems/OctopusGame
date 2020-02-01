using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer, timerMax;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timerMax)
        {
            timer = timerMax;
            MakeParticle();
        }
    }

    public void MakeParticle()
    {
        timer = 0;
        Instantiate(water, transform.position, transform.rotation);
    }
}
