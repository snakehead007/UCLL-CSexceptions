using System;

namespace exceptions
{
    public class Smartphone
    {
        private int connectieSnelheid;
        public int ConnectieSnelheid
        {
            get { return connectieSnelheid; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ConnectieSnelheidException("ConnectieSnelheid negatief");
                    }
                    connectieSnelheid = value;
                }
                catch (ConnectieSnelheidException err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Smartphone(int connectieSnelheid, string model)
        {
            this.connectieSnelheid = connectieSnelheid;
            this.model = model;
        }
        public bool Verbind(int connectieSnelheid)
        {
            return this.connectieSnelheid >= connectieSnelheid;
        }

        public string GeefOmschrijving()
        {
            return "Smartphone " + model + " / Connectie snelh.: " + connectieSnelheid;
        }
    }
}