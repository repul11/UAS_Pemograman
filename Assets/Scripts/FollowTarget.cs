using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FollowTarget : MonoBehaviour
{
    public Transform player; 
    public Transform Bg1; 
    public Transform Bg2; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x != transform.position.x && player.position.x > 0 && player.position.x < 20f) 
         {
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(player.position.x, transform.position.y, transform.position.z), 0.1f);
         }

        Bg1.transform.position = new Vector2(transform.position.x * 1.0f, Bg1.transform.position.y);
        Bg2.transform.position = new Vector2(transform.position.x * 0.8f, Bg2.transform.position.y);
        
    }

}

