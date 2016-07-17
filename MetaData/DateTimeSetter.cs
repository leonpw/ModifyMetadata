using System;
using System.IO;

namespace MetaData
{
    public enum Type
    {
        File,
        Dir,
    }

    public class DateTimeSetter
    {
        private string fileName;
        private Type type;
        private DateTime dateTime;

        public DateTimeSetter(string fileName, Type type, DateTime dateTime)
        {
            this.fileName = fileName;
            this.type = type;
            this.dateTime = dateTime;
        }

        public void SetDateTime()
        {
            switch (type)
            {
                case Type.Dir:
                    SetAllDateTimesForDir();
                    break;

                case Type.File:
                    SetAllDateTimesForFile();
                    break;
            }
        }

        private bool SetAllDateTimesForFile()
        {
            try
            {
                File.SetCreationTimeUtc(fileName, dateTime);
                File.SetLastAccessTimeUtc(fileName, dateTime);
                File.SetLastWriteTimeUtc(fileName, dateTime);
                Console.WriteLine($"Set {dateTime.ToLocalTime()} metadata for file: {fileName}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SetAllDateTimesForDir()
        {
            try
            {
                Directory.SetCreationTimeUtc(fileName, (DateTime) dateTime);
                Directory.SetLastAccessTimeUtc(fileName, (DateTime) dateTime);
                Directory.SetLastWriteTimeUtc(fileName, (DateTime) dateTime);
                Console.WriteLine($"Set {dateTime.ToLocalTime()} metadata for dir: {fileName}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}