using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
[Serializable]
public class MeshObject3D
{
    [SerializeField]
   public List<Vector3> Vertices;
    [SerializeField]
    public List<int> Triangles;
    [SerializeField]
    public List<Vector2> UVs;
    [SerializeField]
    public List<Vector3> Normals;
}





[Serializable]
public class buildBlockMesh : MonoBehaviour {

	//public GameObject[] blocks;
    public  GameObject newBlock;//
  //  public MeshFilter [ ] meshFilters;
    public CombineInstance [ ] combine;

   public Vector3[] GlobalVertices;
    public int[] GlobalTriangles;
    public Vector2 [ ]GlobalUVs;
    public Vector3 [ ] GlobalNormals;


    public List<MeshObject3D> MeshObject_3D_List = new List<MeshObject3D>();
    
    public static buildBlockMesh Instance { get; internal set; }

    void Start()
    {
        Instance = this;
           //newBlock = blocks[0];
    }

    public void SetBlock(int num)
    {
       // newBlock = blocks[num];
    }
/*
    void Combine(GameObject block)
    {
        print( block.GetComponent<MeshFilter>( ).mesh.triangles.Length );
        List<Vector3> verticesInWorldSpace=new List<Vector3>();
        // SubMeshes.Add( block.GetComponent<MeshFilter>().mesh );
        foreach ( Vector3 vertice in block.GetComponent<MeshFilter>( ).mesh.vertices )
        {

            verticesInWorldSpace.Add( vertice + block.transform.position );

        }
        MeshObject3D obj = new MeshObject3D( );
        obj.Triangles = new List<int>( );
        obj.Vertices = new List<Vector3>( );
        obj.UVs = new List<Vector2>( );
        obj.Normals = new List<Vector3>( );

        obj.Triangles.AddRange( block.GetComponent<MeshFilter>( ).mesh.triangles );
        obj.UVs.AddRange( block.GetComponent<MeshFilter>( ).mesh.uv );

        obj.Normals.AddRange( block.GetComponent<MeshFilter>( ).mesh.normals);


        obj.Vertices.AddRange( verticesInWorldSpace );

        MeshObject_3D_List.Add( obj );

             meshFilters = GetComponentsInChildren<MeshFilter>();
       combine = new CombineInstance[meshFilters.Length];
        Destroy(this.gameObject.GetComponent<MeshCollider>());

        Vector2[] oldMeshUVs = transform.GetComponent<MeshFilter>().mesh.uv;

        int i = 0;

        while (i < meshFilters.Length) {
           
            combine[i].mesh = meshFilters[i].sharedMesh;
          
            combine [i].transform = meshFilters[i].transform.localToWorldMatrix;
          
             meshFilters [i].gameObject.SetActive(false);
            i++;
        }


        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine,true);

     

        //make new UV array
        Vector2 [ ] newMeshUVs = new Vector2[oldMeshUVs.Length+24];
         
        //copy over all UVs
        for(i = 0; i < oldMeshUVs.Length; i++)
            newMeshUVs[i] = oldMeshUVs[i];

        //add new UVs based on individual block settings
      /*  SetUVs suv = block.GetComponent<SetUVs>();
        float tilePerc = 1/suv.pixelSize;
        float umin = tilePerc * suv.tileX;
        float umax = tilePerc * (suv.tileX+1);
        float vmin = tilePerc * suv.tileY;
        float vmax = tilePerc * (suv.tileY+1);
        
        newMeshUVs[newMeshUVs.Length-24] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-23] = new Vector2(umax, vmin); 
        newMeshUVs[newMeshUVs.Length-22] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-21] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-20] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-19] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-18] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-17] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-16] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-15] = new Vector2(umax, vmin); 
        newMeshUVs[newMeshUVs.Length-14] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-13] = new Vector2(umax, vmin); 
        newMeshUVs[newMeshUVs.Length-12] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-11] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-10] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-9] = new Vector2(umax, vmin); 
        newMeshUVs[newMeshUVs.Length-8] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-7] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-6] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-5] = new Vector2(umax, vmin); 
        newMeshUVs[newMeshUVs.Length-4] = new Vector2(umin, vmin); 
        newMeshUVs[newMeshUVs.Length-3] = new Vector2(umin, vmax); 
        newMeshUVs[newMeshUVs.Length-2] = new Vector2(umax, vmax); 
        newMeshUVs[newMeshUVs.Length-1] = new Vector2(umax, vmin);

        transform.GetComponent<MeshFilter>().mesh.uv = newMeshUVs;

        transform.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        transform.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        var o_82_8_636311309992862697 = transform.GetComponent<MeshFilter>().mesh;

        this.gameObject.AddComponent<MeshCollider>();
        transform.gameObject.SetActive(true);

        Destroy(block);



        GlobalVertices = GetComponent<MeshFilter>( ).mesh.vertices;
        GlobalTriangles = GetComponent<MeshFilter>( ).mesh.triangles;
        GlobalNormals= GetComponent<MeshFilter>( ).mesh.normals;
        GlobalUVs = GetComponent<MeshFilter>( ).mesh.uv;


    }

    */
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 1000.0f))
            {

                 //generate new block
                 Vector3 blockPos = hit.point + hit.normal/2.0f;

                blockPos.x = (float) Math.Round(blockPos.x,MidpointRounding.AwayFromZero);
                blockPos.y = (float) Math.Round(blockPos.y,MidpointRounding.AwayFromZero);
                blockPos.z = (float) Math.Round(blockPos.z,MidpointRounding.AwayFromZero);

                newBlock.SetActive( true );
                GameObject block = (GameObject) Instantiate( hit .transform.gameObject, blockPos, Quaternion.identity);
                newBlock.SetActive( false );
                block.name = hit.transform.name;


                block.transform.parent = transform;
              //  Combine(block);

			}
		}
       

        }
}

