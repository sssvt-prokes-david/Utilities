﻿using System;
using System.Drawing;
using UtilitiesDraw.PaintersObjects;

namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class Window : BuildingElement
    {



        private string modelName;
        private double width;
        private double height;



        public Window(string modelName, double width, double height)
        {
            this.modelName = modelName;
            this.width = width;
            this.height = height;
        }



        public string ModelName
        {
            get
            {
                return modelName;
            }

            set
            {
                modelName = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }



        // Model "Standard", 0,8 metru x 1,5 metru
        public static Window GetStandardWindow()
        {
            Window window = new Window("Standard", 0.8, 1.5);
            return window;
        }



        // Model "Francouz", 1,0 metru x 2,2 metru
        public static Window GetFrenchWindow()
        {
            Window window = new Window("Francouz", 1.0, 2.2);
            return window;
        }

        public override void DrawSelf(Graphics g, CanvasContext context)
        {
            int windowHeight = 200;
            int widowWidth = 200;
            Rectangle window = new Rectangle(context.Left + 500, context.Height - 350, widowWidth, windowHeight);
            using (Pen pen = new Pen(Color.Black, 2.0f))
            {
                g.DrawRectangle(pen, window);
                g.DrawLine(pen, window.Left, window.Top + 100, window.Right, window.Top +100);
                g.DrawLine(pen, window.Left + 100, window.Top, window.Left + 100, window.Bottom);
            }
        //    Rectangle window2 = new Rectangle(context.Left + 100, context.Height - 225, widowWidth, windowHeight);
        //    using (Pen pen = new Pen(Color.Black, 2.0f))
        //    {
        //        g.DrawRectangle(pen, window2);
        //        g.DrawLine(pen, window2.Left, window2.Top + 100, window2.Right, window2.Top + 100);
        //        g.DrawLine(pen, window2.Left + 100, window2.Top, window2.Left + 100, window2.Bottom);
        //    }
        }

    }



}
