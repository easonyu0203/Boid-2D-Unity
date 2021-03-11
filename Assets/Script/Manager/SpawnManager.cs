using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] GameObject _fish;
    [SerializeField] IntVariable _fishCount;
    [SerializeField] Boundery boundery;

    [SerializeField] ListGameObjectVariable _fishesList;


    //every fish need to be register so the spawn manager can work properly
    void RegisterFish(GameObject newFish)
    {
        //already have, do nothing
        if (_fishesList.Value.Contains(newFish)) return;

        //control by SpawnManager
        ManageBySpawnManager Managee = newFish.AddComponent<ManageBySpawnManager>();
        //On fish Destroy
        Managee.OnDestroyUnityEvent.AddListener(() =>
        {
            if (!_fishesList.Value.Remove(newFish))
            {
                Debug.LogError("[SpawnManager] Can't Remove fish from List<fish>");
            }
        });

        _fishesList.Value.Add(newFish);
    }

    public void Initialize()
    {
        _fishesList.Value.Clear();

        //spawnFish
        RandomInstantiateFish(_fishCount.Value);

    }


    void RandomInstantiateFish(int fishCount)
    {
        for (int i = 0; i < fishCount; i++)
        {
            float xPos = Random.Range(-boundery.XLimit, boundery.XLimit);
            float yPos = Random.Range(-boundery.YLimit, boundery.YLimit);
            float direction = Random.Range((float)0, (float)360);

            GameObject newFish = Instantiate(_fish, new Vector2(xPos, yPos), Quaternion.Euler(Vector3.forward * direction));
            RegisterFish(newFish);

        }
    }

    public void OnFishCountChange()
    {
        int currentCount = _fishesList.Value.Count;
        int diff = currentCount - _fishCount.Value;

        //add fish
        if (diff < 0)
        {
            RandomInstantiateFish(-diff);
        }
        else if (diff > 0) //remove fish
        {
            List<GameObject> removeFish_list = new List<GameObject>();
            for (int i = _fishesList.Value.Count - 1; i + diff > _fishesList.Value.Count - 1; i--)
            {
                removeFish_list.Add(_fishesList.Value[i]);
            }

            foreach(GameObject fish in removeFish_list)
            {
                Destroy(fish);
            }
        }

    }

}
