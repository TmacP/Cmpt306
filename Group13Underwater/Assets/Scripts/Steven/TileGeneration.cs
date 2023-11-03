using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;
using System;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using static UnityEditor.Progress;

/// <summary>
/// Responsible for dirt tile generation
/// -Steven
/// </summary>
public class TileGeneration : MonoBehaviour
{
    private int generationWidth = 40; //NEEDS TO BE EVEN
    private int generationHeight = 100;
    private int generationEndYPos = 0; //Y position of the bottom of the current generated area
    //private int currentCrawlerXPos = 0;
    private (int, int) crawlerBounds = (0, 2); //THIS WILL SET THE CAVE ENTRANCE POSITION

    int minimumCaveWidth = 2;

    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile[] tiles;

    private enum DigType {oneXone, twoXoneLeft, twoXoneRight, threeXone, fiveXone, sevenXone, nineXone}
    private enum Direction {left, right}

    
    //-------------------------------------------
    private float crawlerChanceToGrow = 0.3f;

    private float crawlerChanceToGrowLeft = 0.5f;

    private float crawlerChanceToGrow1 = 0.8f;
    private float crawlerChanceToGrow2 = 0.15f;
    private float crawlerChanceToGrow3 = 0.05f;
    //-------------------------------------------
    private float crawlerChanceToShrink = 0.3f;

    private float crawlerChanceToShrinkLeft = 0.5f;

    private float crawlerChanceToShrink1 = 0.8f;
    private float crawlerChanceToShrink2 = 0.15f;
    private float crawlerChanceToShrink3 = 0.05f;
    //-------------------------------------------


    private void Awake()
    {
        tiles = Resources.LoadAll<Tile>("Steven/Tiles");
    }


    void Start()
    {
        //tilemap.SetTile(new Vector3Int(0, 0, 0), tiles[0]);

        //Debug.Log(Time.time);
        //fillRectangle(new Vector3Int(-mapWidth/2, -6, 0), mapWidth, generationHeight, tiles[0]);
        //createTunnel(new Vector3Int(0, -6, 0), new DigType(), new Vector3Int(-generationWidth / 2, -6, 0), generationWidth, generationHeight);
        //Debug.Log(Time.time);
    }

    void FixedUpdate() {
        Vector3 playerPosition = GameManager.instance.GetPlayerPosition();
        //if (playerPosition.y < generationEndYPos + 20) {
        //    fillRectangle(new Vector3Int(-mapWidth/2, generationEndYPos, 0), mapWidth, generationHeight, tiles[0]);
        //    currentCrawlerXPos = createTunnel(new Vector3Int(currentCrawlerXPos, generationEndYPos, 0), new DigType(), new Vector3Int(-mapWidth / 2, generationEndYPos, 0), mapWidth, generationHeight);
        //    generationEndYPos -= generationHeight;
        //}

        if (playerPosition.y < generationEndYPos + 20) {
            fillRectangle(new Vector3Int(-generationWidth / 2, generationEndYPos, 0), generationWidth, generationHeight, tiles[0]);
            crawlerBounds = createTunnel2(crawlerBounds, new Vector3Int(-generationWidth / 2, generationEndYPos, 0), generationWidth, generationHeight);
            generationEndYPos -= generationHeight;
        }


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
    /*private int createTunnel(Vector3Int startingPosition, DigType initialDigType, Vector3Int topLeftCornerPosition, int width, int height) {

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
        return position.x;

    }*/

    private (int, int) createTunnel2((int, int) bounds, Vector3Int topLeftCornerPosition, int width, int height)
    {
        int yPosition = topLeftCornerPosition.y;
        int leftGenerationBoundary = topLeftCornerPosition.x;
        int rightGenerationBoundary = topLeftCornerPosition.x + width;
        int crawlerSize = bounds.Item2 - bounds.Item1;


        while (yPosition > (topLeftCornerPosition.y - height))
        {
            //crawlerSize = bounds.Item2 - bounds.Item1;

            //DIG
            for (int i = bounds.Item1; i < bounds.Item2; i++) {

                tilemap.SetTile(new Vector3Int(i, yPosition), null);
            }


            Direction dir;
            int dis;
            float rand;

            //GROW
            dir = new Direction();
            dis = 0;
            rand = UnityEngine.Random.value; //CHOOSE IF GROWING
            if (rand < crawlerChanceToGrow)
            {

                rand = UnityEngine.Random.value;
                if (rand < crawlerChanceToGrowLeft) //CHOOSE IF GROWING LEFT
                {
                    dir = Direction.left;
                }
                else
                {
                    dir = Direction.right;
                }

                rand = UnityEngine.Random.value; //CHOOSE HOW FAR GROWING
                if (rand < crawlerChanceToGrow1)
                {
                    dis = 1;
                }
                else if (rand < crawlerChanceToGrow1 + crawlerChanceToGrow2)
                {
                    dis = 2;
                }
                else if (rand < crawlerChanceToGrow1 + crawlerChanceToGrow2 + crawlerChanceToGrow3)
                {
                    dis = 3;
                }
                
                bounds = growCrawler(dis, dir, bounds, leftGenerationBoundary, rightGenerationBoundary, crawlerSize);
            }



            //SHRINK
            dir = new Direction();
            dis = 0;
            rand = UnityEngine.Random.value; //CHOOSE IF SHRINKING
            if (rand < crawlerChanceToShrink)
            {

                rand = UnityEngine.Random.value;
                if (rand < crawlerChanceToShrinkLeft) //CHOOSE IF SHRINKING FROM LEFT
                {
                    dir = Direction.left;
                }
                else
                {
                    dir = Direction.right;
                }

                rand = UnityEngine.Random.value; //CHOOSE HOW FAR SHRINKING
                if (rand < crawlerChanceToShrink1)
                {
                    dis = 1;
                }
                else if (rand < crawlerChanceToShrink1 + crawlerChanceToShrink2)
                {
                    dis = 2;
                }
                else if (rand < crawlerChanceToShrink1 + crawlerChanceToShrink2 + crawlerChanceToShrink3)
                {
                    dis = 3;
                }

                bounds = shrinkCrawler(dis, dir, bounds, leftGenerationBoundary, rightGenerationBoundary, crawlerSize);
            }

            crawlerSize = bounds.Item2 - bounds.Item1;
            yPosition--;
        
        }
        return bounds;
    }


    private (int, int) moveCrawler(int shiftAmount, Direction shiftDirection, (int, int) crawlerBounds, int leftGBoundary, int rightGBoundary, int size) {

        if (shiftAmount >= size) { return crawlerBounds; }
        Debug.Log(size + " " + shiftAmount);

        if (shiftDirection == Direction.left) // left
        {
            if (crawlerBounds.Item1 - shiftAmount <= leftGBoundary) { return crawlerBounds; }
            crawlerBounds.Item1 -= shiftAmount;
            crawlerBounds.Item2 -= shiftAmount;
        }
        else // right
        {
            if (crawlerBounds.Item2 + shiftAmount >= rightGBoundary) { return crawlerBounds; }
            crawlerBounds.Item1 += shiftAmount;
            crawlerBounds.Item2 += shiftAmount;
        }

        return crawlerBounds;
    }


    private (int, int) growCrawler(int growAmount, Direction growDirection, (int, int) crawlerBounds, int leftGBoundary, int rightGBoundary, int size) {

        if (growDirection == Direction.left) // left
        {
            if (crawlerBounds.Item1 - growAmount <= leftGBoundary) { return crawlerBounds; }
            crawlerBounds.Item1 -= growAmount;
        }
        else // right
        {
            if (crawlerBounds.Item2 + growAmount >= rightGBoundary) { return crawlerBounds; }
            crawlerBounds.Item2 += growAmount;
        }

        return crawlerBounds;
    }

    private (int, int) shrinkCrawler(int shrinkAmount, Direction shrinkDirection, (int, int) crawlerBounds, int leftGBoundary, int rightGBoundary, int size)
    {
        //Debug.Log(size + " " + shrinkAmount);

        if (size - shrinkAmount < minimumCaveWidth) { return crawlerBounds; }

        if (shrinkDirection == Direction.left) // left
        {
            crawlerBounds.Item1 += shrinkAmount;
        }
        else // right
        {
            crawlerBounds.Item2 -= shrinkAmount;
        }

        return crawlerBounds;
    }

}