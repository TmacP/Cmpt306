using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] int maxEnemyCount;
    int enemyCount;

    public GameObject Enemy2;
    [SerializeField] int maxEnemy2Count;
    int enemy2Count;

    public GameObject EnemyBoss;
    [SerializeField] int maxEnemyBossCount;
    int enemyBossCount;

    public GameObject BasicFish;
    [SerializeField] int maxBasicFishCount;
    int basicFishCount;

    public GameObject UncommonFish;
    [SerializeField] int maxUncommonFishCount;
    int uncommonFishCount;

    public GameObject SpecialFish;
    [SerializeField] int maxSpecialFishCount;
    int specialFishCount;

    public GameObject LegendaryFish;
    [SerializeField] int maxLegendaryFishCount;
    int legendaryFishCount;

    public GameObject RareFish;
    [SerializeField] int maxRareFishCount;
    int rareFishCount;

    public GameObject health;
    [SerializeField] int maxHealthCount;
    int healthCount;

    public GameObject Magnet;
    [SerializeField] int maxMagnetCount;
    int magnetCount;

    public GameObject Ammo;
    [SerializeField] int maxAmmoCount;
    int ammoCount;

    public GameObject MoveBuff;
    [SerializeField] int maxMoveBuffCount;
    int moveBuffCount;

    public GameObject ScoreCollectable;
    [SerializeField] int maxScoreCollectableCount;
    int scoreCollectableCount;

    public GameObject Bottles;
    [SerializeField] int maxBottlesCount;
    int bottlesCount;

    public GameObject TreasureChest;
    [SerializeField] int maxTreasureChestCount;
    int treasureChestCount;

    public GameObject YellowCoral;
    [SerializeField] int maxYellowCoralCount;
    int yellowCoralCount;

    public GameObject RedCoral;
    [SerializeField] int maxRedCoralCount;
    int redCoralCount;

    public GameObject BlueCoral;
    [SerializeField] int maxBlueCoralCount;
    int blueCoralCount;

    public GameObject LongCoral;
    [SerializeField] int maxLongCoralCount;
    int longCoralCount;

    public GameObject NemoMine;
    [SerializeField] int maxNemoMineCount;
    int nemoMineCount;

    private bool enableDebugLogs = true; // Control debug logs
    GameObject itemPrefab; // Reference to the item prefab to be spawned
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f; // Adjust this interval as needed
    private float playerYCoordinate;

    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions

    public List<Vector3Int> emptyTilePositions;

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
            SpawnItems(BlueCoral, maxBlueCoralCount, ref blueCoralCount);
            SpawnItems(LongCoral, maxLongCoralCount, ref longCoralCount);
            SpawnItems(NemoMine, maxNemoMineCount, ref nemoMineCount);

            nextSpawnTime = Time.time + spawnInterval;
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
        if (enableDebugLogs) { Debug.Log("count: " + spawn + count); } //DEBUG

        // Pass a reference to the spawner to the spawned object
        newlySpawnedEntity.AddComponent<Despawnable>();
        //if (enableDebugLogs) { Debug.Log("Spawner reference passed to spawned object." + newlySpawnedEntity); } //DEBUG

    }


    public void DecrementCount(GameObject item)
    {
        if (enableDebugLogs) { Debug.Log("DecrementCount() called. " + item); } //DEBUG
        switch (item.name)
        {
            case "EnemyFish 1(Clone)":
                enemyCount--;
                break;
            case "EnemyFish1(Clone)":
                enemy2Count--;
                break;
            case "EnemyFishBoss(Clone)":
                enemyBossCount--;
                break;
            case "BasicFish(Clone)":
                basicFishCount--;
                break;
            case "Fish2(Clone)":
                uncommonFishCount--;
                break;
            case "Fish3(Clone)":
                specialFishCount--;
                break;
            case "LionFish(Clone)":
                legendaryFishCount--;
                break;
            case "Fish7(Clone)":
                rareFishCount--;
                break;
            case "HealthBuffCollectable(Clone)":
                healthCount--;
                break;
            case "MagnetBuffCollectable(Clone)":
                magnetCount--;
                break;
            case "AmmoBuff(Clone)":
                ammoCount--;
                break;
            case "MoveSpeedBuffCollectable(Clone)":
                moveBuffCount--;
                break;
            case "ScoreCollectable(Clone)":
                scoreCollectableCount--;
                break;
            case "MessageBottle(Clone)":
                bottlesCount--;
                break;
            case "TreasureChest(Clone)":
                treasureChestCount--;
                break;
            case "CoralYellow(Clone)":
                yellowCoralCount--;
                break;
            case "CoralRed(Clone)":
                redCoralCount--;
                break;
            case "CoralBlue(Clone)":
                blueCoralCount--;
                break;
            case "LongCoralObstacle(Clone)":
                longCoralCount--;
                break;
            case "NemoMine(Clone)":
                nemoMineCount--;
                break;
            default:
                if (enableDebugLogs) { Debug.Log("DecrementCount(), item name not found."); } //DEBUG
                break;
        }
    }




}
