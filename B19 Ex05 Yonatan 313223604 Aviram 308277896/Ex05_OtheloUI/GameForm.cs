using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05_OtheloEngien;

namespace Ex05_OtheloUI
{
    public partial class GameForm : Form
    {
        private readonly Button[,] m_buttons;
        private bool m_KeepPlaying = true;
        private int m_ButtonSize = 50;
        private GameEngien m_GameEngien;
        private GameBoard.eBoardDemantions m_BoardSize;
        private GameEngien.eGameMode m_GameMode;
        private readonly int m_FormSize;
        private int s_ButtonNameCounter = 0;
        private readonly Bitmap r_CoinRed = Ex05_OtheloUI.Properties.Resources.CoinRed;
        private readonly Bitmap r_CoinYellow = Ex05_OtheloUI.Properties.Resources.CoinYellow;


        public GameForm(int i_BoardSize, GameEngien.eGameMode i_GameSetting)
        {
            InitializeComponent();
            m_FormSize = m_ButtonSize * i_BoardSize + 20;
            m_buttons = new Button[i_BoardSize, i_BoardSize];
            this.ClientSize = new System.Drawing.Size(m_FormSize, m_FormSize);
            setButtoms(i_BoardSize);
            m_BoardSize = (GameBoard.eBoardDemantions)i_BoardSize;
            m_GameMode = i_GameSetting;
            m_GameEngien = new GameEngien(m_GameMode, m_BoardSize);
            m_GameEngien.Flip += buttonFlip;
            m_GameEngien.Set += buttonSet;
            m_GameEngien.Error += error;
            makeFirstLayout();
            m_GameEngien.ShowOptions();
        }

        public bool Continue { get => m_KeepPlaying; set => m_KeepPlaying = value; }
        public GameEngien.eGameMode GameSetting { get => m_GameMode; set => m_GameMode = value; }
        public GameBoard.eBoardDemantions BoardSize { get => m_BoardSize; set => m_BoardSize = value; }

        private void makeFirstLayout()
        {
            m_buttons[((int)m_BoardSize / 2) - 1, ((int)m_BoardSize / 2) - 1].BackgroundImage = r_CoinRed;
            m_buttons[((int)m_BoardSize / 2) - 1, ((int)m_BoardSize / 2) - 1].BackgroundImageLayout = ImageLayout.Stretch;

            m_buttons[((int)m_BoardSize / 2) - 1, ((int)m_BoardSize / 2)].BackgroundImage = r_CoinYellow;
            m_buttons[((int)m_BoardSize / 2) - 1, ((int)m_BoardSize / 2)].BackgroundImageLayout = ImageLayout.Stretch;

            m_buttons[((int)m_BoardSize / 2), ((int)m_BoardSize / 2) - 1].BackgroundImage = r_CoinYellow;
            m_buttons[((int)m_BoardSize / 2), ((int)m_BoardSize / 2) - 1].BackgroundImageLayout = ImageLayout.Stretch;

            m_buttons[((int)m_BoardSize / 2), ((int)m_BoardSize / 2)].BackgroundImage = r_CoinRed;
            m_buttons[((int)m_BoardSize / 2), ((int)m_BoardSize / 2)].BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void setButtoms(int i_BoardSize)
        {
            for (int y = 0; y < i_BoardSize; y++)
            {
                for (int x = 0; x < i_BoardSize; x++)
                {
                    m_buttons[y, x] = new Button();
                    m_buttons[y, x].Width = m_ButtonSize;
                    m_buttons[y, x].Height = m_ButtonSize;
                    m_buttons[y, x].Left = this.Left + 10 + x * (m_buttons[y, x].Width);
                    m_buttons[y, x].Top = this.Top + 10 + y * (m_buttons[y, x].Height);
                    m_buttons[y, x].Name = "Button" + s_ButtonNameCounter.ToString();
                    m_buttons[y, x].BackColor = Color.LightGray;
                    m_buttons[y, x].Enabled = false;
                    m_buttons[y, x].Click += Buttons_Click;

                    Controls.Add(m_buttons[y, x]);
                    s_ButtonNameCounter++;
                }
            }
        }

        private void buttonFlip(Ex05_OtheloEngien.Point i_ButtonLocation)
        {
            if (m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImage == r_CoinYellow)
            {
                m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImage = r_CoinRed;
                m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImage = r_CoinYellow;
                m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void buttonSet(Ex05_OtheloEngien.Point i_ButtonLocation, GameEngien.ePlayers i_PlayerType)
        {
            switch (i_PlayerType)
            {
                case GameEngien.ePlayers.FirstPlayer:
                    {
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImage = r_CoinYellow;
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    }
                case GameEngien.ePlayers.SecondPlayer:
                    {
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImage = r_CoinRed;
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    }
                case GameEngien.ePlayers.PossibleMove:
                    {
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackColor = Color.Green;
                        m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].Enabled = true;
                        break;
                    }
                case GameEngien.ePlayers.Empty:
                    {
                        if (m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackColor == Color.Green)
                        {
                            m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].BackColor = Color.LightGray;
                            m_buttons[i_ButtonLocation.y, i_ButtonLocation.x].Enabled = false;
                        }
                        break;
                    }
            }
        }

        private void error(String i_Massege)
        {

        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            bool aiTurn = false;
            Ex05_OtheloEngien.Point location = null;

            for (int y = 0; y < (int)BoardSize; y++)
            {
                for (int x = 0; x < (int)BoardSize; x++)
                {
                    if (m_buttons[y, x] == (sender as Button))
                    {
                        location = new Ex05_OtheloEngien.Point(x, y);
                        break;
                    }
                }
            }

            do
            {
                m_GameEngien.NextMove(location);
                aiTurn = m_GameEngien.ShowOptions();
            } while (aiTurn);
        }
    }
}
