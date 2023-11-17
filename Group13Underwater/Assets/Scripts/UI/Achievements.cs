using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    private List<string> achievement_list = new List<string>();
    private int kills = 0;
    [SerializeField] private int kills_to_next = 5;
    private int kills_next_achievement = 0;


    private int scolls_collected = 0;
    [SerializeField] private int scrolls_to_next = 1;
    private int scrolls_next_achievement = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kills == kills_next_achievement) {

            KillsNextAchievement();
            kills_next_achievement += 1; 

        }

        if (scolls_collected == scrolls_to_next) {

            ScrollsNextAchievement();
            scrolls_next_achievement += 1;
        }
    }

    void KillsNextAchievement() {
    
        achievement_list.Add(string.Format("Defeaded {0} Enemies", kills_to_next));
        // place holder for canvas element code
        kills_to_next *= 2;
    
    }

        void ScrollsNextAchievement() {

        achievement_list.Add(string.Format("You collected {0}", scrolls_to_next));
        // place holder for canvas element code
        scrolls_to_next += 1;

    }
    
}
