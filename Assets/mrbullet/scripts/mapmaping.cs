using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmaping : MonoBehaviour
{
    public Texture2D map;
    //int[,] mapLayer;

    public GameObject obstical;
    public GameObject bloon;
    public GameObject playerIllusion;

    void drawMapLayer()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Color pixelColor = map.GetPixel(i, j);
                if (pixelColor.a == 0)
                {
                    //spawn passable cubes 0
                    //mapLayer[i, j] = 0;
                }
                else if (pixelColor == Color.white)
                {
                    //spawn block can not pass 1
                    Instantiate(obstical, new Vector3(i, j, 0), Quaternion.identity);
                    //mapLayer[i, j] = 1;
                }
                else if (pixelColor == Color.red)
                {
                    Instantiate(bloon, new Vector3(i, j, 0), Quaternion.identity);

                }
                else
                {
                    //set player on the top layer
                    playerIllusion.transform.position = new Vector3(i, j, 0);
                   

                }
            }
        }
    }

    void Start()
    {
        drawMapLayer();
    }

    void Update()
    {
        
    }
}
