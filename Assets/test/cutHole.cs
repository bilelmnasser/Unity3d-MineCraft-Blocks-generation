using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System;

public class cutHole : MonoBehaviour {
/*

    public List<Vector3> vertices;
    public List<int> Triangles;

    	void deleteSquare(int index1, int index2)
        {




            Destroy(this.gameObject.GetComponent<MeshCollider>());
            Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
            int[] oldTriangles = mesh.triangles;
            int[] newTriangles = new int[mesh.triangles.Length-6];

            int i = 0;
            int j = 0;
            while (j < mesh.triangles.Length)
            {
                if(j != index1*3 && j != index2*3)
                {
                    newTriangles[i++] = oldTriangles[j++];
                    newTriangles[i++] = oldTriangles[j++];
                    newTriangles[i++] = oldTriangles[j++];
                }
                else
                {

                    j += 3;
                }
            }
            transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
            this.gameObject.AddComponent<MeshCollider>();

        }

        int findVertex(Vector3 v)
        {
            Vector3[] vertices = transform.GetComponent<MeshFilter>().mesh.vertices;
            for(int i = 0; i < vertices.Length; i++)
            {
                if(vertices[i] == v)
                    return i;
            }
            return -1;
        }

        int findTriangle(Vector3 v1, Vector3 v2, int notTriIndex)
        {
            print( v1 + "  " + v2 );


            int[] triangles = transform.GetComponent<MeshFilter>().mesh.triangles;
            Vector3[] vertices = transform.GetComponent<MeshFilter>().mesh.vertices;
            int i = 0;
            int j = 0;
            int found = 0;
            while (j < triangles.Length)
            {
                if(j/3 != notTriIndex)
                {
                    if(vertices[triangles[j]] == v1 && (vertices[triangles[j+1]] == v2 || vertices[triangles[j+2]] == v2))
                        return j/3;
                    else if(vertices[triangles[j]] == v2 && (vertices[triangles[j+1]] == v1 || vertices[triangles[j+2]] == v1))
                        return j/3;
                    else if(vertices[triangles[j+1]] == v2 && (vertices[triangles[j]] == v1 || vertices[triangles[j+2]] == v1))
                        return j/3;
                    else if(vertices[triangles[j+1]] == v1 && (vertices[triangles[j]] == v2 || vertices[triangles[j+2]] == v2))
                        return j/3;
                }

                j+=3;
            }

            return -1;
        }

        void deleteTri(int index)
        {
            Destroy(this.gameObject.GetComponent<MeshCollider>());
            Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
            int[] oldTriangles = mesh.triangles;
            int[] newTriangles = new int[mesh.triangles.Length-3];

            int i = 0;
            int j = 0;
            while (j < mesh.triangles.Length)
            {
                if(j != index*3)
                {
                    newTriangles[i++] = oldTriangles[j++];
                    newTriangles[i++] = oldTriangles[j++];
                    newTriangles[i++] = oldTriangles[j++];
                }
                else
                {

                    j += 3;
                }
            }
            transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
            this.gameObject.AddComponent<MeshCollider>();
        }

          

    public void deleteObject( Vector3 p0 , Vector3 p1 , Vector3 p2 )
    {
        print( "look for object selected in "+ buildBlockMesh.Instance.MeshObject_3D_List.Count );
        int index = 0;
        foreach( MeshObject3D obj in  buildBlockMesh.Instance.MeshObject_3D_List )
        {


            //print( p0 + " "+ obj .name+" " +list.Contains( p0 ) );
            // print( p1 + " "+ obj.name +" " + list.Contains( p1 ) );
            // print( p2 + " "+ obj.name +" " + list.Contains( p2 ) );
            DestroyImmediate( this.gameObject.GetComponent<MeshCollider>( ) );
       
          
            Vector3 Null= new Vector3( Mathf.Infinity , Mathf.Infinity , Mathf.Infinity ); 
            if ( obj.Vertices.Contains(p0)&& obj.Vertices.Contains( p1 ) && obj.Vertices.Contains( p2 ))
            {
                print( "object selected found !" );

               vertices = transform.GetComponent<MeshFilter>( ).mesh.vertices.ToList<Vector3>();



                List<int> NewTriangles = GetComponent<MeshFilter>( ).mesh.triangles.ToList( );
            List<Vector3>    NewVertices = transform.GetComponent<MeshFilter>( ).mesh.vertices.ToList<Vector3>( );


                
                print(">>>>>>"+ vertices.Count );


                int d = index * obj.Vertices.Count;
                for ( int k = index* obj.Vertices.Count ; k < index * obj.Vertices.Count+ obj.Vertices.Count ; k++ )
                {
                   

                   
                      
                            print( "deleting Vertice  = " + k );


                            while ( NewTriangles .Contains(k))
                            {
                                print( "deleting Triangle with value  = " + k);

                                NewTriangles.Remove( k );

                            }




                    NewVertices.RemoveAt( index * obj.Vertices.Count );










                }

                for(int i=0 ;i< NewTriangles.Count ;i++)// value in Triangles)
                {
                    if( NewTriangles [i] > NewVertices .Count-1)
                    {
                        NewTriangles [ i ] = NewTriangles [ i ] - obj.Vertices.Count;

                    }


                }
                




             



                print( "object selected Deleted ! = " + NewVertices.Count + "/" + NewTriangles.Count );
               
                buildBlockMesh.Instance.GlobalVertices = NewVertices.ToArray( );
                buildBlockMesh.Instance.GlobalTriangles = NewTriangles.ToArray( );
                transform.GetComponent<MeshFilter>( ).mesh.triangles = NewTriangles.ToArray( );
                transform.GetComponent<MeshFilter>( ).mesh.vertices = NewVertices.ToArray( );

               



                transform.GetComponent<MeshFilter>( ).mesh.RecalculateBounds( );
                transform.GetComponent<MeshFilter>( ).mesh.RecalculateNormals( );
                transform.GetComponent<MeshFilter>( ).mesh.RecalculateTangents( );

               // this.gameObject.AddComponent<MeshCollider>( );

                buildBlockMesh.Instance.MeshObject_3D_List.Remove( obj );
                break;
            }

            index++;



        }

        Combine( );

    }


    */
    
    void Update () 
	{
       
      
        if (Input.GetMouseButtonDown(1))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 1000.0f))
            {
                if ( hit.transform .gameObject!= null )
                {

                    DestroyImmediate( hit.transform.gameObject );
                  //  int hitTri = hit.triangleIndex;



                 /*   print( hit.triangleIndex );
                
                    int [ ] triangles = transform.GetComponent<MeshFilter>( ).mesh.triangles;
                    Vector3 [ ] vertices = transform.GetComponent<MeshFilter>( ).mesh.vertices;
                    print( triangles.Length );
                    print( hit.triangleIndex * 3 + 0 );
                    if ( hit.triangleIndex * 3 < triangles.Length-2 )
                    {
                        Vector3 p0 = vertices [ triangles [ hit.triangleIndex * 3 + 0 ] ];//12
                        Vector3 p1 = vertices [ triangles [ hit.triangleIndex * 3 + 1 ] ];//13
                        Vector3 p2 = vertices [ triangles [ hit.triangleIndex * 3 + 2 ] ];//14
                        deleteObject( p0 , p1 , p2 );

                    }*/


                    // print( hit. );

                    //get neighbour
                    /*  

                      for ( int j = 0 ; j < triangles.Length ; j += 3 )
                      {
                          if ( hitTri == j)
                          {
                              Vector3 p0 = vertices [ triangles [ j + 0 ] ];
                              Vector3 p1 = vertices [ triangles [ j + 1 ] ];
                              Vector3 p2 = vertices [ triangles [ j + 2 ] ];
                              deleteObject( p0 , p1 , p2 );

                          }
                          else if ( hitTri == j+1 )
                          {
                              Vector3 p0 = vertices [ triangles [ j + 0 ] ];
                              Vector3 p1 = vertices [ triangles [ j + 1 ] ];
                              Vector3 p2 = vertices [ triangles [ j + 2 ] ];
                              deleteObject( p0 , p1 , p2 );

                          }
                          else if ( hitTri == j+2 )
                          {
                              Vector3 p0 = vertices [ triangles [ j + 0 ] ];
                              Vector3 p1 = vertices [ triangles [ j + 1 ] ];
                              Vector3 p2 = vertices [ triangles [ j + 2 ] ];
                              deleteObject( p0 , p1 , p2 );

                          }

                      }

                      */






                    //  print( triangles [ hitTri * 3 + 0 ] );
                    // print( triangles [ hitTri * 3 + 1 ] );
                    //   print( triangles [ hitTri * 3 + 2 ] );
                    //   print( triangles [ hitTri * 3 + 3 ] );



                    /*
                                        float edge1 = Vector3.Distance( p0 , p1 );
                                        float edge2 = Vector3.Distance( p0 , p2 );
                                        float edge3 = Vector3.Distance( p1 , p2 );

                                        Vector3 shared1;
                                        Vector3 shared2;


                                        if ( edge1 > edge2 && edge1 > edge3 )
                                        {
                                            shared1 = p0;
                                            shared2 = p1;
                                        }
                                        else if ( edge2 > edge1 && edge2 > edge3 )
                                        {
                                            shared1 = p0;
                                            shared2 = p2;
                                        }
                                        else
                                        {
                                            shared1 = p1;
                                            shared2 = p2;
                                        }

                                        int v1 = findVertex( shared1 );
                                        int v2 = findVertex( shared2 );

                        */





                    //   deleteSquare( hitTri , findTriangle( vertices [ v1 ] , vertices [ v2 ] , hitTri ) );









                   // Combine( );
                }
            }
		}

	}
 
    

    /*
    void Combine(  )
    {
      MeshFilter[]   meshFilters = GetComponentsInChildren<MeshFilter>( );
        CombineInstance[] combine = new CombineInstance [ meshFilters.Length ];
        Destroy( this.gameObject.GetComponent<MeshCollider>( ) );

        Vector2 [ ] oldMeshUVs = transform.GetComponent<MeshFilter>( ).mesh.uv;

        int i = 0;

        while ( i < meshFilters.Length )
        {

            combine [ i ].mesh = meshFilters [ i ].sharedMesh;
            
            combine [ i ].transform = meshFilters [ i ].transform.localToWorldMatrix;

            meshFilters [ i ].gameObject.SetActive( false );
            i++;
        }


        transform.GetComponent<MeshFilter>( ).mesh = new Mesh( );
        transform.GetComponent<MeshFilter>( ).mesh.CombineMeshes( combine , true );

        //make new UV array
        Vector2 [ ] newMeshUVs = new Vector2 [ oldMeshUVs.Length + 24 ];

        //copy over all UVs
        for ( i = 0 ; i < oldMeshUVs.Length ; i++ )
            newMeshUVs [ i ] = oldMeshUVs [ i ];

        

        transform.GetComponent<MeshFilter>( ).mesh.RecalculateBounds( );
        transform.GetComponent<MeshFilter>( ).mesh.RecalculateNormals( );
        var o_82_8_636311309992862697 = transform.GetComponent<MeshFilter>( ).mesh;

        this.gameObject.AddComponent<MeshCollider>( );
        transform.gameObject.SetActive( true );

    }

    */


   
  
}
/*
public static class EdgeHelpers
{
    public struct Edge
    {
        public int v1;
        public int v2;
        public int triangleIndex;
        public Edge( int aV1 , int aV2 , int aIndex )
        {
            v1 = aV1;
            v2 = aV2;
            triangleIndex = aIndex;
        }
    }

    public static List<Edge> GetEdges( int [ ] aIndices )
    {
        List<Edge> result = new List<Edge>( );
        for ( int i = 0 ; i < aIndices.Length ; i += 3 )
        {
            int v1 = aIndices [ i ];
            int v2 = aIndices [ i + 1 ];
            int v3 = aIndices [ i + 2 ];
            result.Add( new Edge( v1 , v2 , i ) );
            result.Add( new Edge( v2 , v3 , i ) );
            result.Add( new Edge( v3 , v1 , i ) );
        }
        return result;
    }

    public static List<Edge> FindBoundary( this List<Edge> aEdges )
    {
        List<Edge> result = new List<Edge>( aEdges );
        for ( int i = result.Count - 1 ; i > 0 ; i-- )
        {
            for ( int n = i - 1 ; n >= 0 ; n-- )
            {
                if ( result [ i ].v1 == result [ n ].v2 && result [ i ].v2 == result [ n ].v1 )
                {
                    // shared edge so remove both
                    result.RemoveAt( i );
                    result.RemoveAt( n );
                    i--;
                    break;
                }
            }
        }
        return result;
    }
    public static List<Edge> SortEdges( this List<Edge> aEdges )
    {
        List<Edge> result = new List<Edge>( aEdges );
        for ( int i = 0 ; i < result.Count - 2 ; i++ )
        {
            Edge E = result [ i ];
            for ( int n = i + 1 ; n < result.Count ; n++ )
            {
                Edge a = result [ n ];
                if ( E.v2 == a.v1 )
                {
                    // in this case they are already in order so just continoue with the next one
                    if ( n == i + 1 )
                        break;
                    // if we found a match, swap them with the next one after "i"
                    result [ n ] = result [ i + 1 ];
                    result [ i + 1 ] = a;
                    break;
                }
            }
        }
        return result;
    }
}*/