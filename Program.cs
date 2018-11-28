using System;
using System.Collections;
using System.Collections.Generic;

namespace MediaPerAlunno
{
    class Program 
    {
        static void StampaMedie(List<Scheda> recordSet)
        {
            string codiceAlunno = "";
            int numGare = 0;
            double media = 0.0;

            IEnumerator<Scheda> enumerator = recordSet.GetEnumerator();

            bool primoGiro = true;

            while (enumerator.MoveNext())
            {
                if (primoGiro)
                {
                    codiceAlunno = enumerator.Current.CodiceAlunno;
                    media = enumerator.Current.Voto;
                    numGare = 1;
                    primoGiro = false;
                }
                else
                {
                    if(enumerator.Current.CodiceAlunno == codiceAlunno)
                    {
                        media += enumerator.Current.Voto;
                        numGare++;
                    }
                    else
                    {
                        media /= numGare;
                        Console.WriteLine("Alunno {0}. Media : {1}", codiceAlunno, media);
                        media = enumerator.Current.Voto;
                        numGare = 1;
                        codiceAlunno = enumerator.Current.CodiceAlunno;
                    }
                }

            }
            media /= numGare;
            Console.WriteLine("Alunno {0}. Media : {1}", codiceAlunno, media);
        }

        static void Main(string[] args)
        {
            List<Scheda> recordSet = new List<Scheda>();
            recordSet.Add(new Scheda { CodiceAlunno = "A001", CodiceGara = "G001", Voto = 6 });
            recordSet.Add(new Scheda { CodiceAlunno = "A001", CodiceGara = "G001", Voto = 6 });
            recordSet.Add(new Scheda { CodiceAlunno = "A002", CodiceGara = "G001", Voto = 7 });
            recordSet.Add(new Scheda { CodiceAlunno = "A002", CodiceGara = "G001", Voto = 10});
            recordSet.Add(new Scheda { CodiceAlunno = "A002", CodiceGara = "G001", Voto = 6 });
            recordSet.Add(new Scheda { CodiceAlunno = "A002", CodiceGara = "G001", Voto = 4 });
            recordSet.Add(new Scheda { CodiceAlunno = "A003", CodiceGara = "G001", Voto = 10});
            recordSet.Add(new Scheda { CodiceAlunno = "A003", CodiceGara = "G001", Voto = 8 });
            recordSet.Add(new Scheda { CodiceAlunno = "A003", CodiceGara = "G001", Voto = 8 });
            recordSet.Add(new Scheda { CodiceAlunno = "A003", CodiceGara = "G001", Voto = 9 });

            StampaMedie(recordSet);

            Console.WriteLine("Hello World!");
        }
    }
}
