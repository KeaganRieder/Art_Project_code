using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// holds the settinsg for map generation
/// </summary>
public class ImageHandlerTest 
{
    public int mapWidth;
    public int mapHeight;
    public int scale;
    public int seed;
    public int octaves;
    public float amplitude;
    public float frequency;

    //maps
    public static float[,] noiseMap;

    public void SetDefulats()
    {
        mapWidth = 100;
        mapHeight = 100;
        octaves = 30;
        scale = 50;
        amplitude = 0.30f;//86
        frequency = 2.5f;
    }

    public void DrawImage(List<Renderer> renderer)
    {
        int makeNebula = Random.Range(0, 20);
        amplitude = Random.Range(.1f, .4f);
        frequency = Random.Range(.1f, .3f);
        seed = Random.Range(1, 5000);
        noiseMap = NoiseMap.GenerateNoiseMap(mapWidth, mapHeight, seed, octaves, scale, frequency, amplitude, new Vector2(0,0));
        if (makeNebula <= 12)
        {
            renderer[0].material.mainTexture = GenerateNebula();
        }
        else
        {
            renderer[0].material.mainTexture = GenerateSystem();
        }
        
        //renderer[1].material.mainTexture = GenerateStarMap();
    }

    //maybe
    public void SpawnStar()
    {

    }

    private Texture2D GenerateNebula()
    {
        int makeSpace = Random.Range(0, 5);
        
        float offsetValue = Random.Range(0f, 1f);

        //getting nebula color
        Color nebulaColor = new(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        Color nebulaColor2 = new(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        Color nebulaColor3 = new(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        Color nebulaColor4 = new(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        Color nebulaColor5 = new(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        Texture2D texture = new Texture2D(mapWidth, mapHeight);

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                var height = noiseMap[x, y];
                Color color;


                //space
                //
                if (height <= Random.Range(0.1f, .3f))
                {
                    color = new((nebulaColor2.r * height) -.1f, (nebulaColor2.g * height) -.1f, (nebulaColor2.b * height) -.1f);

                }
                else if (height <= Random.Range(0.3f, .4f))
                {
                    color = new((nebulaColor.r * height) -.1f, (nebulaColor.g * height) -.1f, (nebulaColor.b * height) -.1f);
                   
                }
                //
                else if (height <= Random.Range(0.5f, .6f))
                {
                    color = new(nebulaColor.r * height, nebulaColor.g * height, nebulaColor.b * height);
                }
                //Random.Range(.8f, 1f)height <= Random.Range(.8f, 1f)
                else if(height <= Random.Range(0.6f, .7f))
                {
                    color = new(nebulaColor2.r * height, nebulaColor2.g * height, nebulaColor2.b * height);
                }
                else if(height <= Random.Range(0.7f, .8f))
                {
                    color = new(nebulaColor3.r * height, nebulaColor3.g * height, nebulaColor3.b * height);
                }
                else if (height <= Random.Range(.8f, .9f))
                {
                    color = new(nebulaColor4.r * height, nebulaColor4.g * height, nebulaColor4.b * height);
                }
                else
                {
                    color = new(nebulaColor5.r * height, nebulaColor5.g * height, nebulaColor5.b * height);
                }

                texture.SetPixel(x, y, color);
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        return texture;
    }

    private Texture2D GenerateSystem()
    {
        Texture2D texture = new Texture2D(mapWidth, mapHeight);
        Color color = new(0,0,0);
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    private Texture2D DrawCircle(int cx,int cy, int r,Color color)
    {
        Texture2D planet = new Texture2D(mapWidth, mapHeight);
        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
            for (y = 0; y <= d; y++)
            {
                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                planet.SetPixel(px, py, color);
                planet.SetPixel(nx, py, color);

                planet.SetPixel(px, ny, color);
                planet.SetPixel(nx, ny, color);
            }
        }
        return planet;
    }


    /*
 private Texture2D GenerateStarMap()
 {
     Texture2D texture = new Texture2D(mapWidth, mapHeight);

     
             Color color;
             int spawnStar = Random.Range(0, 50);
             int starColor = Random.Range(0, 10);

             if (spawnStar <=2)
             {
                 if (starColor == 0)
                 {
                     color = new Color(.1f, .3f, .1f);
                 }
                 else if (starColor <= 3)
                 {
                     color = new Color(.3f, .1f, .1f);
                 }
                 else if (starColor <= 6)
                 {
                     color = new Color(.1f, .3f, .3f);
                 }
                 else
                 {
                     color = new Color(.1f, .3f, .3f);
                 }

             }
             else
             {
                 color = new(1, 1, 1, 0);
             } 

             texture.SetPixel(x, y, color);
         }
     }
     texture.filterMode = FilterMode.Point;
     texture.Apply();
     return texture;
 }


  * 
 */




}
