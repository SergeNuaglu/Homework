using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    class MainClass
    {
        public static void Main(string[] args)
        {

        }
    }

    class PlayerDataBase
    {
        Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public PlayerDataBase (Dictionary<int,Player> players)
        {
            _players = players;
        }

        public void AddPlayer(int playerNumber, Player player)
        {
            _players.Add(playerNumber,player);
        }

        public void DeletePlayer(int playerNumber)
        {
            _players.Remove(playerNumber);
        }

        public void BanPlayer(int playerNumber)
        {

        }
        public void UnbanPlayer(int playerNumber)
        {

        }

    }

    class Player
    {
        private string _nickname;
        private int _playerNumber;
        private int _playerLavel;
        private bool _isBan = false;

        public bool IsBan
        {
            get
            {
                return IsBan;
            }
            set
            {
                if (_playerNumber==value)
                {

                }
            }
        }

        public Player(string nickname,int playerNumber, int playerLevel)
        {
            _nickname = nickname;
            _playerNumber = playerNumber;
            _playerLavel = playerLevel;
        }
    }
}
