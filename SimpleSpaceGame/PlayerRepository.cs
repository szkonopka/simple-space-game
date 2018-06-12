using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleSpaceGame
{
    public class PlayerRepository
    {
        private XDocument _doc;
        public PlayerRepository()
        {

        }

        public void Add(string name, int score)
        {
            _doc = XDocument.Load("../../data/Players.xml");
            try
            {
                XElement xmlPlayer = new XElement("Player",
                    new XAttribute("Name", name),
                    new XAttribute("Score", score)
                    );
                _doc.Root.Add(xmlPlayer);
                _doc.Save("../../data/Players.xml");
            }
            catch(Exception ex)
            {

            }
        }

        public List<Player> GetAll()
        {
            _doc = XDocument.Load("../../data/Players.xml");
            try
            {
                var players = from p in _doc.Descendants("Player")
                              select new Player()
                              {
                                  Name = (string)p.Attribute("Name").Value,
                                  Score = Int32.Parse((String)p.Attribute("Score"))
                              };
                return players.OrderByDescending(p => p.Score).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
