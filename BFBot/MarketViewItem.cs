using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class MarketViewItem : System.Windows.Forms.ListViewItem, ICloneable
        {
        //private Market m_market;

        //public MarketViewItem(Market market)
        //    {
        //    m_market = market;
        //    m_market.OnMarketBacked += new Market.MarketBackedDelegate(m_market_OnMarketBacked);
        //    m_market.OnMarketClosed += new Market.MarketClosed(m_market_OnMarketClosed);
        //    m_market.OnMarketEqualised += new Market.MarketEqualisedDelegate(m_market_OnMarketEqualised);
        //    m_market.OnUpdateMarket += new Market.MarketUpdateDelegate(m_market_OnUpdateMarket);

        //    //this.BackColor = System.Drawing.Color.MistyRose;
        //    this.Text = m_market.FullyQualifiedName;
        //    this.ImageIndex = (int)m_market.MarketState;
        //    this.SubItems.Add(m_market.Meeting);
        //    this.SubItems.Add(m_market.MarketDate());
        //    this.SubItems.Add(m_market.Time);
        //    this.SubItems.Add(m_market.SecondsToOff.ToString());
        //    this.SubItems.Add("0.00");
        //    this.SubItems.Add("0.00");
        //    this.SubItems.Add("");
        //    this.SubItems.Add("0.00");
        //    this.SubItems.Add("0.00");
        //    }

        //void m_market_OnUpdateMarket(Market market)
        //    {
        //    if (this.ListView == null)
        //        return ;
        //    if(this.ListView.Visible == false)
        //        return;
        //    try
        //        {
        //        //if (market.MarketState == BFBot.MarketState.Equalised || market.MarketState == BFBot.MarketState.Closed)
        //        //    {
        //        //    if (market.MarketState != BFBot.MarketState.Closed)
        //        //        this.SubItems[4].Text = m_market.SecondsToOff.ToString();
        //        //    return;
        //        //    }
        //        this.ImageIndex = (int)m_market.MarketState;
        //        if(market.MarketState != BFBot.MarketState.Closed)
        //            this.SubItems[4].Text = m_market.SecondsToOff.ToString();

        //        if (market.MarketState != BFBot.MarketState.Backed && market.MarketState != BFBot.MarketState.Equalised)
        //            this.SubItems[6].Text = m_market.MarketSelection.CurrentBackPrice.ToString();

        //        if(market.MarketState == BFBot.MarketState.Analysing)
        //            this.SubItems[7].Text = m_market.MarketSelection.Name;

        //        if (market.MarketState != BFBot.MarketState.Equalised)
        //            this.SubItems[9].Text = m_market.MarketSelection.CurrentLayPrice.ToString();
        //        }
        //    catch (Exception)
        //    { }
        //    }

        //void m_market_OnMarketEqualised(Market market)
        //    {
        //    if (this.ListView == null)
        //        return;
        //    if (this.ListView.Visible == false)
        //        return;
        //    //this.BackColor = System.Drawing.Color.LightBlue;
        //    this.ImageIndex = (int)BFBot.MarketState.Equalised;
        //    this.SubItems[8].Text = m_market.EqualisedRunner.LayStake().ToString("0.00");
        //    this.SubItems[9].Text = m_market.EqualisedRunner.LayOdds.ToString("0.00");
        //    }

        //void m_market_OnMarketClosed(Market market)
        //    {
        //    if (this.ListView == null)
        //        return;
        //    if (!this.ListView.Visible == true)
        //        return;
        //    //this.BackColor = System.Drawing.Color.LightGray;
        //    this.ImageIndex = (int)BFBot.MarketState.Closed;
        //    }

        //void m_market_OnMarketBacked(Market market)
        //    {
        //    if (this.ListView == null)
        //        return;
        //    if (!this.ListView.Visible == true)
        //        return;
        //    //this.BackColor = System.Drawing.Color.LightGreen;
        //    this.ImageIndex = (int)BFBot.MarketState.Backed;
        //    this.SubItems[5].Text = m_market.Favourite.BackedStake.ToString("0.00");
        //    this.SubItems[6].Text = m_market.Favourite.BackedOdds.ToString("0.00");
        //    }


        //#region ICloneable Members

        //object ICloneable.Clone()
        //    {
        //    return new MarketViewItem(m_market);
        //    }

        //#endregion
        }
    }
