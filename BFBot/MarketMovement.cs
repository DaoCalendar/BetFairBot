using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class MarketMovement
        {
        private double m_movementBack = 0.0;
        private double m_movementLay = 0.0;
        
        private List<decimal> m_marketMovementBack;
        private List<decimal> m_marketMovementLay;

        public enum MarketMovementType
            {
            Back = 0,
            Lay =1
            }

        public enum MovementHalf
            {
            FirstHalf = 0,
            SecondHalf = 1
            }

        public enum MovementQuater
            {
            FirstQuater = 0,
            SecondQuater = 1,
            ThirdQuater = 2,
            FourthQuater = 3
            }

        public enum MovementTen
            {
            OneTenth = 0,
            TwoTenth = 1,
            ThreeTenth = 2,
            FourTenth = 3,
            FiveTenth = 4,
            SixTenth = 5,
            SevenTenth = 6,
            EightTenth = 7,
            NineTenth = 8,
            TenTenth = 9
            }

        public MarketMovement()
            {
            m_marketMovementBack = new List<decimal>();
            m_marketMovementLay = new List<decimal>();
            }

        public bool BackTime
            {
            get { return TimeToBack(); }
            }

        private bool TimeToBack()
            {
            return true;
            //if (m_marketMovementBack.Count >= 100)
            //    {
            //    double spanBack1 = CompleteSpan(MarketMovementType.Back);
            //    double spanLay1 = CompleteSpan(MarketMovementType.Lay);
                
            //    double halfSpanBack1 = HalfSpan(MarketMovementType.Back, MovementHalf.FirstHalf);
            //    double halfSpanLay1 = HalfSpan(MarketMovementType.Lay, MovementHalf.FirstHalf);
            //    double halfSpanBack2 = HalfSpan(MarketMovementType.Back, MovementHalf.SecondHalf);
            //    double halfSpanLay2 = HalfSpan(MarketMovementType.Lay, MovementHalf.SecondHalf);

            //    double quaterSpanBack1 = QuaterSpan(MarketMovementType.Back, MovementQuater.FirstQuater);
            //    double quaterSpanLay1 = QuaterSpan(MarketMovementType.Lay, MovementQuater.FirstQuater);
            //    double quaterSpanBack2 = QuaterSpan(MarketMovementType.Back, MovementQuater.SecondQuater);
            //    double quaterSpanLay2 = QuaterSpan(MarketMovementType.Lay, MovementQuater.SecondQuater);
            //    double quaterSpanBack3 = QuaterSpan(MarketMovementType.Back, MovementQuater.ThirdQuater);
            //    double quaterSpanLay3 = QuaterSpan(MarketMovementType.Lay, MovementQuater.ThirdQuater);
            //    double quaterSpanBack4 = QuaterSpan(MarketMovementType.Back, MovementQuater.FourthQuater);
            //    double quaterSpanLay4 = QuaterSpan(MarketMovementType.Lay, MovementQuater.FourthQuater);

            //    double tenSpanBack1 = TenSpan(MarketMovementType.Back, MovementTen.OneTenth);
            //    double tenSpanLay1 = TenSpan(MarketMovementType.Lay, MovementTen.OneTenth);
            //    double tenSpanBack2 = TenSpan(MarketMovementType.Back, MovementTen.TwoTenth);
            //    double tenSpanLay2 = TenSpan(MarketMovementType.Lay, MovementTen.TwoTenth);
            //    double tenSpanBack3 = TenSpan(MarketMovementType.Back, MovementTen.ThreeTenth);
            //    double tenSpanLay3 = TenSpan(MarketMovementType.Lay, MovementTen.ThreeTenth);
            //    double tenSpanBack4 = TenSpan(MarketMovementType.Back, MovementTen.FourTenth);
            //    double tenSpanLay4 = TenSpan(MarketMovementType.Lay, MovementTen.FourTenth);
            //    double tenSpanBack5 = TenSpan(MarketMovementType.Back, MovementTen.FiveTenth);
            //    double tenSpanLay5 = TenSpan(MarketMovementType.Lay, MovementTen.FiveTenth);
            //    double tenSpanBack6 = TenSpan(MarketMovementType.Back, MovementTen.SixTenth);
            //    double tenSpanLay6 = TenSpan(MarketMovementType.Lay, MovementTen.SixTenth);
            //    double tenSpanBack7 = TenSpan(MarketMovementType.Back, MovementTen.SevenTenth);
            //    double tenSpanLay7 = TenSpan(MarketMovementType.Lay, MovementTen.SevenTenth);
            //    double tenSpanBack8 = TenSpan(MarketMovementType.Back, MovementTen.EightTenth);
            //    double tenSpanLay8 = TenSpan(MarketMovementType.Lay, MovementTen.EightTenth);
            //    double tenSpanBack9 = TenSpan(MarketMovementType.Back, MovementTen.NineTenth);
            //    double tenSpanLay9 = TenSpan(MarketMovementType.Lay, MovementTen.NineTenth);
            //    double tenSpanBack10 = TenSpan(MarketMovementType.Back, MovementTen.TenTenth);
            //    double tenSpanLay10 = TenSpan(MarketMovementType.Lay, MovementTen.TenTenth);

            //    double tenWeight = 0.0;
            //    double quaterWeight = 0.0;
            //    double halfWeight = 0.0;
            //    double weight = 0.0;

            //    weight = spanBack1;
            //    halfWeight += halfSpanBack1 + halfSpanBack2;
            //    quaterWeight += quaterSpanBack1 + quaterSpanBack2 + quaterSpanBack3 + quaterSpanBack4;
            //    tenWeight += tenSpanBack1 + tenSpanBack2 + tenSpanBack3 + tenSpanBack4 + tenSpanBack5 + tenSpanBack6 + tenSpanBack7 + tenSpanBack8 + tenSpanBack9 + tenSpanBack10;

            //    double totalWeight = weight + halfWeight + quaterWeight + tenWeight;
            //    if(totalWeight < -90)
            //        return true;
            //    return false;
            //    }
            //return false;
            }

        public List<Decimal> GetMarketMovement()
            {
            return m_marketMovementBack;
            }

        public void BackAdd(decimal value)
            {
            if (m_marketMovementBack.Count > 100)
                m_marketMovementBack.Remove(m_marketMovementBack[0]);
            m_marketMovementBack.Add(value);
            if (m_marketMovementBack.Count > 2)
                ProcessMovement(MarketMovementType.Back);
            }

        public void LayAdd(decimal value)
            {
            if (m_marketMovementLay.Count > 100)
                m_marketMovementLay.Remove(m_marketMovementLay[0]);
            m_marketMovementLay.Add(value);
            if (m_marketMovementLay.Count > 2)
                ProcessMovement(MarketMovementType.Lay);
            }

        public bool AbleToPredict
            {
            get 
                {
                if (m_marketMovementBack.Count > 9)
                    return true;
                return false;
                }
            }

        private void ProcessMovement(MarketMovementType type)
            {
            if (type == MarketMovementType.Back)
                {
                m_movementBack += (double)m_marketMovementBack[m_marketMovementBack.Count - 1] - (double)m_marketMovementBack[m_marketMovementBack.Count - 2];
                }
            else
                {
                m_movementLay += (double)m_marketMovementLay[m_marketMovementLay.Count - 1] - (double)m_marketMovementLay[m_marketMovementLay.Count - 2];
                }
            }

        //private double CompleteSpan(MarketMovementType marketMovementType)
        //    {
        //    return SpanValue(0, m_marketMovementBack.Count, marketMovementType);
        //    }

        //private double HalfSpan(MarketMovementType marketMovementType, MovementHalf movementHalf)
        //    {
        //    if (movementHalf == MovementHalf.FirstHalf)
        //        {
        //        return SpanValue(0, 50, marketMovementType);
        //        }
        //    else
        //        {
        //        return SpanValue(50, 100, marketMovementType);
        //        }
        //    }

        //private double QuaterSpan(MarketMovementType marketmovementType, MovementQuater movementQuater)
        //    {
        //    switch(movementQuater)
        //        {
        //        case(MovementQuater.FirstQuater):
        //            return SpanValue(0, 25, marketmovementType);
        //        case(MovementQuater.SecondQuater):
        //            return SpanValue(25, 50, marketmovementType);
        //        case(MovementQuater.ThirdQuater):
        //            return SpanValue(50, 75, marketmovementType);
        //        default:
        //            return SpanValue(75, 100, marketmovementType);
        //        }
        //    }

        //private double TenSpan(MarketMovementType marketMovementType, MovementTen movementTen)
        //    {
        //    switch (movementTen)
        //        {
        //        case(MovementTen.OneTenth):
        //            return SpanValue(0, 10, marketMovementType);
        //        case (MovementTen.TwoTenth):
        //            return SpanValue(10, 20, marketMovementType);
        //        case (MovementTen.ThreeTenth):
        //            return SpanValue(20, 30, marketMovementType);
        //        case (MovementTen.FourTenth):
        //            return SpanValue(30, 40, marketMovementType);
        //        case (MovementTen.FiveTenth):
        //            return SpanValue(40, 50, marketMovementType);
        //        case (MovementTen.SixTenth):
        //            return SpanValue(50, 60, marketMovementType);
        //        case (MovementTen.SevenTenth):
        //            return SpanValue(60, 70, marketMovementType);
        //        case (MovementTen.EightTenth):
        //            return SpanValue(70, 80, marketMovementType);
        //        case (MovementTen.NineTenth):
        //            return SpanValue(80, 90, marketMovementType);
        //        default:
        //            return SpanValue(90, 100, marketMovementType);
        //        }
        //    }

        private double SpanValue(int start, int end, MarketMovementType marketMovementType)
            {
            double spanValue = 0.0;

            if (marketMovementType == MarketMovementType.Back)
                {
                for (int i = start; i < end - 1; i++)
                    {
                    if ((double)m_marketMovementBack[i] > (double)m_marketMovementBack[i + 1])
                        spanValue += 1;
                    else
                        spanValue += -1;
                    }
                }
            else
                {
                for (int i = start; i < end - 1; i++)
                    {
                    if ((double)m_marketMovementBack[i] > (double)m_marketMovementBack[i + 1])
                        spanValue += 1;
                    else
                        spanValue += -1;
                    }
                }
            return spanValue;
            }

        public decimal[] BackPrices(int amount)
            {
            int index = 0;
            decimal[] prices = new decimal[amount];

            for (int i = m_marketMovementBack.Count; i > m_marketMovementBack.Count - amount; i--)
                {
                prices[index++] = m_marketMovementBack[i-1];
                }
            return prices;
            }

        public decimal[] LayPrices(int amount)
            {
            int index = 0;
            decimal[] prices = new decimal[amount];

            for (int i = m_marketMovementLay.Count; i > m_marketMovementLay.Count - amount; i--)
                {
                prices[index++] = m_marketMovementLay[i-1];
                }
            return prices;
            }
        }
    }
