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

        public PlayerDataBase(Dictionary<int, Player> players)
        {
            _players = players;
        }

        public void AddPlayer(int playerNumber, Player player)
        {
            _players.Add(playerNumber, player);
        }

        public void DeletePlayer(int playerNumber)
        {
            _players.Remove(playerNumber);
        }

        public void BanUnbanPlayer(int playerNumber)
        {
            _players[playerNumber].IsBan = _players.ContainsKey(playerNumber);
        }
    }

    class Player
    {
        private string _nickname;
        private int _level;
        private int _number;

        public bool IsBan
        {
            get
            {
                return IsBan;
            }
            set
            {
                if (value)
                {
                    if (IsBan)
                    {
                        IsBan = false;
                    }
                    else
                    {
                        IsBan = true;
                    }
                }
            }
        }

        public Player(string nickname, int number, int level)
        {
            _nickname = nickname;
            _number = number;
            _level = level;
        }
    }
}
