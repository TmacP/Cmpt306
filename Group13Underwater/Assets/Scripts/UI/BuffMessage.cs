using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMessage : MonoBehaviour
{
    public GameObject AmmoBuff;
    public GameObject SpeedBuff;
    public GameObject MagnetBuff;
    public GameObject HealthBuff;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ShowMessage(string message)
    {
        Debug.Log(message);

        // Deactivate all buffs
        DeactivateAllBuffs();

        // Activate the desired buff
        if (message == "Ammo")
        {
            AmmoBuff.SetActive(true);
            Invoke("DeactivateAmmoBuff", 3f);
        }
        else if (message == "MoveSpeedBuff")
        {
            SpeedBuff.SetActive(true);
            Invoke("DeactivateSpeedBuff", 3f);
        }
        else if (message == "MagnetBuff")
        {
            MagnetBuff.SetActive(true);
            Invoke("DeactivateMagnetBuff", 3f);
        }
        else if (message == "HealBuff")
        {
            HealthBuff.SetActive(true);
            Invoke("DeactivateHealthBuff", 3f);
        }
    }

    void DeactivateAllBuffs()
    {
        AmmoBuff.SetActive(false);
        SpeedBuff.SetActive(false);
        MagnetBuff.SetActive(false);
        HealthBuff.SetActive(false);
    }

    void DeactivateAmmoBuff()
    {
        AmmoBuff.SetActive(false);
    }

    void DeactivateSpeedBuff()
    {
        SpeedBuff.SetActive(false);
    }

    void DeactivateMagnetBuff()
    {
        MagnetBuff.SetActive(false);
    }

    void DeactivateHealthBuff()
    {
        HealthBuff.SetActive(false);
    }
}
