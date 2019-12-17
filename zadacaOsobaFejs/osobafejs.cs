using System;
using System.Collections.Generic;
using System.Collections;

namespace OsobaFejs
{

    class Osoba : IComparable<Osoba>
    {
        public string ime, prezime;
        public Fejs f;
        private List<Osoba> listaPrijatelja;
        public bool izbacena;
        private Osoba(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
            listaPrijatelja = new List<Osoba>();
            izbacena = false;
            f = null;

        }

        public int BrojPrijatelja
        { 
            get 
            {
                if (!this.izbacena) return this.listaPrijatelja.Count;
                else throw new InvalidOperationException("Osoba je izbačena."); 
            } 
        }

        public static Osoba StvoriOsobu(string ime, string prezime, Fejs f)
        {
            Osoba o = new Osoba(ime, prezime);
            o.f = f;
            return o;
        }

        public List<Osoba> prijatelji()
        {
            if (!this.izbacena) return this.listaPrijatelja;
            else throw new InvalidOperationException("Osoba je izbačena.");
        }

        public void izbaciPrijatelja(Osoba o)
        {
            if (this.listaPrijatelja.Contains(o))
                this.listaPrijatelja.Remove(o);

        }


        public int CompareTo(Osoba o)
        {
            if (!this.izbacena && !o.izbacena)
            {
                if (this.BrojPrijatelja.CompareTo(o.BrojPrijatelja) != 0)
                    return this.BrojPrijatelja.CompareTo(o.BrojPrijatelja);

                else
                {
                    if (this.prezime.CompareTo(o.prezime) != 0)
                        return this.prezime.CompareTo(o.prezime);

                    else return this.ime.CompareTo(o.ime);
                }

            }
            else throw new InvalidOperationException("Jedna od osoba je izbacena");
        }

        public static Osoba operator +(Osoba o1, Osoba o2)
        {
            if (o1.f.Equals(o2.f))
            {
                if (!o1.izbacena && !o2.izbacena)
                {
                    if (!o1.listaPrijatelja.Contains(o2) && !o2.listaPrijatelja.Contains(o1))
                    {
                        o1.listaPrijatelja.Add(o2);
                        o2.listaPrijatelja.Add(o1);
                        return o1;
                    }

                    else throw new InvalidOperationException("Osobe su već prijatelji.");
                    
                }
                else throw new InvalidOperationException("Barem jedna od osoba je izbačena s fejsa");
            }

            else throw new InvalidOperationException("Osobe nisu s istog fejsa");
            
        }

        public static Osoba operator -(Osoba o1, Osoba o2)
        {
            if (o1.f.Equals(o2.f))
            {
                if (o1.BrojPrijatelja == 0)
                { o1.f.izbaci(o1);  throw new NullReferenceException("Osoba više nit nema prijatelje"); }

                if (o2.BrojPrijatelja == 0) 
                { o2.f.izbaci(o2); throw new NullReferenceException("Osoba više nit nema prijatelje"); }

                if (!o1.izbacena && !o2.izbacena)
                {
                    if (o1.listaPrijatelja.Contains(o2) && o2.listaPrijatelja.Contains(o1))
                    {
                        o1.listaPrijatelja.Remove(o2);
                        o2.listaPrijatelja.Remove(o1);
                        
                        return o1;
                    }

                    else throw new InvalidOperationException("Osobe uopće nisu prijatelji.");

                }
                else throw new InvalidOperationException("Barem jedna od osoba je izbačena s fejsa");
            }

            else throw new InvalidOperationException("Osobe nisu s istog fejsa");

        }

        public override bool Equals(object obj)
        {
            Osoba isOsoba = obj as Osoba;
            if (isOsoba == null)  return false;
            
            return (this.ime.Equals(isOsoba.ime) && this.prezime.Equals(isOsoba.prezime));
        }

        public override int GetHashCode()
        {
            return this.ime.GetHashCode() + this.prezime.GetHashCode();
        }


        //public static bool operator ==(Osoba o1, Osoba o2) => (o1.ime == o2.ime && o1.prezime == o2.prezime);
        //public static bool operator !=(Osoba o1 , Osoba o2) => !(o1.ime == o2.ime && o1.prezime == o2.prezime);
        public override string ToString()
        {
            return this.ime + " " + this.prezime;
        }
    }





    class Fejs : IEnumerable<Osoba>, IComparable<Fejs>, IComparer<Osoba>
    {
        private List<Osoba> listaOsoba;
        public string imeFejsa;

        public Fejs(string imeFejsa)
        {
            this.imeFejsa = imeFejsa;
            this.listaOsoba = new List<Osoba>();
        }
        public Osoba dodaj(string ime, string prezime)
        {
            Osoba o = Osoba.StvoriOsobu(ime, prezime, this);
            this.listaOsoba.Add(o);
            return o;
        }

        public void izbaci(Osoba o)
        {

            if (o.BrojPrijatelja == 0)
            {
                if(this.listaOsoba.Contains(o))
                this.listaOsoba.Remove(o);
                o.f = null;
                o.izbacena = true;
            }
            
            else if (this.Equals(o.f))
            {
                
                this.listaOsoba.Remove(o);
                o.f = null;
                o.izbacena = true;

               
                foreach (Osoba prijatelj in this.listaOsoba)
                    prijatelj.izbaciPrijatelja(o);


            }
            else throw new InvalidOperationException("Osoba nije u ovom fejsu");
        }

        

        public Dictionary<string,Osoba> this[string prezime]
        {
            get
            {
                Dictionary<string,Osoba> osobeSPrezimenom = new Dictionary<string, Osoba>();
                foreach (Osoba o in this.listaOsoba)
                    if (o.prezime == prezime)
                        osobeSPrezimenom.Add(o.ime,o);

                return osobeSPrezimenom;
            }

        }

        public IEnumerator<Osoba> GetEnumerator()
        {
            foreach (Osoba o in this.listaOsoba)
                yield return o;
        }

      
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Fejs f) => this.imeFejsa.CompareTo(f.imeFejsa);


        public int Compare(Osoba o1, Osoba o2) => o1.CompareTo(o2);

        public void Sort() => this.listaOsoba.Sort();

        public void IspisiSveSFejsa()
        {
            foreach (Osoba o in this)
                Console.WriteLine(o);
        }

        public Queue<Osoba> meduPrijatelji(Osoba o1, Osoba o2)
        {

            if (o1.f == this && o2.f == this)
            {
                if (o1.f == o2.f)
                {
                    Queue<Osoba> redMeduPrijatelja = new Queue<Osoba>();
                    foreach (Osoba prijateljO1 in o1.prijatelji())
                        foreach (Osoba prijateljO2 in o2.prijatelji())
                            //if (prijateljO1.Equals(prijateljO2))
                            if (prijateljO1 == prijateljO2)
                                redMeduPrijatelja.Enqueue(prijateljO1);

                    return redMeduPrijatelja;
                }

                else throw new InvalidOperationException("Osobe nisu na istom fejsu");
            }

            else throw new InvalidOperationException("Bar jedna od osoba se ne nalazi na ovom fejsu");

            
        }

        public override bool Equals(object f)
        {
            Fejs isFejs = f as Fejs;
            if (isFejs == null)  return false; 
            else return this.imeFejsa.Equals(isFejs.imeFejsa);
        }

        public override int GetHashCode()
        {
            return this.imeFejsa.GetHashCode();
        }

        public override string ToString()
        {
            return this.imeFejsa;
        }
    }

    

    



    class Program
    {
        static void Main(string[] args)
        {
            Fejs f = new Fejs("qwertz");
            Osoba o1 = f.dodaj("Ella", "Dvornik");
            Osoba o2 = f.dodaj("Lidija", "Bacic");
            Osoba o3 = f.dodaj("Nera", "Nikolic");
            Osoba o4 = f.dodaj("Sonja", "Kovac");
            Osoba o5 = f.dodaj("Niko", "Kovac");
            Osoba o6 = f.dodaj("Miso", "Kovac");
            Osoba o7 = f.dodaj("Dino", "Peric");
            Osoba o8 = f.dodaj("Jelena", "Peric");
            Osoba o9 = f.dodaj("Andela", "Ledenko");

            Console.WriteLine("Sve osobe na fejsu : {0}", f.imeFejsa);
            f.IspisiSveSFejsa();
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Osobe s prezimenom: Kovac");
            Dictionary<string, Osoba> osobeSPrezimenom = new Dictionary<string, Osoba>();
            osobeSPrezimenom = f["Kovac"];
            foreach (KeyValuePair<string, Osoba> osp in osobeSPrezimenom)
                Console.WriteLine(osp.Key, osp.Value);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Osoba s prezimenom Kovac i imenom Sonja: {0}", osobeSPrezimenom["Sonja"]);
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Nakon sorta:");
            f.Sort();
            f.IspisiSveSFejsa();
            Console.WriteLine("---------------------------------------------------");

            try
            {
                o1 += o2;
                o1 += o3;
                o1 += o4;
                o2 += o3;
                o2 += o4;
                o2 += o6;
                o2 += o9;
                o3 += o6;
                o3 += o8;
                o3 += o9;
                o4 += o5;
                o4 += o6;
                o4 += o7;
                o5 += o8;
                o5 += o7;
                o6 += o9;
            } catch(InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            try
            { o6 += o9; }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Osoba o4:\n");
            Console.WriteLine(o4.BrojPrijatelja);
            foreach (Osoba o in o4.prijatelji())
                Console.WriteLine(o);
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Osoba o7 prije izbacivanja:\n");
            Console.WriteLine(o7.BrojPrijatelja);
            Console.WriteLine(o7.izbacena);
            Console.WriteLine(o7.f);
            foreach (Osoba o in o7.prijatelji())
                Console.WriteLine(o);
            Console.WriteLine("---------------------------------------------------");

            try
            {
                o7 -= o4;
                o7 -= o5;
            }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            try { o7 -= o4; } 
            catch (NullReferenceException ex) { Console.WriteLine(ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Osoba o7 poslije izbacivanja:\n");
            try
            { Console.WriteLine(o7.BrojPrijatelja); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine(o7.izbacena);
            if(o7.f == null) Console.WriteLine("Nema fejsa.");
            try
            {
                foreach (Osoba o in o7.prijatelji())
                    Console.WriteLine(o);
            }catch(InvalidOperationException ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Meduprijatelji: ");
            Queue<Osoba> redMeduprijatelja = f.meduPrijatelji(o1, o2);
            foreach (Osoba o in redMeduprijatelja)
                Console.WriteLine(o);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Povratak o7 na Fejs");
            o7 = f.dodaj(o7.ime, o7.prezime);
            o7 += o9;
            o7 += o8;
            Console.WriteLine("Br. prijatelja: {0}", o7.BrojPrijatelja);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Fejs2:");

            Fejs f2 = new Fejs("jabuka");
            Osoba a1 = f2.dodaj("Prank", "Sinatra");
            Osoba a2 = f2.dodaj("Dinah", "Mite");
            Osoba a3 = f2.dodaj("Nera", "Nikolic");
            Osoba a4 = f2.dodaj("Sonja", "Kovac");
            Osoba a5 = f2.dodaj("Don", "Keigh");
            Osoba a6 = f2.dodaj("Miso", "Kovac");
            Osoba a7 = f2.dodaj("Ben", "Dover");
            Osoba a8 = f2.dodaj("Eileen", "Dover");
            Osoba a9 = f2.dodaj("Jack", "Inoff");
            Osoba a10 = f2.dodaj("Ivana", "Fuccu");
            Osoba a11 = f2.dodaj("Bon", "Herr");
            Osoba a12 = f2.dodaj("Jack", "Pott");


            try
            {
                a1 += a2;
                a1 += a3;
                a1 += a4;
                a1 += a5;
                a4 += a2;
                a4 += a5;
                a4 += a6;
                a4 += a7;
                a6 += a7;
                a6 += a10;
                a6 += a11;
            }
            catch(InvalidOperationException ex)
            { Console.WriteLine(ex.Message); }

            try
            { a4 += a6; }
            catch(InvalidOperationException ex)
            { Console.WriteLine(ex.Message); }

            try
            { a4 += o6; }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("---------------------------------------------------");

            try
            { f2.izbaci(o6); }
            catch(InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            try
            { Queue<Osoba> redMeduprijatelja2 = f.meduPrijatelji(a4, o6); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            try
            { a3 -= o3; }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Prijatelji: ");
            foreach (Osoba o in a4.prijatelji())
                Console.WriteLine(o);
            Console.WriteLine("Broj prijatelja: {0}", a4.BrojPrijatelja);
            Console.WriteLine("---------------------------------------------------");

            try
            { 
                Queue<Osoba> redMeduprijatelja3 = f2.meduPrijatelji(a1, a4);
                Console.WriteLine("Meduprijatelji: ");
                foreach (Osoba a in redMeduprijatelja3)
                    Console.WriteLine(a.ToString());
            }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }


        }
    }
}
