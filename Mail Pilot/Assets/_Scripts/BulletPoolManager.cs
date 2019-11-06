using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    public List<GameObject> Bullets;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < 15; i++) {
            Bullets.Add(Instantiate(bullet, new Vector3(0f, 0f, 0f), Quaternion.identity));
            Bullets[i].GetComponent<BulletController>().poolManager = this;
            Bullets[i].transform.parent = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 pos)
    {
        GameObject t = Bullets[0];
        t.transform.position = pos;
        Bullets.Remove(t);
        return t;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject b)
    {
        b.transform.position = new Vector3(0f, 0f, 0f);
        b.SetActive(false);
        if (!Bullets.Contains(b))
        {
            Bullets.Add(b);
        }
    }
}
