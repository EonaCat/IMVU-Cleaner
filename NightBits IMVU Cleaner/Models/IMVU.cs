using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightBits_IMVU_Cleaner.Models
{
    /* Copyright by Jeroen Saey (NightBits) */

    public class IMVU
    {
        private String _DEFAULT_IMVU_CLIENT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\IMVUClient\";
        private String _DEFAULT_IMVU_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\IMVU\";
        private const String _APPLICATION = "IMVUClient";
        private const String _QUALITY_APPLICATION = "IMVUQualityAgent";

        public void CleanCache()
        {
            if (_IsIMVUInstalled())
            {
                Debug.WriteLine("Cleaning Cache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_CLIENT_PATH + @"ui\profile\Cache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "ProductFiles");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "Cache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "AssetCache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "HttpCache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "PixmapCache");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH + "avpics");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.cache");
            }
            else
            {
                Debug.WriteLine("IMVU is not installed!");
            }
        }

        public void CleanAvi()
        {
            if (_IsIMVUInstalled())
            {
                Debug.WriteLine("Cleaning Avi");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*productInfoCache.db*");
            }
            else
            {
                Debug.WriteLine("IMVU is not installed!");
            }
        }

        public void CleanLogs()
        {
            if (_IsIMVUInstalled())
            {
                Debug.WriteLine("Cleaning Logs");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.log*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.1*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.2*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.3*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.4*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.5*");
                _DeleteFilesInDirectory(_DEFAULT_IMVU_PATH, "*.6*");
            }
            else
            {
                Debug.WriteLine("IMVU is not installed!");
            }
        }

        public void Kill()
        {
            Process[] processName = Process.GetProcessesByName(_APPLICATION);

            foreach (Process currentProcess in processName)
            {
                currentProcess.Kill();
            }

            processName = Process.GetProcessesByName(_QUALITY_APPLICATION);

            foreach (Process currentProcess in processName)
            {
                currentProcess.Kill();
            }
        }

        public bool isRunning()
        {
            Process[] processName = Process.GetProcessesByName(_APPLICATION);
            return processName.Length != 0;
        }

        private void _DeleteFilesInDirectory(String currentDirectory, String searchPattern="*.*")
        {
            Directory.EnumerateFiles(currentDirectory, searchPattern).ToList().ForEach(file => File.Delete(file));
        }

        private bool _IsIMVUInstalled()
        {
            return Directory.Exists(_DEFAULT_IMVU_CLIENT_PATH);
        }

        private void _DeleteFilesInDirectory(String directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            DirectoryInfo currentDirectory = new DirectoryInfo(directory);

            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    Debug.WriteLine(fileNotFoundException.Message);
                }
            }

            foreach (DirectoryInfo subDirectory in currentDirectory.GetDirectories())
            {
                try
                {
                    subDirectory.Delete(true);
                }
                catch (DirectoryNotFoundException directoryNotFoundException)
                {
                    Debug.WriteLine(directoryNotFoundException.Message);
                }
            }
        }
    }
}
