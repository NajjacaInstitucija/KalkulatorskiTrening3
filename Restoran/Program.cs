using System;
using System.Collections;
using System.Collections.Generic;

namespace Restoran
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, IDictionary<string, int>> jela = new Dictionary<string, IDictionary<string,int>>();
            IDictionary<string, int> restorani = new Dictionary<string, int>();

            while(true)
            {
                string restoran = Console.ReadLine();
                string brs = Console.ReadLine();
                int brJela = Convert.ToInt32(brs);
                if (brJela == 0) break;

                for(int i = 0; i < brJela; ++i)
                {
                    string jelo = Console.ReadLine();

                    if (!jela.ContainsKey(jelo))
                    {
                        restorani = new Dictionary<string, int>();
                        restorani.Add(restoran, 1);
                        jela.Add(jelo, restorani);
                    }

                    else
                    {
                        restorani = jela[jelo];
                        if(!restorani.ContainsKey(restoran))
                        {

                            restorani[restoran] = 1;
                            jela[jelo] = restorani;
                        }
                        
                        else
                        {
                            
                            restorani[restoran]++;
                            jela[jelo] = restorani;
                        }
                    }
                    
                }


                foreach(KeyValuePair<string, IDictionary<string, int>> kvp in jela)
                {
                    restorani = kvp.Value;
                    Console.WriteLine("{0}: ", kvp.Key);
                    foreach (KeyValuePair<string, int> k in restorani)
                    {

                         Console.WriteLine("({0}, {1})", k.Key, k.Value);
                    }
                }

            }

            
        }
    }
}
