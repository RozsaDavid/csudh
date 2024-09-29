namespace csudh {
    public class IPaddress {
        public string domain;
        public string address;

        public IPaddress(string domain, string address) {
            this.domain = domain;
            this.address = address;
        }

        public string Domain(int level) {
            string[] domain = this.domain.Split(".");
            if(domain.Length < level || domain[0] == "")
                return "nincs";
            else
                return domain[domain.Length - level];

        }
    }

    class Program {
        static void Main(string[] args) {
            List<IPaddress> addresses = new List<IPaddress>();

            try {
                StreamReader sr = new StreamReader("csudh.txt");
                string line = sr.ReadLine();
                while(!sr.EndOfStream) {
                    line = sr.ReadLine();
                    string[] read = line.Split(";");
                    addresses.Add(new IPaddress(read[0], read[1]));
                }
                sr.Close();
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.WriteLine("3. feladat: Domainek száma: " + addresses.Count);
            Console.WriteLine("5. feladat: Az első domain felépítése:");
            for(int i = 1;i <= 5;i++)
                Console.WriteLine("\t" + i + ". szint: " + addresses[0].Domain(i));

            try {
                StreamWriter sw = new StreamWriter("table.html");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th style='text-align: left'>Ssz</th>");
                sw.WriteLine("<th style='text-align: left'>Host domain neve</th>");
                sw.WriteLine("<th style='text-align: left'>Host IP címe</th>");
                sw.WriteLine("<th style='text-align: left'>1. szint</th>");
                sw.WriteLine("<th style='text-align: left'>2. szint</th>");
                sw.WriteLine("<th style='text-align: left'>3. szint</th>");
                sw.WriteLine("<th style='text-align: left'>4. szint</th>");
                sw.WriteLine("<th style='text-align: left'>5. szint</th>");
                sw.WriteLine("</tr>");

                for(int i = 0;i < addresses.Count;i++) {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th style='text-align: left'>" + (i + 1) + "</th>");
                    sw.WriteLine("<td>" + addresses[i].domain + "</td>");
                    sw.WriteLine("<td>" + addresses[i].address + "</td>");
                    for(int j = 1;j <= 5;j++)
                        sw.WriteLine("<td>" + addresses[i].Domain(j) + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("<table>");

                sw.Flush();
                sw.Close();

            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}

