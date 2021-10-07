using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayer : MonoBehaviour
{

    public Manager manager = null;
    public Manager1 manager1 = null;

    public int player = 2;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        switch (player)
        {
            case 1:
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    manager.GetComponent<Manager>().NewBlock();
                    player++;
                    manager.GetComponent<Manager>().InstantiatePlatform();
                }

                break;
            case 2:
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    manager1.GetComponent<Manager1>().NewBlock();
                    player++;
                    manager.GetComponent<Manager>().InstantiatePlatform();
                }
                break;
        }

        if(player > 2)
        {
            player = 1;
        }
    }
}
