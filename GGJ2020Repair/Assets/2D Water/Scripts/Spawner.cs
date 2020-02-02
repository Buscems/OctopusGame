using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer, timerMax;
    public GameObject water;

    public Transform target;

    public float pushForce;

    public GameObject barrelEffect;

    public static int amountOfWaterParticles;

    // Start is called before the first frame update
    void Start()
    {

        amountOfWaterParticles = 0;

        target = GameObject.Find("Container").transform;
        try
        {
            barrelEffect.transform.up = (target.position - transform.position).normalized;
        }
        catch
        {

        }
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
        var temp = Instantiate(water, transform.position, transform.rotation);
        temp.transform.up = (target.position - temp.transform.position).normalized;
        temp.GetComponent<Rigidbody2D>().AddForce(temp.transform.up * pushForce);
        amountOfWaterParticles++;
    }
}
