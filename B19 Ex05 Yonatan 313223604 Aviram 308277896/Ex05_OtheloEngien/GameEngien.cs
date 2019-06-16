using System;
using System.Collections.Generic;

namespace Ex05_OtheloEngien
{

    public class GameEngien
    {
        private AI m_PcAi = new AI();
        private ePlayers m_CurrentPlayer = ePlayers.FirstPlayer;
        private eGameMode m_Mode;
        private GameBoard.eBoardDemantions m_BoardSize;
        private GameBoard m_gameBoard;
        private List<Point> m_moveOptions = null;
        private int m_player1Score = 0, m_player2Score = 0;

        public ePlayers CurrentPlayer { get => m_CurrentPlayer; set => m_CurrentPlayer = value; }

        public delegate void MyAction<T, G>(T t1, G t2);
        public event Action<Point> Flip;
        public event MyAction<Point, ePlayers> Set;
        public event Action<String> Error;

        public GameEngien(eGameMode i_Mode, GameBoard.eBoardDemantions i_BoardSize)
        {
            m_Mode = i_Mode;
            m_BoardSize = i_BoardSize;
            m_gameBoard = new GameBoard(i_BoardSize, false);
            m_gameBoard.Flip += onFlip;
            m_gameBoard.Set += onSet;
        }


        public bool ShowOptions()
        {
            bool isNextPlayerIsAI;
            isNextPlayerIsAI = m_CurrentPlayer == ePlayers.SecondPlayer && m_Mode == eGameMode.PvC;
            eraseLastOptions();
            if (!m_gameBoard.IsThereOptionsToPlay(CurrentPlayer, ref m_moveOptions))
            {
                changePlayer();
                isNextPlayerIsAI = m_CurrentPlayer == ePlayers.SecondPlayer && m_Mode == eGameMode.PvC;
                if (!m_gameBoard.IsThereOptionsToPlay(CurrentPlayer, ref m_moveOptions))
                {
                    onError("END");
                }
            }
            return isNextPlayerIsAI;
        }

        private void eraseLastOptions()
        {
            if (m_moveOptions != null)
            {
                foreach (Point p in m_moveOptions)
                {
                    onSet(new Point(p.x, p.y), ePlayers.Empty);
                }
            }
        }

        public void NextMove(Point i_userCordInput)
        {

            if (m_Mode == eGameMode.PvC && m_CurrentPlayer == ePlayers.SecondPlayer)
            {
                i_userCordInput = m_PcAi.AiTurn(m_gameBoard, m_CurrentPlayer);
            }
            if (m_gameBoard.TryAddDiscToLocation(i_userCordInput.x, i_userCordInput.y, (Disc.eColors)m_CurrentPlayer))
            {
                changePlayer();

                m_gameBoard.CalcPlayersScore(out m_player1Score, out m_player2Score);
            }
            else
            {
                onError("WRONG CHOISE");
            }
        }
        private void changePlayer()
        {
            if (CurrentPlayer == ePlayers.FirstPlayer)
            {
                CurrentPlayer = ePlayers.SecondPlayer;
            }
            else
            {
                CurrentPlayer = ePlayers.FirstPlayer;
            }
        }
        public enum eGameMode
        {
            PvP,
            PvC
        }
        public enum ePlayers
        {
            FirstPlayer = 'x',
            SecondPlayer = 'o',
            Empty = ' ',
            PossibleMove = '.',
            GameOver = -1
        }
        private Point makePcMove(List<Point> i_PcOptions)
        {
            Random randMove = new Random();
            int index = randMove.Next(1, i_PcOptions.Count) - 1;
            return i_PcOptions[index];
        }

        protected virtual void onFlip(Point i_PointToFlip)
        {
            Flip.Invoke(i_PointToFlip);
        }
        protected virtual void onSet(Point i_PointToFlip, ePlayers i_PlayerType)
        {
            Set.Invoke(i_PointToFlip, i_PlayerType);
        }
        protected virtual void onError(String i_Massege)
        {
            Error.Invoke(i_Massege);
        }
    }

}

//public void StartGame()
// {
// bool restartGame = true;
//   while (restartGame)
// {

//GameUi gameUi = new GameUi();
//gameUi.LaunchMenu();
//GameBoard gameBoard = new GameBoard((int)gameUi.MatrixSize);
//Point userCordInput;
//GameUi.ePlayers currentPlayer = GameUi.ePlayers.FirstPlayer;
//bool continueGame = true;
//int gameItrator = 0;
//int thereNoOptionsForXPlayers = 0;
//List<Point> moveOptions = null;
//bool isLastTurnWasOk = true;
//int player1Score = 0, player2Score = 0;

//    while (continueGame)
//    {
//        if (m_gameBoard.IsThereOptionsToPlay(m_CurrentPlayer, ref m_moveOptions))
//        {
//            if (m_Mode == eGameMode.PvC && m_CurrentPlayer == ePlayers.SecondPlayer)
//            { 
//                ////userCordInput = MakePcMove(moveOptions);
//                i_userCordInput = m_PcAi.AiTurn(m_gameBoard, m_CurrentPlayer);
//            }
//            else
//            {
//                m_gameBoard.CalcPlayersScore(out m_player1Score, out m_player2Score);
//                userCordInput = gameUi.NextTurn(m_gameBoard.CreatePrintingBoard(m_moveOptions), m_CurrentPlayer, isLastTurnWasOk, m_player1Score, m_player2Score);
//            }

//            if (m_gameBoard.TryAddDiscToLocation(userCordInput.x, userCordInput.y, (Disc.eColors)m_CurrentPlayer))
//            {
//                gameItrator++;
//                isLastTurnWasOk = true;
//            }
//            else
//            {
//                isLastTurnWasOk = false;
//            }

//            m_thereNoOptionsForXPlayers = 0;
//        }
//        else
//        {
//            m_thereNoOptionsForXPlayers++;
//            gameItrator++;
//        }

//        if (gameItrator % 2 == 0)
//        {
//            m_CurrentPlayer = GameUi.ePlayers.FirstPlayer;
//        }
//        else
//        {
//            m_CurrentPlayer = GameUi.ePlayers.SecondPlayer;
//        }

//        continueGame = m_thereNoOptionsForXPlayers < 2;
//    }

//    m_gameBoard.CalcPlayersScore(out m_player1Score, out m_player2Score);
//    gameUi.GameOver(m_gameBoard.CreatePrintingBoard(m_moveOptions), m_player1Score, m_player2Score, ref restartGame);
//}
//}
