using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeno
{
    public class Screeno
    {
        #region Internal Properties
        internal static Screeno Instance { get; private set; }
        internal string Path { get; private set; }
        internal TimeSpan BufferTime { get; private set; }
        #endregion

        #region Constructors
        public Screeno(string savePath, TimeSpan bufferTime)
        {
            if(Instance != null)
            {
                throw new InvalidDataException("Screeno has already been instantiated. Please ensure you only have 1 Screeno instance.");
            }

            Instance = this;

            if (Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            Path = savePath;
            BufferTime = bufferTime;
        }

        public Screeno(string savePath) : this(savePath, new TimeSpan(0, 0, 3))
        {

        }
        #endregion
    }
}
