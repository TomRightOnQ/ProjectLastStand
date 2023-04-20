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

            Vector3 pos = new Vector3(0f, 0.1f, 2f);

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
        }
    }

    public void despawn(Monsters monster) {
        if (monster != null) {
            monster.Deactivate();
            GameManager.Instance.dataManager.RemoveDeactivatedMonster(monster);
        }
    }
}
