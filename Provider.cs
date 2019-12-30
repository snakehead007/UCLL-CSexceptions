using System;
using System.Collections;
using System.Collections.Generic;

namespace exceptions
{
    public class Provider
    {
        public enum Status {Online, Offline, Restricted };
        public Status status;
        
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        private int connectieSnelheid;
        public int ConnectieSnelheid
        {
            get { return connectieSnelheid; }
            set { connectieSnelheid = value; }
        }

        private List<Smartphone> smartphones;
        public List<Smartphone> Smartphones
        {
            get { return smartphones; }
            set { smartphones = value; }
        }

        public Provider(string naam, int connectieSnelheid)
        {
            this.naam = naam;
            this.connectieSnelheid = connectieSnelheid;
            smartphones = new List<Smartphone>();
        }
        
        private void VoegSmartphoneToe(Smartphone smartphone)
        {
            try
            {
                if (status != Status.Online)
                {
                    throw new OfflineSatusException("Provider niet offline.");
                }
                if (smartphone.Verbind(connectieSnelheid))
                {
                    throw new VerbindingsFoutException("Apparaat niet compatibel met het netwerk.");
                }
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            smartphones.Add(smartphone);
            
        }

        public string GeefOmschrijving()
        {
            string str = naam + "\n" +
                         "\t- Connectiesnelheid: " + connectieSnelheid + "\n" +
                         "\t- Status: " + status+"\n"+
                         "\t- Overzicht smartphones:\n";
            foreach (var telefon in smartphones)
            {
                str += "\t\t"+telefon.GeefOmschrijving()+"\n";
            }
            return str;
        }
    }
}