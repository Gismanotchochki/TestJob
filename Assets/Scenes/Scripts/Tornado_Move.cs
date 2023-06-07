using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Move : MonoBehaviour
{
    public List<GameObject> waypoints;

    public float speed = 2;
    int index = 0;
    
    private bool stop = false;

    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.5 && stop != true)
        {
            if (index <= waypoints.Count - 1)
            {


                index++;

                if (index == 4)
                {

                speed = 0;


                stop = true;
                    
                }
            }
        }
          

        



    }
}
