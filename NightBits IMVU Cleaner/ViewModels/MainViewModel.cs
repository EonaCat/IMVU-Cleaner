using NightBits_IMVU_Cleaner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightBits_IMVU_Cleaner.ViewModels
{
    /* Copyright by Jeroen Saey (NightBits) */

    public class MainViewModel
    {
        IMVU _imvu = new IMVU();
     
        public void CleanCache()
        {
            _imvu.CleanCache();
        }

        public void CleanAvi()
        {
            _imvu.CleanAvi();
        }

        public void CleanLogs()
        {
            _imvu.CleanLogs();
        }

        public void KillImvu()
        {
            _imvu.Kill();
        }

        public bool isRunning()
        {
            return _imvu.isRunning();
        }
    }
}
