using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;

namespace BFBot
    {
    public class Account
        {
        public delegate void Update();
        public event Update OnUpdate;

        public double AmountTransferd
            {
            get { return BfBot.Transfered; }
            }

        public double Balance
            {
            get { return BfBot.Balance; }
            set { BfBot.Balance = value; }
            }

        public double MaxStake
            {
            get { return BfBot.MaxStake; }
            set { BfBot.MaxStake = value; }
            }

        public double TransferLimit
            {
            get { return BfBot.TransferLimit; }
            set { BfBot.TransferLimit = value; }
            }

        public void Add(double value, string description, string action)
            {
            BfBot.Balance += value;
            if (OnUpdate != null)
                OnUpdate();
            Transfer();
            BFBotDB.BfBotDbWorker.Instance().Deposit(value, BfBot.Balance, description, action);
            }

        public void Remove(double value, string description, string action)
            {
            BfBot.Balance -= value;
            if (OnUpdate != null)
                OnUpdate();
            BFBotDB.BfBotDbWorker.Instance().Withdrawal(value, BfBot.Balance, description, action);
            }

        private void Transfer()
            {
            if (BfBot.Balance > BfBot.TransferLimit)
                {
                BfBot.Transfered += BfBot.Balance - BfBot.TransferLimit;
                BfBot.Balance = BfBot.TransferLimit;
                }
            }

        public bool AbleToEqulise(double value)
            {
            if (BfBot.Balance > value * 1.5)
                return true;
            return false;
            }

        public double AllowedStake
            {
            get 
                {
                double value = 0;
                if (BfBot.Balance <= 2)
                    return value;
                value = BfBot.Balance / 6.6; 
                if (value > BfBot.MaxStake)
                    value = BfBot.MaxStake;
                return value;
                }
            }
        }
    }
