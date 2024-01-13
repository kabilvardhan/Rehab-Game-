using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem.EnhancedTouch;

using System.Collections.Generic;
using System.Linq;

//Size of one pixel in mm = Diagonal size of the screen in mm / Square root of (Horizontal pixel count^2 + Vertical pixel count^2)

//For example, if you have a display with a diagonal size of 24 inches and a resolution of 1920x1080 pixels:

//Size of one pixel in mm = 24 inches / sqrt(1920^2 + 1080^2)

//irframe length ID length = 93.5 , ID breadth = 52.8

//ir frame to dispaly scaling inlenght 15.6/36.11 inch = 0.423 , 7.6 / 20.787 = 0.3656

public class RawData : MonoBehaviour
{
    public Text touch_data1, touch_data2, touch_data3,distance_AB,distance_CA, distance_BC;

    public GameObject pointA, pointB, pointC;

    public static float inch = 2.54f;

    public static float origin_pt, first_pt, second_pt, third_pt, Theta_, initial_x, initial_y, angle, x_coord, y_coord, x_coord_, y_coord_, x_coord_1, y_coord_1, x_coord_2, y_coord_2;

    public static double pixelsize;
    public List<Vector2> coordinates = new List<Vector2>();
    public List<Vector2> dist = new List<Vector2>();
    public List<float> dist_values = new List<float>();

    //public float[] dist_values;

    //List<string> list = new List<string>();
    //public static List<string> items = new List<string>();
    //public static List<string[]> items = new List<string>();
    void Update()
    {

        if (Input.touchCount > 2)
        {
            //Touch touch1 = Input.GetTouch(0);
            //Touch touch2 = Input.GetTouch(1);
            //Touch touch3 = Input.GetTouch(2);
            //Debug.Log("Input.GetTouch(0).radius");

            coordinates.Clear();
            for (int i = 0; i < Input.touchCount; i++)
            {
                coordinates.Add(Input.GetTouch(i).position);

                    
            }
            dist.Clear();

            

            for (int i = 0; i < Input.touchCount; i++)
            {
                //dist_values.Clear();
                if (i < Input.touchCount - 1)
                {
                    
                    dist.Add(coordinates[i] - coordinates[i + 1]);
                    //Debug.Log(dist[i].magnitude + "  " + dist[i]);

                    //dist_values.Add(dist[i].magnitude/5);
                    dist_values.Add(Mathf.Sqrt(Mathf.Pow((dist[i][0]), 2) + Mathf.Pow((dist[i][1]), 2)) / inch);
                }


                else
                {
                    dist.Add(coordinates[i] - coordinates[0]);
                    //Debug.Log(dist[i].magnitude + "  " + dist[i]);
                    //dist_values.Add(dist[i].magnitude/5); //Mathf.Sqrt(Mathf.Pow((dist[0][0]), 2) + Mathf.Pow((dist[0][1]), 2)) / inch);
                    dist_values.Add(Mathf.Sqrt(Mathf.Pow((dist[i][0]), 2) + Mathf.Pow((dist[i][1]), 2)) / inch);
                }
                


            }
            //Debug.Log(dist_values[0] + "," + dist_values[1]);

            //dist_values.Clear();
            int vertexAB;
            int vertexAC;

            vertexAB = dist_values.IndexOf(dist_values.OrderBy(item => Mathf.Abs(34 - item)).First());
            vertexAC = dist_values.IndexOf(dist_values.OrderBy(item => Mathf.Abs(63 - item)).First());
            dist_values.Clear();
            // find a
            //Debug.Log(vertexAB + "," + vertexAC);

            //second_pt = (touch1.position.x - touch.position.x); 
            //third_pt = (touch1.position.y - touch.position.y);

            //Theta_ = Mathf.Atan2(third_pt, second_pt) * Mathf.Rad2Deg;
            if (vertexAB == 0)
            {
                if(vertexAC == 1)
                {
                    pointA.transform.position = (coordinates[0]);
                    pointB.transform.position = (coordinates[1]);
                    pointC.transform.position = (coordinates[2]);
                    second_pt = (coordinates[1][0] - coordinates[0][0]);
                    third_pt  = (coordinates[1][1] - coordinates[0][1]);
                    Theta_ = (Mathf.Atan2(second_pt,third_pt)) * Mathf.Rad2Deg;
                    
                }


            }

            if (vertexAB == 0)
            {
                if (vertexAC == 2)
                {
                    pointA.transform.position = (coordinates[1]);
                    pointB.transform.position = (coordinates[0]);
                    pointC.transform.position = (coordinates[2]);
                    second_pt = (coordinates[0][0] - coordinates[1][0]);
                    third_pt = (coordinates[0][1] - coordinates[1][1]);
                    Theta_ = (Mathf.Atan2(second_pt, third_pt)) * Mathf.Rad2Deg;
                }
                

            }
            if (vertexAB == 1)
            {
                if (vertexAC == 2)
                {
                    pointA.transform.position = (coordinates[1]);
                    pointB.transform.position = (coordinates[2]);
                    pointC.transform.position = (coordinates[0]);
                    second_pt = (coordinates[2][0] - coordinates[1][0]);
                    third_pt = (coordinates[2][1] - coordinates[1][1]);
                    Theta_ = (Mathf.Atan2(second_pt, third_pt)) * Mathf.Rad2Deg;
                }
                
            }
            if (vertexAB == 1)
            { 

                if (vertexAC == 0)
                {
                    pointA.transform.position = (coordinates[2]);
                    pointB.transform.position = (coordinates[1]);
                    pointC.transform.position = (coordinates[0]);
                    second_pt = (coordinates[1][0] - coordinates[2][0]);
                    third_pt = (coordinates[1][1] - coordinates[2][1]);
                    Theta_ = (Mathf.Atan2(second_pt, third_pt)) * Mathf.Rad2Deg;

                }
                

            }
            if (vertexAB == 2)
            {
                if (vertexAC == 0)
                {
                    pointA.transform.position = (coordinates[2]);
                    pointB.transform.position = (coordinates[0]);
                    pointC.transform.position = (coordinates[1]);
                    second_pt = (coordinates[0][0] - coordinates[2][0]);
                    third_pt = (coordinates[0][1] - coordinates[2][1]);
                    Theta_ = (Mathf.Atan2(second_pt, third_pt)) * Mathf.Rad2Deg;
                }
                
            }
            if (vertexAB == 2)
            {
                if (vertexAC == 1)
                {
                    pointA.transform.position = (coordinates[0]);
                    pointB.transform.position = (coordinates[2]);
                    pointC.transform.position = (coordinates[1]);
                    second_pt = (coordinates[2][0] - coordinates[0][0]);
                    third_pt = (coordinates[2][1] - coordinates[0][1]);
                    Theta_ = (Mathf.Atan2(second_pt, third_pt)) * Mathf.Rad2Deg;

                }
                
            }

            Debug.Log(Theta_.ToString());
            //void FindAngle(List<Vector2> vectorList)
            //{
            //    Debug.Log(vectorList[0]);
            //}

            //Debug.Log(coordinates[0] - coordinates[1]);

            //dist.Clear();
            //dist.Add(coordinates[1] - coordinates[0]);
            //dist.Add(coordinates[2] - coordinates[0]);

            //dist_values.Clear();

            //dist_values.Add(Mathf.Sqrt(Mathf.Pow((dist[0][0]), 2) + Mathf.Pow((dist[0][1]), 2)) / inch);
            //dist_values.Add(Mathf.Sqrt(Mathf.Pow((dist[1][0]), 2) + Mathf.Pow((dist[1][1]), 2)) / inch);

            //Debug.Log(dist[0][0].ToString() + dist[0][1]);
            //Debug.Log(dist_values[0].ToString() + "   ,   " + dist_values[1].ToString());



            touch_data1.text = coordinates[0].ToString();
            touch_data2.text = coordinates[1].ToString();
            touch_data3.text = coordinates[2].ToString();



            //Debug.Log(coordinates[0].ToString() + coordinates[1].ToString() + coordinates[2].ToString());


          
            //Debug.Log(vertexAB.ToString());


            //Vector2 vertexP1 = coordinates.IndexOf();






            //UnityEngine.InputSystem.EnhancedTouch.Touch touch1 = Input.GetTouch(0);

            //if (touch1.phase == TouchPhase.Moved)
            //{
            //    rawTouchPosition_1 = touch1.rawPosition;
            //    //Debug.Log(rawTouchPosition_1);
            //    touch_data1.text = Input.GetTouch(0).position.ToString();
            //    //touch_data1.Clear();

            //}


            //Theta_.text = (Mathf.Atan2(third_pt, second_pt) * Mathf.Rad2Deg).ToString();

        }
        else
        {
            touch_data1.text = "No touch_1 contacts";
            touch_data2.text = "No touch_2 contacts";
            touch_data3.text = "No touch_3 contacts";
        }
    }
}