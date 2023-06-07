using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoint : MonoBehaviour
{

    public List<GameObject> waypoints;
    
    public float speed = 2;
    int index = 0;
    public GameObject polM;
    private bool stop = false;

    public Animator animatePolicemen;

    // Start is called before the first frame update
    void Start()
    {
        animatePolicemen = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.5&&stop!=true)
        {
            if (index <= waypoints.Count - 1)
            {



                if (index == 1 || index == 3)
                {
                    speed = 1;
                    animatePolicemen.Play("Walk");

                }
                else
                {             
                    speed = 2;
                    animatePolicemen.Play("Run");
                }

                index++;
                
                if (index == 4)
                {

                    speed = 0;

                    animatePolicemen.Play("Idle");
                    stop = true;
                    index = 0;
                }
                else
                    polM.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);



            }

        }
        


    }
}
