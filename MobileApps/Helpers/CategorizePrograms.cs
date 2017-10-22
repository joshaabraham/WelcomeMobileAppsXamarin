using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.BL.Services
{
    public class CategorizePrograms
    {
        public static List<Program> CategorizeByProgramType(List<Program> AllPrograms, string categorizeKey)
        {
            List<Program> result = new List<Program>();

            foreach (Program currentProgram in AllPrograms)
            {
                if (currentProgram.Name.Contains(categorizeKey))
                    result.Add(currentProgram);
            }
            return result;
        }
    }
}
