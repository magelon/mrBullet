using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public GameObject point;

    public Animator an;

    AudioSource audioData;

    private void Start()
    {
        point.SetActive(false);
        audioData = GetComponent<AudioSource>();
        poolManager.instance.CreatePool(bullet, 30);
    }

    void Update()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        if (Input.GetButton("Fire1"))
        {
            //show point
            point.SetActive(true);
            point.transform.position = pz;
           
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //fire
            an.SetTrigger("fire");
            audioData.Play(0);
            point.SetActive(false);
            GameObject bull = poolManager.instance.ReuseObject(bullet, firePos.transform.position, Quaternion.identity);//Instantiate(bullet, firePos.transform.position, Quaternion.identity);
            
            bull.GetComponent<Rigidbody2D>().AddForce((pz-firePos.transform.position).normalized * 100f);
        }
    }
}
