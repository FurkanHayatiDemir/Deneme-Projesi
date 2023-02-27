using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCube : MonoBehaviour
{
    public static RandomCube instance;

    public Transform spawnLocation;

    public GameObject[] pieces;

    public Text scoreText;

    int score = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {

            Instantiate(pieces[UnityEngine.Random.Range(0, 3)], spawnLocation.position, spawnLocation.rotation); //küp oluþturma instantiate
        }
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString();

    }
}
