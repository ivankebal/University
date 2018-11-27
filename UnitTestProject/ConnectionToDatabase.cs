using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    /// <summary>
    /// Database which will be used for tests; if is not exist, EF will create it
    /// </summary>
    public static class TestDBConnection
    {
        public static string ConnectionString()
        {
            return "UniversityTest";
        }
    }
}
