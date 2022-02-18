using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NodeData
{
    public int uid;
    public int id;// mod id
    public string rid = "";
    public int type;
    public string p;
    public string r;
    public string s;
    public List<NodeData> prims = new List<NodeData>();
}

public class MapData
{

    public List<NodeData> pref = new List<NodeData>();
}
