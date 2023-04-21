using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Managing the spawning and despawning of monster entities
public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    private int difficulty = 1;
    private float spawning = 1f;


    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawning);

            Vector3 pos = new Vector3(Random.Range(-2, 2), 0.1f, (Random.Range(-2, 2)));

            spawn(pos);
        }
    }

    // Spawning
    public void spawn(Vector3 pos)
    {
        // Get monster from pool
        Monsters monster = GameManager.Instance.dataManager.TakeMonsterPool();

        if (monster != null)
        {
            // Config the monster
            monster.transform.position = pos;
            monster.CurrentHitPoints = 20;
            monster.UpdateHP();
        }
    }

    // Check if a mosnter should get despawn
    public void despawnCheck(Monsters monster) {
        if (monster != null && monster.CurrentHitPoints <= 0) {
            monster.Deactivate();
            GameManager.Instance.dataManager.RemoveDeactivatedMonster(monster);
        }
    }
}
