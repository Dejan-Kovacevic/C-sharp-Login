using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Gibt an, ob die Zündung aktuell eingeschaltet ist.
        private bool zuendungAktiv = false;

        // Beispielwerte für die einzelnen Fahrzeugsysteme in der Liste.
        private readonly Dictionary<string, string> systemwerte = new Dictionary<string, string>
        {
            { "Benzin",         "62 %" },
            { "Fehlermeldung",  "Keine" },
            { "Klimaanlage",    "Aus" },
            { "Trip",           "124 km" },
            { "Kilometerstand", "84.213 km" },
            { "Temperatur",     "21 °C" },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Anzeige in den Grundzustand versetzen.
            ZuendungAnzeigen();
            lblSystemwert.Text = "—";
        }

        private void cmdbtn2_Click(object sender, EventArgs e)
        {
            // Zündung umschalten (ein/aus).
            zuendungAktiv = !zuendungAktiv;
            ZuendungAnzeigen();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string auswahl = listBox1.SelectedItem as string;
            if (auswahl == null)
            {
                return;
            }

            // Uhrzeit wird live ermittelt, alle anderen Werte kommen aus der Tabelle.
            if (auswahl == "Uhrzeit")
            {
                lblSystemwert.Text = DateTime.Now.ToString("HH:mm");
            }
            else if (systemwerte.TryGetValue(auswahl, out string wert))
            {
                lblSystemwert.Text = wert;
            }
            else
            {
                lblSystemwert.Text = "—";
            }
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Aktualisiert Beschriftung, Farbe und Statuszeile passend zum Zündungszustand.
        private void ZuendungAnzeigen()
        {
            if (zuendungAktiv)
            {
                Txtlbl2.Text = "Zündung: Aktiviert";
                Txtlbl2.ForeColor = Color.ForestGreen;
                cmdbtn2.Text = "Zündung ausschalten";
                lblStatus.Text = "Motor betriebsbereit – Zündung aktiviert.";
            }
            else
            {
                Txtlbl2.Text = "Schlüssel";
                Txtlbl2.ForeColor = Color.Gray;
                cmdbtn2.Text = "Zündung einschalten";
                lblStatus.Text = "Bereit – Zündung aus.";
            }
        }
    }
}
