using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mock3SemPrepWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static List<Catch> catchList = new List<Catch>()
        {
            new Catch(1, "EbbeVand", "Gedde", 3.75, "Aresø", 2),
            new Catch(2, "PeterStor", "Ørred", 1.55, "Emsø", 7),
            new Catch(3, "AndyBor", "Skalle", 0.35, "Vejlesø", 25)
        };

        /// Opgave 1

        public List<Catch> GetCatches()
        {

            //foreach (Catch @catch in catchList)
            //{   
            //    @catch.ToString();
            //}
            return catchList;
        }

        public Catch GetOneCatch(string id)
        {
            int idInt = int.Parse(id);
            return catchList.Find(Catch => Catch.Id == idInt);
        }

        public Catch AddCatch(Catch newCatch)
        {
            catchList.Add(newCatch);
            return newCatch;
        }

        public Catch UpdateCatch(string id, Catch udcatch)
        {
            int idint = int.Parse(id);
            Catch existingCatch = catchList.FirstOrDefault(eC => eC.Id == idint);
            if (existingCatch == null)
            {
                return null;
            }
            if (udcatch.Navn != null) 
            {
                existingCatch.Navn = udcatch.Navn;
            }
            if (udcatch.Art != null)
            {
                existingCatch.Art = udcatch.Art;
            }
            if (udcatch.Vaegt != 0)
            {
                existingCatch.Vaegt = udcatch.Vaegt;
            }
            if (udcatch.Sted != null)
            {
                existingCatch.Sted = udcatch.Sted;
            }
            if (udcatch.Uge != 0)
            {
                existingCatch.Uge = udcatch.Uge;
            }
            return existingCatch;
        }

        public Catch DeleteCatch(string id)
        {
            int idint = int.Parse(id);
            Catch delCatch = catchList.Find(ca => ca.Id == idint);
            if (delCatch == null)
            {
                return null;
            }
            catchList.Remove(delCatch);
            return delCatch;
        }


    }
}
