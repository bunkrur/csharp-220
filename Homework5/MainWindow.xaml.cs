using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Homework5
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "X's Turn";
        }

        private string turn = "X";
        Dictionary<string, string> ScoreDict = new Dictionary<string, string>();

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == null && !uxTurn.Text.Contains("Wins"))
            {
                ((Button)sender).Content = turn;
                CheckForWinner((Button)sender);
            }
            else
            {
                uxNewGame_Click(sender, e);
            }
        }

        private void CheckForWinner(Button btn)
        {
            List<string> xList = new List<string>();
            ScoreDict.Add(btn.Tag.ToString(), btn.Content.ToString());
            var checkArr = ScoreDict.Where(x => x.Value == turn).OrderBy(x => x.Key).Select(x => x.Key).ToArray();
            if (checkArr.Length >= 3)
            {
                if ((checkArr.Contains("0,0") & checkArr.Contains("0,1") & checkArr.Contains("0,2")) ||
                    (checkArr.Contains("1,0") & checkArr.Contains("1,1") & checkArr.Contains("1,2")) ||
                    (checkArr.Contains("2,0") & checkArr.Contains("2,1") & checkArr.Contains("2,2")) ||
                    (checkArr.Contains("0,0") & checkArr.Contains("1,1") & checkArr.Contains("2,2")) ||
                    (checkArr.Contains("2,0") & checkArr.Contains("1,1") & checkArr.Contains("0,2")) ||
                    (checkArr.Contains("0,0") & checkArr.Contains("1,0") & checkArr.Contains("2,0")) ||
                    (checkArr.Contains("0,1") & checkArr.Contains("1,1") & checkArr.Contains("2,1")) ||
                    (checkArr.Contains("0,2") & checkArr.Contains("1,2") & checkArr.Contains("2,2")))
                {
                    uxTurn.Text = turn.ToString() + " Wins";
                }
                else
                {
                    SwapTurns(btn);
                }
            }
            else if (checkArr.Length == 5)
            {
                uxTurn.Text = "NaN";
                EmptyBoard();
            }
            else
            {
                SwapTurns(btn);
            }
        }

        private void SwapTurns(Button btn)
        {
            if (turn == "X")
            {
                uxTurn.Text = "O's Turn";
                turn = "O";
            }
            else
            {
                uxTurn.Text = "X's Turn";
                turn = "X";
            }
        }


        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            uxTurn.Text = "X's Turn";
            turn = "X";
            ScoreDict.Clear();
            EmptyBoard();
        }

        private void EmptyBoard()
        {
            foreach (UIElement child in uxGrid.Children)
            {
                ((Button)child).Content = null;
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    
}