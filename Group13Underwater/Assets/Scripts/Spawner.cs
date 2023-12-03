using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] int maxEnemyCount;
    [SerializeField] int enemyCountCap;
    public int enemyCount;

    public GameObject Enemy2;
    [SerializeField] int maxEnemy2Count;
    [SerializeField] int enemy2CountCap;
    public int enemy2Count;

    public GameObject EnemyBoss;
    [SerializeField] int maxEnemyBossCount;
    [SerializeField] int enemyBossCountCap;
    public int enemyBossCount;

    public GameObject BasicFish;
    [SerializeField] int maxBasicFishCount;
    [SerializeField] int basicFishCountCap;
    public int basicFishCount;

    public GameObject UncommonFish;
    [SerializeField] int maxUncommonFishCount;
    [SerializeField] int uncommonFishCountCap;
    public int uncommonFishCount;

    public GameObject SpecialFish;
    [SerializeField] int maxSpecialFishCount;
    [SerializeField] int specialFishCountCap;
    public int specialFishCount;

    public GameObject LegendaryFish;
    [SerializeField] int maxLegendaryFishCount;
    [SerializeField] int legendaryFishCountCap;
    public int legendaryFishCount;

    public GameObject RareFish;
    [SerializeField] int maxRareFishCount;
    [SerializeField] int rareFishCountCap;
    public int rareFishCount;

    public GameObject health;
    [SerializeField] int maxHealthCount;
    [SerializeField] int healthCountCap;
    public int healthCount;

    public GameObject Magnet;
    [SerializeField] int maxMagnetCount;
    [SerializeField] int magnetCountCap;
    public int magnetCount;

    public GameObject Ammo;
    [SerializeField] int maxAmmoCount;
    [SerializeField] int ammoCountCap;
    public int ammoCount;

    public GameObject MoveBuff;
    [SerializeField] int maxMoveBuffCount;
    [SerializeField] int moveBuffCountCap;
    public int moveBuffCount;

    public GameObject ScoreCollectable;
    [SerializeField] int maxScoreCollectableCount;
    [SerializeField] int scoreCollectableCountCap;
    public int scoreCollectableCount;

    public GameObject Bottles;
    [SerializeField] int maxBottlesCount;
    [SerializeField] int bottlesCountCap;
    public int bottlesCount;

    public GameObject TreasureChest;
    [SerializeField] int maxTreasureChestCount;
    [SerializeField] int treasureChestCountCap;
    public int treasureChestCount;

    public GameObject YellowCoral;
    [SerializeField] int maxYellowCoralCount;
    [SerializeField] int yellowCoralCountCap;
    public int yellowCoralCount;

    public GameObject RedCoral;
    [SerializeField] int maxRedCoralCount;
    [SerializeField] int redCoralCountCap;
    public int redCoralCount;
    // public GameObject BlueCoral;
    // [SerializeField] int maxBlueCoralCount;
    // public int blueCoralCount;
    public GameObject LongCoral;
    [SerializeField] int maxLongCoralCount;
    [SerializeField] int longCoralCountCap;
    public int longCoralCount;
    public GameObject NemoMine;
    [SerializeField] int maxNemoMineCount;
    [SerializeField] int nemoMineCountCap;
    public int nemoMineCount;
    private bool enableDebugLogs = true; // Control debug logs
    GameObject itemPrefab; // Reference to the item prefab to be spawned
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f; // Adjust this interval as needed
    private float playerYCoordinate;
    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions
    public List<Vector3Int> emptyTilePositions;
    private float depthGoal = -250f;

    private void Start()
    {
        //if (enableDebugLogs) { Debug.Log("Spawner started."); } //DEBUG
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            //if (enableDebugLogs) { Debug.Log("Time to spawn items."); } //DEBUG
            SpawnItems(Enemy, maxEnemyCount, ref enemyCount);
            SpawnItems(Enemy2, maxEnemy2Count, ref enemy2Count);
            SpawnItems(EnemyBoss, maxEnemyBossCount, ref enemyBossCount);
            SpawnItems(BasicFish, maxBasicFishCount, ref basicFishCount);
            SpawnItems(UncommonFish, maxUncommonFishCount, ref uncommonFishCount);
            SpawnItems(SpecialFish, maxSpecialFishCount, ref specialFishCount);
            SpawnItems(LegendaryFish, maxLegendaryFishCount, ref legendaryFishCount);
            SpawnItems(RareFish, maxRareFishCount, ref rareFishCount);
            SpawnItems(health, maxHealthCount, ref healthCount);
            SpawnItems(Magnet, maxMagnetCount, ref magnetCount);
            SpawnItems(Ammo, maxAmmoCount, ref ammoCount);
            SpawnItems(MoveBuff, maxMoveBuffCount, ref moveBuffCount);
            SpawnItems(ScoreCollectable, maxScoreCollectableCount, ref scoreCollectableCount);
            SpawnItems(Bottles, maxBottlesCount, ref bottlesCount);
            SpawnItems(TreasureChest, maxTreasureChestCount, ref treasureChestCount);
            SpawnItems(YellowCoral, maxYellowCoralCount, ref yellowCoralCount);
            SpawnItems(RedCoral, maxRedCoralCount, ref redCoralCount);
            //SpawnItems(BlueCoral, maxBlueCoralCount, ref blueCoralCount);
            SpawnItems(LongCoral, maxLongCoralCount, ref longCoralCount);
            SpawnItems(NemoMine, maxNemoMineCount, ref nemoMineCount);
            IncreaseMaxCount();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }





    private void IncreaseMaxCount()
    {
        // Get the player's y coordinate from the GameManager
        float playerYCoordinate = GameManager.instance.GetPlayerPosition().y;
        //if (enableDebugLogs) { Debug.Log("INCREASE MAX COUNT players Y coor. " + playerYCoordinate); } //DEBUG

         if (playerYCoordinate <= depthGoal){
            depthGoal = depthGoal + playerYCoordinate;

            //if (enableDebugLogs) { Debug.Log("IncreaseMaxCount() called."); } //DEBUG
            if (maxEnemyCount < enemyCountCap)
            {
                maxEnemyCount++;
                //if (enableDebugLogs) { Debug.Log("maxEnemyCount: " + maxEnemyCount); } //DEBUG
            }
            if (maxEnemy2Count < enemy2CountCap)
            {
                maxEnemy2Count++;
                //if (enableDebugLogs) { Debug.Log("maxEnemy2Count: " + maxEnemy2Count); } //DEBUG
            }
            if (maxEnemyBossCount < enemyBossCountCap)
            {
                maxEnemyBossCount++;
                //if (enableDebugLogs) { Debug.Log("maxEnemyBossCount: " + maxEnemyBossCount); } //DEBUG
            }
            if (maxBasicFishCount < basicFishCountCap)
            {
                maxBasicFishCount++;
                //if (enableDebugLogs) { Debug.Log("maxBasicFishCount: " + maxBasicFishCount); } //DEBUG
            }
            if (maxUncommonFishCount < uncommonFishCountCap)
            {
                maxUncommonFishCount++;
                //if (enableDebugLogs) { Debug.Log("maxUncommonFishCount: " + maxUncommonFishCount); } //DEBUG
            }
            if (maxSpecialFishCount < specialFishCountCap)
            {
                maxSpecialFishCount++;
                //if (enableDebugLogs) { Debug.Log("maxSpecialFishCount: " + maxSpecialFishCount); } //DEBUG
            }
            if (maxLegendaryFishCount < legendaryFishCountCap)
            {
                maxLegendaryFishCount++;
                //if (enableDebugLogs) { Debug.Log("maxLegendaryFishCount: " + maxLegendaryFishCount); } //DEBUG
            }
            if (maxRareFishCount < rareFishCountCap)
            {
                maxRareFishCount++;
                //if (enableDebugLogs) { Debug.Log("maxRareFishCount: " + maxRareFishCount); } //DEBUG
            }
            if (maxHealthCount < healthCountCap)
            {
                maxHealthCount++;
                //if (enableDebugLogs) { Debug.Log("maxHealthCount: " + maxHealthCount); } //DEBUG
            }
            if (maxMagnetCount < magnetCountCap)
            {
                maxMagnetCount++;
                //if (enableDebugLogs) { Debug.Log("maxMagnetCount: " + maxMagnetCount); } //DEBUG
            }
            if (maxAmmoCount < ammoCountCap)
            {
                maxAmmoCount++;
                //if (enableDebugLogs) { Debug.Log("maxAmmoCount: " + maxAmmoCount); } //DEBUG
            }
            if (maxMoveBuffCount < moveBuffCountCap)
            {
                maxMoveBuffCount++;
                //if (enableDebugLogs) { Debug.Log("maxMoveBuffCount: " + maxMoveBuffCount); } //DEBUG
            }
            if (maxScoreCollectableCount < scoreCollectableCountCap)
            {
                maxScoreCollectableCount++;
                //if (enableDebugLogs) { Debug.Log("maxScoreCollectableCount: " + maxScoreCollectableCount); } //DEBUG
            }
            if (maxBottlesCount < bottlesCountCap)
            {
                maxBottlesCount++;
                //if (enableDebugLogs) { Debug.Log("maxBottlesCount: " + maxBottlesCount); } //DEBUG
            }
            if (maxTreasureChestCount < treasureChestCountCap)
            {
                maxTreasureChestCount++;
                //if (enableDebugLogs) { Debug.Log("maxTreasureChestCount: " + maxTreasureChestCount); } //DEBUG
            }
            if (maxYellowCoralCount < yellowCoralCountCap)
            {
                maxYellowCoralCount++;
                //if (enableDebugLogs) { Debug.Log("maxYellowCoralCount: " + maxYellowCoralCount); } //DEBUG
            }
            if (maxRedCoralCount < redCoralCountCap)
            {
                maxRedCoralCount++;
                //if (enableDebugLogs) { Debug.Log("maxRedCoralCount: " + maxRedCoralCount); } //DEBUG
            }
            // if (maxBlueCoralCount < blueCoralCountCap)
            // {
            //     maxBlueCoralCount++;
            //     if (enableDebugLogs) { Debug.Log("maxBlueCoralCount: " + maxBlueCoralCount); } //DEBUG
            // }
            if (maxLongCoralCount < longCoralCountCap)
            {
                maxLongCoralCount++;
                //if (enableDebugLogs) { Debug.Log("maxLongCoralCount: " + maxLongCoralCount); } //DEBUG
            }
            if (maxNemoMineCount < nemoMineCountCap)
            {
                maxNemoMineCount++;
                //if (enableDebugLogs) { Debug.Log("maxNemoMineCount: " + maxNemoMineCount); } //DEBUG
            }
        }
    }

    private void SpawnItems(GameObject spawn, int maxCount, ref int count)
    {
        itemPrefab = spawn;
        //if (enableDebugLogs) { Debug.Log("Spawning items."); } //DEBUG
        //if (enableDebugLogs) { Debug.Log("emptyTilePositions " + string.Join(", ", tileGeneration.emptyTilePositions)); }//DEBUG

        if (tileGeneration.emptyTilePositions.Count == 0)
        {
            //if (enableDebugLogs) { Debug.Log("No empty tile positions available."); } //DEBUG
            return;
        }

        if (itemPrefab == null)
        {
            //if (enableDebugLogs) { Debug.Log("Item prefab is not assigned."); } //DEBUG
            return;
        }

        // Get the player's y coordinate from the GameManager
        float playerYCoordinate = GameManager.instance.GetPlayerPosition().y;
        
        //if (enableDebugLogs) { Debug.Log("players Y coor. " + playerYCoordinate); } //DEBUG

        int randomIndex = Random.Range(0, tileGeneration.emptyTilePositions.Count);
        Vector3Int position = tileGeneration.emptyTilePositions[randomIndex];

        // Instantiate the chosen item prefab at the random position
        Vector3 spawnPosition = new Vector3(position.x, position.y, 0);

        //if (enableDebugLogs) { Debug.Log("spawn position y coor. " + spawnPosition.y); } //DEBUG

         // Check if the item is in veiw of the player player
        // if (enableDebugLogs) { Debug.Log("playerYCoordinate + spawnPosition.y = :" + (playerYCoordinate + spawnPosition.y)); } //DEBUG
         if (playerYCoordinate <= (spawnPosition.y + 80))
         {
             //if (enableDebugLogs) { Debug.Log("Item is  in view of the player."); } //DEBUG
             return;
        }

        // check if the item is too far away from the player
        //if (enableDebugLogs) { Debug.Log("playerYCoordinate - spawnPosition.y = :" + (playerYCoordinate - spawnPosition.y)); } //DEBUG
        if ((playerYCoordinate - spawnPosition.y) >=  160)
        {
            //if (enableDebugLogs) { Debug.Log("Item is too far from player."); } //DEBUG
            return;
        }
        // check if the item is above player
        if (playerYCoordinate <= spawnPosition.y)
        {
            //if (enableDebugLogs) { Debug.Log("Item is above player."); } //DEBUG
            tileGeneration.emptyTilePositions.RemoveAt(randomIndex);
            return;
        }

        // check it count is maxed out
        if (count >= maxCount)
        {
            //if (enableDebugLogs) { Debug.Log("Item count is maxed out."); } //DEBUG
            return;
        }

        // all the checks have passed so spawn the item
        GameObject newlySpawnedEntity = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        // add += count
        count++;
        //if (enableDebugLogs) { Debug.Log("count: " + spawn + count); } //DEBUG

        // Pass a reference to the spawner to the spawned object
        newlySpawnedEntity.AddComponent<Despawnable>();
        //if (enableDebugLogs) { Debug.Log("Spawner reference passed to spawned object." + newlySpawnedEntity); } //DEBUG

    }


    public void DecrementCount(GameObject item)
    {
        //if (enableDebugLogs) { Debug.Log("DecrementCount() called. " + item.name); } //DEBUG
        switch (item.name)
        {
            case "EnemyFish 1(Clone)":
                enemyCount--;
                //if (enableDebugLogs) { Debug.Log("enemyCount: " + enemyCount); } //DEBUG
                break;
            case "EnemyFish1(Clone)":
                enemy2Count--;
                //if (enableDebugLogs) { Debug.Log("enemy2Count: " + enemy2Count); } //DEBUG
                break;
            case "EnemyFishBoss(Clone)":
                enemyBossCount--;
                //if (enableDebugLogs) { Debug.Log("enemyBossCount: " + enemyBossCount); } //DEBUG
                break;
            case "BasicFish(Clone)":
                basicFishCount--;
                //if (enableDebugLogs) { Debug.Log("basicFishCount: " + basicFishCount); } //DEBUG
                break;
            case "Fish2(Clone)":
                uncommonFishCount--;
                //if (enableDebugLogs) { Debug.Log("uncommonFishCount: " + uncommonFishCount); } //DEBUG
                break;
            case "Fish3(Clone)":
                specialFishCount--;
                //if (enableDebugLogs) { Debug.Log("specialFishCount: " + specialFishCount); } //DEBUG
                break;
            case "LionFish(Clone)":
                legendaryFishCount--;
                //if (enableDebugLogs) { Debug.Log("legendaryFishCount: " + legendaryFishCount); } //DEBUG
                break;
            case "Fish7(Clone)":
                rareFishCount--;
                //if (enableDebugLogs) { Debug.Log("rareFishCount: " + rareFishCount); } //DEBUG
                break;
            case "HealBuffCollectable(Clone)":
                healthCount--;
                //if (enableDebugLogs) { Debug.Log("healthCount: " + healthCount); } //DEBUG
                break;
            case "MagnetBuffCollectable(Clone)":
                magnetCount--;
                //if (enableDebugLogs) { Debug.Log("magnetCount: " + magnetCount); } //DEBUG
                break;
            case "AmmoBuff(Clone)":
                ammoCount--;
                //if (enableDebugLogs) { Debug.Log("ammoCount: " + ammoCount); } //DEBUG
                break;
            case "MoveSpeedBuffCollectable(Clone)":
                moveBuffCount--;
                //if (enableDebugLogs) { Debug.Log("moveBuffCount: " + moveBuffCount); } //DEBUG
                break;
            case "ScoreCollectable(Clone)":
                scoreCollectableCount--;
                if (enableDebugLogs) { Debug.Log("scoreCollectableCount: " + scoreCollectableCount); } //DEBUG
                break;
            case "MessageBottle(Clone)":
                bottlesCount--;
                //if (enableDebugLogs) { Debug.Log("bottlesCount: " + bottlesCount); } //DEBUG
                break;
            case "TreasureChest(Clone)":
                treasureChestCount--;
                //if (enableDebugLogs) { Debug.Log("treasureChestCount: " + treasureChestCount); } //DEBUG
                break;
            case "CoralYellow(Clone)":
                yellowCoralCount--;
                //if (enableDebugLogs) { Debug.Log("yellowCoralCount: " + yellowCoralCount); } //DEBUG
                break;
            case "CoralRed(Clone)":
                redCoralCount--;
                //if (enableDebugLogs) { Debug.Log("redCoralCount: " + redCoralCount); } //DEBUG
                break;
            // case "CoralBlue(Clone)":
            //     blueCoralCount--;
            //     if (enableDebugLogs) { Debug.Log("blueCoralCount: " + blueCoralCount); } //DEBUG
            //     break;
            case "LongCoralObstacle(Clone)":
                longCoralCount--;
                //if (enableDebugLogs) { Debug.Log("longCoralCount: " + longCoralCount); } //DEBUG
                break;
            case "NemoMine(Clone)":
                nemoMineCount--;
                //if (enableDebugLogs) { Debug.Log("nemoMineCount: " + nemoMineCount); } //DEBUG
                break;
            default:
                //if (enableDebugLogs) { Debug.Log("DecrementCount(), item name not found." + item.name); } //DEBUG
                break;
        }
    }




}
