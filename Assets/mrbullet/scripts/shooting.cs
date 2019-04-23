using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePos;
    public GameObject point;

    private void Start()
    {
        point.SetActive(false);
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
            point.SetActive(false);
            GameObject bull = Instantiate(bullet, firePos.transform.position, Quaternion.identity);
            bull.GetComponent<Rigidbody2D>().AddForce((pz-firePos.transform.position).normalized * 100f);
        }
    }
}
