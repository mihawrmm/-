using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ргр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            string newTeam = txtNewTeam.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newTeam) && !lstTeams.Items.Contains(newTeam))
            {
                lstTeams.Items.Add(newTeam);
                txtNewTeam.Clear();
            }
        }

        private void btnRemoveTeam_Click(object sender, EventArgs e)
        {
            if (lstTeams.SelectedItem != null)
            {
                lstTeams.Items.Remove(lstTeams.SelectedItem);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var teams = new List<string>();
            foreach (var item in lstTeams.Items)
            {
                teams.Add(item.ToString());
            }

            if (teams.Count < 2 || teams.Count % 2 != 0)
            {
                MessageBox.Show("Введіть парну кількість команд (мінімум 2)", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var schedule = GenerateRoundRobinSchedule(teams);
            txtSchedule.Clear();

            for (int i = 0; i < schedule.Count; i++)
            {
                txtSchedule.AppendText("Тур " + (i + 1) + ":\r\n");
                foreach (var match in schedule[i])
                {
                    txtSchedule.AppendText(match.Item1 + " — " + match.Item2 + "\r\n");
                }
                txtSchedule.AppendText("\r\n");
            }
        }

        private List<List<Tuple<string, string>>> GenerateRoundRobinSchedule(List<string> teams)
        {
            int n = teams.Count;
            var schedule = new List<List<Tuple<string, string>>>();

            for (int round = 0; round < n - 1; round++)
            {
                var roundMatches = new List<Tuple<string, string>>();
                for (int i = 0; i < n / 2; i++)
                {
                    string home = teams[i];
                    string away = teams[n - 1 - i];
                    roundMatches.Add(new Tuple<string, string>(home, away));
                }
                schedule.Add(roundMatches);

                var last = teams[n - 1];
                teams.RemoveAt(n - 1);
                teams.Insert(1, last);
            }

            return schedule;
        }
    }
}
