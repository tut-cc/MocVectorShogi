using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour {
    public GameObject prefab;

    public void DoInstantiate(Transform root)
    {
        PhotonNetwork.Instantiate(prefab.name, root.position, root.rotation, 0);
    }
}
