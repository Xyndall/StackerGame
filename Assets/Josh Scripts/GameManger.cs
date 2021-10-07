using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private GameObject[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    public GameObject platform = null;
    GameObject currentCube = null;
    GameObject LastCube = null;
    float height = 0.1f;

    float xSize = 1;
    float zSize = 1;

    Vector3 CurrentCube = Vector3.zero;

    private void Awake()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawners");
    }
    private void Start()
    {
        platform.transform.localScale = new Vector3(1, 0.1f, 1);
        spawnPlatform(spawnerIndex, height);
        spawnerIndex++;
        Debug.Log(spawnerIndex + "   manager");
    }

    private void Update()
    {
        if (spawnerIndex > spawners.Length-1)
        {
            Debug.Log("Hit");
            spawnerIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spawnPlatform(spawnerIndex, height);
            spawnerIndex++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            platform.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        }

    }



    void spawnPlatform(int value, float height)
    {
        
        GameObject platform = Instantiate(this.platform, new Vector3(spawners[value].transform.position.x, height, spawners[value].transform.position.z), transform.rotation);
        platform.GetComponent<MeshRenderer>().material.SetColor("_color", Color.HSVToRGB(1f, 1f, 1f));
        platform.transform.localScale = new Vector3( xSize -= 0.1f, 0.1f, zSize -= 0.1f);
        this.height += 0.1f;
        platform.GetComponent<Platform>().myDir(value);
    }

    void HangOver()
    {
        CurrentCube = transform.localScale;

        platform = currentCube;


    }
    

}
