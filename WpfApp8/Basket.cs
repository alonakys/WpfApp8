﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp8
{
    public class Basket
    {
        public int Capacity { get; set; }
        public List<Thing> things { get; set; }
        public ImageBrush Imagee { get; set; }
        public Point Position { get; set; }
        public Basket()
        {
            Capacity = 10;
            things = new List<Thing>();
            Imagee = new ImageBrush();
            Imagee.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/pngeggRight.png"));
        }


        public bool IsFull()
        {
            return things.Count >= Capacity;
        }

        public void AddThing(Thing Thing)
        {
            things.Add(Thing);
        }
    }
}
