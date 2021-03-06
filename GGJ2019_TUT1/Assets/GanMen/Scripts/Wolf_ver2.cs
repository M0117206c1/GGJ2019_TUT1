﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_ver2 : MonoBehaviour
{
    public Vector3 chaseTarget;
    public GameObject player;
    [SerializeField]private Collider2D wall;
    [SerializeField] private bool isOnCollision;
    public float speed;
    public bool isChase;
    public float reach;
    //public Rigidbody2D rb;
    private bool canGo;
    public float distance;
    public bool isMove;
    private bool isNowMove;
    [SerializeField] private GameObject search;

    // Start is called before the first frame update
    void Start()
    {
        search = (GameObject)Resources.Load("Prefab/WolfSearch");
        isNowMove = isMove;
        StartChase();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChase == true)
        {
            transform.position = Vector3.Lerp(transform.position, chaseTarget, speed);
        }
        IsMove();
    }

    public void StartChase()
    {
        StartCoroutine(ChaseAI());
    }

    private IEnumerator ChaseAI()
    {
        isChase = true;
        if(Mathf.Abs(transform.position.y - player.transform.position.y) < Mathf.Abs(transform.position.x - player.transform.position.x))
        {
            chaseTarget = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            chaseTarget = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        while(isMove == true)
        {
            yield return null;
        }
        chaseTarget = player.transform.position;
        while (isOnCollision == false)
        {
            yield return null;
        }
        if (Mathf.Abs(transform.position.y - player.transform.position.y) < Mathf.Abs(transform.position.x - player.transform.position.x))
        {

            if (player.transform.position.y < transform.position.y)
            {
                WolfSearch ws0 = Instantiate(search, transform.position - new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                //yield return null; Debug.Log("ok");
                yield return new WaitForSeconds(1f);
                if (ws0.isOnCol == false)
                {
                    chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    WolfSearch ws1 = Instantiate(search, transform.position + new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                    if (ws1.isOnCol == false)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                        //Destroy(ws1.gameObject);
                    }
                    else
                    {
                        WolfSearch ws2 = Instantiate(search, transform.position + new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                        if (ws2.isOnCol == false)
                        {
                            chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
            else
            {

                WolfSearch ws0 = Instantiate(search, transform.position + new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                if (ws0.isOnCol == false)
                {
                    chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    WolfSearch ws1 = Instantiate(search, transform.position - new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                    if (ws1.isOnCol == false)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        //Destroy(ws1.gameObject);
                    }
                    else
                    {
                        WolfSearch ws2 = Instantiate(search, transform.position + new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                        if (ws2.isOnCol == false)
                        {
                            chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                WolfSearch ws0 = Instantiate(search, transform.position - new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                if (ws0.isOnCol == false)
                {
                    chaseTarget = new Vector3(transform.position.x - distance, transform.position.y , transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    WolfSearch ws01 = Instantiate(search, transform.position + new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                    if(ws01.isOnCol == false)
                    {
                        chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        //Destroy(ws01.gameObject);
                    }
                    else
                    {
                        WolfSearch ws2 = Instantiate(search, transform.position + new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                        if(ws2.isOnCol == false)
                        {
                            chaseTarget = new Vector3(transform.position.x , transform.position.y + distance, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
            else
            {
                WolfSearch ws0 = Instantiate(search, transform.position + new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                if (ws0.isOnCol == false)
                {
                    chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    WolfSearch ws01 = Instantiate(search, transform.position - new Vector3(reach, 0, 0), Quaternion.identity).GetComponent<WolfSearch>();
                    if (ws01.isOnCol == false)
                    {
                        chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        //Destroy(ws01.gameObject);
                    }
                    else
                    {
                        WolfSearch ws2 = Instantiate(search, transform.position - new Vector3(0, reach, 0), Quaternion.identity).GetComponent<WolfSearch>();
                        if (ws2.isOnCol == false)
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
        }

        while (isOnCollision == true)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Re");
        StartChase();


    }
    private void RayShoot(float x, float y)
    {
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0));
        int distance = 10;
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("false");
        }
    }
    private bool RayTest(float x, float y)
    {
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0).normalized);
        //new Vector3(transform.position.x * x, transform.position.y * y, transform.position.z));
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("false");
            return false;

        }

        else
        {
            return true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isOnCollision = true;
            wall = collision;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isOnCollision = false;
            //Invoke("AvoidReset", 1f);
            wall = null;
            Debug.Log("Exit");
        }

    }

    private void IsMove()
    {
        StartCoroutine(IsMove2());
    }

    private IEnumerator IsMove2()
    {
        Vector3 prePos = transform.position;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        if (Mathf.Abs(transform.position.y - prePos.y) < speed && (Mathf.Abs(transform.position.x - prePos.x) < speed))
        {
            prePos = transform.position;
            isMove = false;

        }
        else
        {
            isMove = true;
        }

    }
}
