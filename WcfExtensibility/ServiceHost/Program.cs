﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new System.ServiceModel.ServiceHost(typeof(PersonService)))
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
