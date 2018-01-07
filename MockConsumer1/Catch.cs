using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockConsumer1
{
    class Catch
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Art { get; set; }
        public double Vaegt { get; set; }
        public string Sted { get; set; }
        public int Uge { get; set; }

        public Catch(int id, string navn, string art, double vaegt, string sted, int uge)
        {
            Id = id;
            Navn = navn;
            Art = art;
            Vaegt = vaegt;
            Sted = sted;
            Uge = uge;
        }

        public Catch()
        {
            
        }
    }
}
