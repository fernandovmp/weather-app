using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WeatherAppTest.Helpers
{
    internal static class FromEmbedResources
    {
        internal static string ReadText(string file)
        {
            string text;
            Assembly assembly = typeof(FromEmbedResources).GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream($"WeatherAppTest.{file}"))
            {
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
            }
            return text;
        }
    }
}
