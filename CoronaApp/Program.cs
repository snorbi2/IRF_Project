using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoronaApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var inputParser = new InputParser("./input/input-2020-12-05.xml");
            var counties = inputParser.Parse();
            using (var db = new CountyContext())
            {
                foreach (var county in counties)
                {
                    var tmpCounty = db.Counties.Find(county.Name);
                    if (tmpCounty != null)
                        db.Counties.Remove(tmpCounty);
                    db.Counties.Add(county);
                }
                db.SaveChanges();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(db));
            }
        }
    }
}
