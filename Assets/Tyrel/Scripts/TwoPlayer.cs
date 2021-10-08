using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TwoPlayer : MonoBehaviour
{

    public Manager manager = null;
    public Manager1 manager1 = null;

    public int player = 2;

    public Text WinningText = null;
    //public GameObject Light = null;

    // Start is called before the first frame update
    void Start()
    {
        WinningText.gameObject.SetActive(false);
        //Light.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        switch (player)
        {
            case 1:
                manager.GetComponent<Manager>().CameraLook();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    manager.GetComponent<Manager>().NewBlock();
                    //manager.GetComponent<Manager>().InstantiatePlatform();
                    player++;

                }

                break;
            case 2:
                manager1.GetComponent<Manager1>().CameraLook();
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    manager1.GetComponent<Manager1>().NewBlock();
                    //manager1.GetComponent<Manager1>().InstantiatePlatform();
                    player++;

                }
                break;
        }

        if(player > 2)
        {
            player = 1;
        }

        if (manager.GetComponent<Manager>().CurrentPlatform.transform.localScale.x <= 0f ||
               manager.GetComponent<Manager>().CurrentPlatform.transform.localScale.z <= 0f)
        {
            manager.GetComponent<Manager>().endGame = true;
            manager.GetComponent<Manager>().Score.gameObject.SetActive(true);            
            StartCoroutine(End());
            return;
        }

        if (manager1.GetComponent<Manager1>().CurrentPlatform.transform.localScale.x <= 0f ||
               manager1.GetComponent<Manager1>().CurrentPlatform.transform.localScale.z <= 0f)
        {
            manager1.GetComponent<Manager1>().endGame = true;
            manager1.GetComponent<Manager1>().Score.gameObject.SetActive(true);
            StartCoroutine(End());
            return;
        }

        //StartCoroutine(LightsOff());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    
    //IEnumerator LightsOff()
    //{
    //    yield return new WaitForSeconds(5f);
    //    Light.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(5f);
    //    Light.gameObject.SetActive(true);
    //}

    IEnumerator End()
    {


        if (manager1.GetComponent<Manager1>().Level > manager.GetComponent<Manager>().Level)
        {
            WinningText.gameObject.SetActive(true);
            WinningText.GetComponent<Text>().color = Color.yellow;
            WinningText.text = "Yellow Wins";
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(0);

        }
        else if (manager.GetComponent<Manager>().Level > manager1.GetComponent<Manager1>().Level)
        {
            WinningText.gameObject.SetActive(true);
            WinningText.GetComponent<Text>().color = Color.blue;
            WinningText.text = "Blue Wins";
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(0);
        }
        else
        {

        }



    }
}
