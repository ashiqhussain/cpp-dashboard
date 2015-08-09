using System;
using System.Collections.Generic;
using System.Linq;
using CppDashboard.DataProvider;
using CppDashboard.Models;

namespace CppDashboard.Logic
{
    public class DataLoader
    {
        private static readonly int InitialReadTimeDuration = 2;
        private static readonly DataLoader _instance = new DataLoader();
        private static bool _loaded;

        public bool IsSystemOnline
        {
            get
            {
                //var automatic = int.Parse(_configs.First(h => h.Key.Equals("Offline:Status")).Value);
                //var manual = int.Parse(_configs.First(h => h.Key.Equals("Offline:ManualOverrideEnabled")).Value);

                //if (automatic == 1 || manual == 1)
                //{
                //    return false;
                //}

                return true;
            }
        }

        public static DataLoader Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Load()
        {
            lock (this)
            {
                if (_loaded)
                {
                    throw new InvalidOperationException("Data is already loaded");
                }

                _loaded = true;    
            }
        }
    }
}