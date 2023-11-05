using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;


/// <summary>
/// Responsible for dirt tile generation
/// -Steven
/// </summary>
public class TileGeneration : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tile[] groundTiles;
    
    //[SerializeField] Tilemap backgroundTileMap;
    //[SerializeField] Tile[] backgroundTiles;

    //[SerializeField] int backgroundWidth = 4;
    //[SerializeField] int backgroundHeight = 4;
    

    [SerializeField] int dirtWidth = 60; //NEEDS TO BE EVEN
    [SerializeField] int crawlerWidth = 40;
    [SerializeField] int generationHeight = 100;

    [SerializeField] (int, int) crawlerBounds = (-1, 1); //THIS WILL SET THE CAVE ENTRANCE POSITION

    [SerializeField] int minimumCaveWidth = 2;

    public List<Vector3Int> emptyTilePositions = new List<Vector3Int>(); // List of all empty tile positions for spawing enemies, items, etc.
    private bool enableDebugLogs = false; // Flag to enable or disable debug logs.



    private enum Direction {left, right}

    
    //-------------------------------------------
    [SerializeField] float crawlerChanceToGrow = 0.3f;

    [SerializeField] float crawlerChanceToGrowLeft = 0.5f;

    [SerializeField] float crawlerChanceToGrow1 = 0.8f;
    [SerializeField] float crawlerChanceToGrow2 = 0.15f;
    [SerializeField] float crawlerChanceToGrow3 = 0.05f;
    //-------------------------------------------
    [SerializeField] float crawlerChanceToShrink = 0.3f;

    [SerializeField] float crawlerChanceToShrinkLeft = 0.5f;

    [SerializeField] float crawlerChanceToShrink1 = 0.8f;
    [SerializeField] float crawlerChanceToShrink2 = 0.15f;
    [SerializeField] float crawlerChanceToShrink3 = 0.05f;
    //-------------------------------------------

    private int generationEndYPos = 0; //Y position of the bottom of the current generated area
    //private int backgroundGenerationEndYPos = 0;


    private void Awake()
    {
        groundTiles = Resources.LoadAll<Tile>("Steven/Tiles/Ground");
        //backgroundTiles = Resources.LoadAll<Tile>("Steven/Tiles/Background");
    }

    void FixedUpdate() {
        Vector3 playerPosition = GameManager.instance.GetPlayerPosition();
        if (playerPosition.y < generationEndYPos + 20) {
            //fillRectangle(new Vector3Int(-backgroundWidth / 2, backgroundGenerationEndYPos, 0), backgroundWidth, backgroundHeight, backgroundTileMap, backgroundTiles[0]);
            fillRectangle(new Vector3Int(-dirtWidth / 2, generationEndYPos, 0), dirtWidth, generationHeight, groundTilemap, groundTiles[0]);
            crawlerBounds = createTunnel(crawlerBounds, new Vector3Int(-crawlerWidth / 2, generationEndYPos, 0), crawlerWidth, generationHeight);
            generationEndYPos -= generationHeight;
            //backgroundGenerationEndYPos -= backgroundHeight;
        }
    }




    /// <summary>
    /// Fills a rectangle with the inputted tile. The rectangle generates with the inputted position at the top left corner.
    /// </summary>
    /// <param name="topLeftCornerPosition">Disired position of the rectangles top left corner.</param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void fillRectangle(Vector3Int topLeftCornerPosition, int width, int height, Tilemap tileMap, Tile fillTile)
    {
        Vector3Int position = topLeftCornerPosition;
        for (int x = topLeftCornerPosition.x; x < topLeftCornerPosition.x + width; x++)
        {
            for (int y = topLeftCornerPosition.y; y > topLeftCornerPosition.y - height; y--)
            {
                tileMap.SetTile(new Vector3Int(x, y, 0), fillTile);
            }
        }
    }


    private (int, int) createTunnel((int, int) bounds, Vector3Int topLeftCornerPosition, int width, int height)
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

                groundTilemap.SetTile(new Vector3Int(i, yPosition), null);
                emptyTilePositions.Add(new Vector3Int(i, yPosition, 0)); // Add empty tile position to list
                if (enableDebugLogs){Debug.Log("emptyTilePositions.Add: " + string.Join(", ", emptyTilePositions));}//DEBUG

            }


            Direction dir;
            int dis;
            float rand;

            
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
            crawlerSize = bounds.Item2 - bounds.Item1;


            yPosition--;
        
        }
        return bounds;
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