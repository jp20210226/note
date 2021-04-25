using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatMesh : MonoBehaviour
{
    public Material mat;



    // Use this for initialization
    void Start()
    {

        //DrawCube();
        this.gameObject.GetComponent<MeshRenderer>().material = mat;
        Mesh mesh = this.gameObject.GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        mesh.vertices = new Vector3[] 
        {
            new Vector3(0,0,0), new Vector3(0,0,1), new Vector3(1, 0, 1), new Vector3(1, 0, 0),
            new Vector3(0,1,0), new Vector3(0,1,1), new Vector3(1, 1, 1), new Vector3(1, 1, 0)
        };
        mesh.triangles = new int[] 
        {
         
         0,3,2,
         0,2,1,
         0,1,5,
         0,5,4,
         4,5,7,
         7,5,6,
         3,7,2,
         2,7,6,
         0,4,3,
         3,4,7,
         2,6,1,
         1,6,5
        };
        mesh.uv = new Vector2[] 
        {
        
        
        };
    }

    #region 画正方体
    void DrawCube()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        
        //设置三角形顶点顺序，顺时针设置
        int vertices_Count = 4 * 6;
        Vector3[] tempV1 = new Vector3[vertices_Count];
        tempV1[0] = new Vector3(0, 1, 1);
        tempV1[1] = new Vector3(1, 1, 1);
        tempV1[2] = new Vector3(1, 1, 0);
        tempV1[3] = new Vector3(0, 1, 0);

        tempV1[4] = new Vector3(0, 0, 0);
        tempV1[5] = new Vector3(1, 0, 0);
        tempV1[6] = new Vector3(1, 0, 1);
        tempV1[7] = new Vector3(0, 0, 1);

        tempV1[8] = new Vector3(0, 1, 0);
        tempV1[9] = new Vector3(1, 1, 0);
        tempV1[10] = new Vector3(1, 0, 0);
        tempV1[11] = new Vector3(0, 0, 0);


        tempV1[12] = new Vector3(1, 0, 1);
        tempV1[13] = new Vector3(1, 1, 1);
        tempV1[14] = new Vector3(0, 1, 1);
        tempV1[15] = new Vector3(0, 0, 1);


        tempV1[16] = new Vector3(0, 0, 0);
        tempV1[17] = new Vector3(0, 0, 1);
        tempV1[18] = new Vector3(0, 1, 1);
        tempV1[19] = new Vector3(0, 1, 0);


        tempV1[20] = new Vector3(1, 1, 0);
        tempV1[21] = new Vector3(1, 1, 1);
        tempV1[22] = new Vector3(1, 0, 1);
        tempV1[23] = new Vector3(1, 0, 0);

        int[] triangles = new int[vertices_Count / 2 * 3];
        for (int i = 0, j = 0; i < triangles.Length; i += 6, j += 4)
        {
            triangles[i] = j;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
            triangles[i + 3] = j;
            triangles[i + 4] = j + 2;
            triangles[i + 5] = j + 3;
        }
        mesh.vertices = tempV1;
        mesh.triangles = triangles;
 
    }
    #endregion

}
