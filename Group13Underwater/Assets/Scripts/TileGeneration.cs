using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;
using System;

/// <summary>
/// Responsible for dirt tile generation
/// -Steven
/// </summary>
public class TileGeneration : MonoBehaviour
{
    private int mapWidth = 40; //NEEDS TO BE EVEN
    private int generationHeight = 100;


    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile[] tiles;

    private enum DigType {oneXone, twoXoneLeft, twoXoneRight, threeXone, fiveXone, sevenXone, nineXone}


    private void Awake()
    {
        tiles = Resources.LoadAll<Tile>("Steven/Tiles");
    }


    void Start()
    {
        //tilemap.SetTile(new Vector3Int(0, 0, 0), tiles[0]);

        Debug.Log(Time.time);
        fillRectangle(new Vector3Int(-mapWidth/2, -6, 0), mapWidth, generationHeight, tiles[0]);
        createTunnel(new Vector3Int(0, -6, 0), new DigType(), new Vector3Int(-mapWidth / 2, -6, 0), mapWidth, generationHeight);
        Debug.Log(Time.time);
    }




    /// <summary>
    /// Fills a rectangle with the inputted tile. The rectangle generates with the inputted position at the top left corner.
    /// </summary>
    /// <param name="topLeftCornerPosition">Disired position of the rectangles top left corner.</param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void fillRectangle(Vector3Int topLeftCornerPosition, int width, int height, Tile fillTile)
    {
        Vector3Int position = topLeftCornerPosition;
        for (int x = topLeftCornerPosition.x; x < topLeftCornerPosition.x + width; x++)
        {
            for (int y = topLeftCornerPosition.y; y > topLeftCornerPosition.y - height; y--)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), fillTile);
            }
        }
    }

    /// <summary>
    /// Digs a tunnel from top to bottom. Input the top left corner of desired digging area.
    /// </summary>
    /// <param name="startingPosition">Start position of the tunnel.</param>
    /// <param name="initialDigType"></param>
    /// <param name="topLeftCornerPosition">Top left of desired digging area.</param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void createTunnel(Vector3Int startingPosition, DigType initialDigType, Vector3Int topLeftCornerPosition, int width, int height) {

        Vector3Int position = startingPosition;
        int leftBoundary = topLeftCornerPosition.x;
        int rightBoundary = topLeftCornerPosition.x + width - 1;
        
        int randomDirection = 0;
        int moveDownPityTimer = 0;

        DigType digType = initialDigType;
        



        while (position.y > startingPosition.y - height)
        {
            //TEST IF CHANGE DIGTYPE
            int randint = UnityEngine.Random.Range(1, 21);
            if (randint > 18) {

                //CHANGE DIGTYPE
                randint = UnityEngine.Random.Range(1, 8);
                if (randint == 1) { digType = DigType.oneXone; }
                if (randint == 2) { digType = DigType.twoXoneLeft; }
                if (randint == 3) { digType = DigType.twoXoneRight; }
                if (randint == 4) { digType = DigType.threeXone; }
                if (randint == 5) { digType = DigType.fiveXone; }
                if (randint == 6) { digType = DigType.sevenXone; }
                if (randint == 7) { digType = DigType.nineXone; }
            }




            //DIG
            if (digType == DigType.oneXone)
            {
                tilemap.SetTile(position, null);
            }
            else if (digType == DigType.twoXoneLeft)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
            }
            else if (digType == DigType.twoXoneRight)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
            }
            else if (digType == DigType.threeXone)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
            }
            else if (digType == DigType.fiveXone) 
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 2, position.y), null);
            }
            else if (digType == DigType.fiveXone)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 2, position.y), null);
            }
            else if (digType == DigType.sevenXone)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 3, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 3, position.y), null);
            }
            else if (digType == DigType.nineXone)
            {
                tilemap.SetTile(position, null);
                tilemap.SetTile(new Vector3Int(position.x - 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 1, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 2, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 3, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 3, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x - 4, position.y), null);
                tilemap.SetTile(new Vector3Int(position.x + 4, position.y), null);
            }




            //MOVE
            if (moveDownPityTimer < 5)
            {
                randomDirection = UnityEngine.Random.Range(1, 4);
                if (randomDirection == 1) { 
                    position.y--; 
                    moveDownPityTimer = 0; 
                }
                else if (randomDirection == 2 && position.x > leftBoundary+5) { 
                    position.x--; 
                    moveDownPityTimer++; 
                }
                else if (randomDirection == 3 && position.x < rightBoundary-5) { 
                    position.x++; 
                    moveDownPityTimer++; 
                }
            }
            //PITY MOVE DOWN
            else { 
                position.y--; 
                moveDownPityTimer = 0; 
            }
        }
        

    }
}