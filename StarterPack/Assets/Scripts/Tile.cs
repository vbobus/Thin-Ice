using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public int tileRow;

    public int tileColumn;

    public bool tileSelected = false;

    public bool tileDisabled = false;

    [SerializeField]
    private Material correctPathMat;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!tileSelected)
            {
                collision.gameObject.GetComponent<Penguin>().KillPenguin();
            }
        }
    }

    public void SetTile(int lnTileRow, int lnTileColumn)
    {
        tileRow = lnTileRow;
        tileColumn = lnTileColumn;
    }

    public void SetAsSelected(int lnOrder)
    {
        tileSelected = true;
        GetComponent<Renderer>().material = correctPathMat;
    }
}
