using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjectManager/SpawnManager")]
public class SpawnManager : ScriptableObject
{
    [SerializeField] GameObject _fish;
    [SerializeField] IntVariable _fishCount;
    [SerializeField] Boundery boundery;

    [SerializeField] ListGameObjectVariable _fishesList;


    //the limit of boundery
    private float xlimit;
    private float ylimit;

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

        //get limits
        ylimit = boundery.YLimit;
        xlimit = boundery.XLimit;

        //add the inspecting fish to the list
        GameObject inspectFish = GameObject.Find("InspectFish");
        RegisterFish(inspectFish);

        //spawnFish
        RandomInstantiateFish(_fishCount.Value);

    }


    void RandomInstantiateFish(int fishCount)
    {
        for (int i = 0; i < fishCount; i++)
        {
            float xPos = Random.Range(-xlimit, xlimit);
            float yPos = Random.Range(-ylimit, ylimit);
            float direction = Random.Range((float)0, (float)360);

            GameObject newFish = Instantiate(_fish, new Vector2(xPos, yPos), Quaternion.Euler(Vector3.forward * direction));
            RegisterFish(newFish);

        }
    }

}
