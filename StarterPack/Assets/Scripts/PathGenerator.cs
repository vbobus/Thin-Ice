using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] cubes;

    private GameObject[,] cubeLayout = new GameObject[3,3];

    [SerializeField] private int gridWidth = 3;
    [SerializeField] private int gridLenght = 1;

    [SerializeField] private Material correctPathMat;


    private void Start()
    {
        int i = 0;
        for (int y = 0; y < gridLenght; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                cubeLayout[x, y] = cubes[i];
                i++;
            }
        }


        //<< StartingPoint
        int xValue = Random.Range(0, 3);
        cubeLayout[xValue, 0].GetComponent<Renderer>().material = correctPathMat;

        int yValue = 0;


        while (yValue <= 2)
        {
            int nextX = xValue;
            //int nextY = 0;


            //int xStarting = 0;
            //int xEnding = 3;


            bool goSraight = Random.Range(0, 2) == 0 ? true : false;

            if (goSraight)
            {
                yValue++;
                cubeLayout[nextX, yValue].GetComponent<Renderer>().material = correctPathMat;
            }
            else
            {
                Debug.Log("Left or Right");
                //<< Next point
                if (xValue == 0 || xValue == 2)
                {
                    nextX = 1;
                }

                if (xValue == 1)
                {
                    bool goRight = Random.Range(0, 2) == 0 ? true : false;
                    if (goRight)
                        nextX = 2;
                    else
                        nextX = 0;
                }

                cubeLayout[nextX, yValue].GetComponent<Renderer>().material = correctPathMat;
            }
        }













    }


}
