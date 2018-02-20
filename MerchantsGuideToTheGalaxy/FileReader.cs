using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MerchantsGuideToTheGalaxy.GalaxyFile
{
    /// <summary>
    /// Read the content of a galaxy file.
    /// </summary>
    public class FileReader
    {

        /// <summary>
        /// Reads the lines of the galaxy file.
        /// </summary>
        /// <param name="path">The full path to the file.</param>
        /// <returns>
        ///     Empty string if the file don't exists or don't have content. Otherwise, return all the content.
        /// </returns>
        public string ReadLines(string path)
        {
            var content = string.Empty;
            
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        content += line + Environment.NewLine;
                    }
                }
            }

            return content.TrimEnd();
        }
    }
}
