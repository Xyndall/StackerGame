﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public enum direction { X, Z };
    public direction dir = direction.X;

    public GameObject CurrentPlatform = null;
    public GameObject LastPlatform = null;
    public Text Score = null;
    public int Level = 0;
    public bool endGame = false;
    public float speed = 120;


    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (endGame)
        {
            return;
        }

        //returns absoulute value of time
        var time = Mathf.Abs(Time.time % 2f - 1f);
        

        var pos1 = LastPlatform.transform.position + Vector3.up * 10f;
        //it takes pos1 position then moves the cube in either x or z coordinates, if the remainder of level / 2 == 0 run vector3.left else run vector3.forward * speed
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * speed;

        if (Level > 20)
        {
            time = Mathf.Abs(Time.time % 4f - 1f);

        }

        //uses pos1 and pos2 and moves the current platforms position 
        if (Level % 2 == 0)
        {
            
            CurrentPlatform.transform.position = Vector3.Lerp(pos2, pos1, time);
        }
        else
        {
            
            CurrentPlatform.transform.position = Vector3.Lerp(pos1, pos2, time);
        }




        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            NewBlock();
        }

        

    }


    void NewBlock()
    {
        if (LastPlatform != null)
        {
            //grabs the current cubes x y z position rounded to the nearest integer 
            CurrentPlatform.transform.position = new Vector3(Mathf.Round(CurrentPlatform.transform.position.x),
                    CurrentPlatform.transform.position.y,
             Mathf.Round(CurrentPlatform.transform.position.z));
            //sets the currentcubes scale using the position of the currentcube minus the last position of the last cube
            CurrentPlatform.transform.localScale = new Vector3(LastPlatform.transform.localScale.x - Mathf.Abs(CurrentPlatform.transform.position.x - LastPlatform.transform.position.x),
                                                           LastPlatform.transform.localScale.y,
                                                           LastPlatform.transform.localScale.z - Mathf.Abs(CurrentPlatform.transform.position.z - LastPlatform.transform.position.z));

            CurrentPlatform.transform.position = Vector3.Lerp(CurrentPlatform.transform.position, LastPlatform.transform.position, 0.5f) + Vector3.up * 5f;

            //if the currentcube 
            if (CurrentPlatform.transform.localScale.x <= 0f ||
               CurrentPlatform.transform.localScale.z <= 0f)
            {
                endGame = true;
                Score.gameObject.SetActive(true);
                Score.text = "Your Score " + Level;
                StartCoroutine(End());
                return;
            }

        }

        //instantiates a new current cube from the last cube
        LastPlatform = CurrentPlatform;
        CurrentPlatform = Instantiate(LastPlatform);
        CurrentPlatform.name = Level + "";
        CurrentPlatform.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        Level++;
        //makes the camera focus on the current cubes position and moves the camera up by the current cubes position
        Camera.main.transform.position = CurrentPlatform.transform.position + new Vector3(100, 70f, -100);
        Camera.main.transform.LookAt(CurrentPlatform.transform.position + Vector3.down * 30f);
        Score.text = Level + "";
    }


    IEnumerator End()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
