using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalaxyFile
{
    /// <summary>
    /// Holds categorized info readed from file
    /// </summary>
    public class FileInfo
    {
        public List<string> ContentLines { get; set; }
        public List<string> ValidLines { get; set; }
        public List<string> ReferenceValues { get; set; }
        public List<string> Questions { get; set; }
        public List<string> Output { get; set; }
        public bool HasInvalidExpressions { get; set; }
        
        public FileInfo()
        {
            this.ContentLines = new List<string>();
            this.ValidLines = new List<string>();
            this.ReferenceValues = new List<string>();
            this.Questions = new List<string>();
            this.Output = new List<string>();
        }
    }
}
