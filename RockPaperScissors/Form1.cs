using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;
        int wins = 0;
        int losses = 0;
        int ties = 0;
        int cpuValue;


        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        Point playerLocation = new Point(168, 70);
        Point cpuLocation = new Point(360, 70);

        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            g.DrawImage(rockImage, playerLocation);
            jabPlayer.Play();
            Thread.Sleep(1000);
            cpuTurn();
            determineWinner();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            g.DrawImage(paperImage, playerLocation);
            jabPlayer.Play();
            Thread.Sleep(1000);
            cpuTurn();
            determineWinner();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissors";
            g.DrawImage(scissorImage, playerLocation);
            jabPlayer.Play();
            Thread.Sleep(1000);
            cpuTurn();
            determineWinner();
        }

        public void cpuTurn()
        {
            cpuValue = randGen.Next(1, 4);

            if (cpuValue == 1)
            {
                cpuChoice = "rock";
                g.DrawImage(rockImage, cpuLocation);
            }
            else if (cpuValue == 2)
            {
                cpuChoice = "paper";
                g.DrawImage(paperImage, cpuLocation);
            }
            else
            {
                cpuChoice = "scissors";
                g.DrawImage(scissorImage, cpuLocation);
            }

            jabPlayer.Play();
            Thread.Sleep(1000);
        }
        public void determineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                g.DrawImage(tieImage, 225, 5, 250, 150);
                ties++;
                tiesLabel.Text = "Ties: " + ties;
            }

            else if (playerChoice == "rock" && cpuChoice == "scissors")
            {
                g.DrawImage(winImage, 225, 5, 250, 150);
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else if (playerChoice == "paper" && cpuChoice == "rock")
            {
                g.DrawImage(winImage, 225, 5, 250, 150);
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else if (playerChoice == "scissors" && cpuChoice == "paper")
            {
                g.DrawImage(winImage, 225, 5, 250, 150);
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else
            {
                g.DrawImage(loseImage, 225, 5, 250, 150);
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
            gongPlayer.Play();
            Thread.Sleep(3000);
            Refresh();
        }
    }
}