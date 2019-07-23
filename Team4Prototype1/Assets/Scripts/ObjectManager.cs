using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string itemName;
    private GameObject obj;

    public Item (string n)
    {
        itemName = n;
    }

    public void SetName(string n)
    {
        itemName = n;
    }

    public void SetObject(GameObject o)
    {
        obj = o;
    }

    public GameObject GetObject()
    {
        return obj;
    }

    public string GetName()
    {
        return itemName;
    }
}

public class ObjectManager : MonoBehaviour
{
    public int numberOfBlocks;
    public float xUpperLimit, xLowerLimit, yUpperLimit, yLowerLimit;
    public GameObject blockPrefab;

    private List<Item> items = new List<Item>();
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfBlocks; i++)
        {
            float x, y;
            x = Random.Range(xLowerLimit, xUpperLimit);
            y = Random.Range(yLowerLimit, yUpperLimit);
            Item item = new Item(counter.ToString());
            item.SetObject(Instantiate(blockPrefab, new Vector3(x, y, 15), Quaternion.identity));
            items.Add(item);
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item FindItemWithGivenObject (GameObject obj)
    {
        if (obj == null)
            return null;
        foreach(Item it in items)
        {
            if (it.GetObject() == obj)
            {
                return it;
            }
        }
        return null;
    }
}
