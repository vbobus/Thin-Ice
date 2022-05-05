using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator instance;


    [SerializeField] private GameObject midTilePrefab;
    [SerializeField] private GameObject sideTilePrefab;


    [SerializeField] private int amountOfRows;
    [SerializeField] private int tilesPerRow;

    [SerializeField] private int tileWidth;
    [SerializeField] private int tileLength;

   
    private List<Tile> createdTiles = new List<Tile>();
    private List<GameObject> createdRows = new List<GameObject>();


    private int rowIndexToGenerate;
    private int currentFurthestRow;
    private List<Tile> possibleNextSteps = new List<Tile>();

    private void Awake()
    {
        //<< Generate singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }



    void Start()
    {
        FirstGeneration();
        PathGeneration();
    }


    public void StepOnTile(int lnTileRow)
    {
        if (lnTileRow == rowIndexToGenerate)
        {
            currentFurthestRow++;
            rowIndexToGenerate++;

            GenerateNewRow(currentFurthestRow);            
            
        }
    }


    private void GenerateNewRow(int x)
    {
        for (int y = 0; y < tilesPerRow; y++)
        {
            GameObject loTilePrefab;

            if (y == 0)
            {
                loTilePrefab = Instantiate(sideTilePrefab);
                loTilePrefab.transform.position = new Vector3((-tileWidth * 2) + (y * tileWidth), 0.0f, tileLength * x);
                loTilePrefab.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

            }
            else if (y == tilesPerRow - 1)
            {
                loTilePrefab = Instantiate(sideTilePrefab);
                loTilePrefab.transform.position = new Vector3((-tileWidth * 2) + (y * tileWidth), 0.0f, tileLength * x);
            }
            else
            {
                loTilePrefab = Instantiate(midTilePrefab);
                loTilePrefab.transform.position = new Vector3((-tileWidth * 2) + (y * tileWidth), 0.0f, tileLength * x);
            }

            //<< Get the component Tile and add it to the current List of tiles. Set the Tile.
            Tile loTile = loTilePrefab.GetComponent<Tile>();
            loTile.SetTile(x, y);

            createdTiles.Add(loTile);
        }
    }


    private void PathGeneration()
    {
        int xValue = Random.Range(0, 3);

        int lnOrder = 0;

        Tile currentTileOnPath = createdTiles.Where(x => x.tileRow == 0 && x.tileColumn == xValue).FirstOrDefault();
        currentTileOnPath.SetAsSelected(lnOrder);


        bool keepSelecting = true;

        int currentRow = 0;
        int currentTilesInRow = 1;

        while (keepSelecting)
        {
            possibleNextSteps.Clear();

            //<< Ask if you want to go left
            AddIfExists(currentTileOnPath.tileRow, currentTileOnPath.tileColumn - 1);
            AddIfExists(currentTileOnPath.tileRow, currentTileOnPath.tileColumn + 1);

            //<< Ask if you want to go front
            AddIfExists(currentTileOnPath.tileRow + 1, currentTileOnPath.tileColumn - 1);
            AddIfExists(currentTileOnPath.tileRow + 1, currentTileOnPath.tileColumn);
            AddIfExists(currentTileOnPath.tileRow + 1, currentTileOnPath.tileColumn + 1);

            if (possibleNextSteps.Count > 0)
            {
                lnOrder++;
                int nextTileIndex = Random.Range(0, possibleNextSteps.Count);
                currentTileOnPath = possibleNextSteps[nextTileIndex];

                if (currentRow == currentTileOnPath.tileRow)
                {
                    currentTilesInRow++;
                    if (currentTilesInRow > 3)
                    {
                        currentTileOnPath.tileDisabled = true;
                        continue;
                    }
                } else
                {
                    currentRow = currentTileOnPath.tileRow;
                    currentTilesInRow = 1;
                }


                currentTileOnPath.SetAsSelected(lnOrder);
            }
            else
            {
                keepSelecting = false;
            }
        }
    }

    private void AddIfExists(int xIndex, int yIndex)
    {
        Tile possibleNextTile = createdTiles.Where(x => x.tileRow == xIndex && x.tileColumn == yIndex && x.tileSelected == false && x.tileDisabled == false).FirstOrDefault();
        if (possibleNextTile)
        {
            possibleNextSteps.Add(possibleNextTile);
        }
    }


    private void FirstGeneration()
    {
        //tileGrid = new GameObject[amountOfRows, tilesPerRow];

        for (int x = 0; x < amountOfRows; x++)
        {
            GenerateNewRow(x);
        }

        //<< Sets the latest generated row as the currentFurthestRow
        rowIndexToGenerate = amountOfRows / 2;
        currentFurthestRow = amountOfRows - 1;
    }
}
        
    

