using System;
using System.Collections.Generic;
using System.Text;
using BetfairG = BetfairClient.Framework.com.betfair.api6.global;
using BetfairE = BetfairClient.Framework.com.betfair.api6.exchange;

namespace BetfairClient.Framework
{
    #region Exceptions

    public class ExchangeException : Exception
    {
        public string Function = string.Empty;

        public ExchangeException(string function, object response)
            : this(function, FormatResponseError(response), null)
        {
        }

        public ExchangeException(string function, string message, Exception exception)
            : base(string.Format("{0}: {1}", function, message), exception)
        {
            Function = function;
        }

        private static string FormatResponseError(object response)
        {
            try
            {
                System.Reflection.PropertyInfo propertyInfo = null;
                object errorCode = null;
                object minorErrorCode = null;

                propertyInfo = response.GetType().GetProperty("errorCode");
                if(propertyInfo != null)
                {
                    errorCode = propertyInfo.GetValue(response, null);
                }
                propertyInfo = response.GetType().GetProperty("minorErrorCode");
                if(propertyInfo != null)
                {
                    minorErrorCode = propertyInfo.GetValue(response, null);
                }

                object header = null;
                object headerErrorCode = null;
                object headerMinorErrorCode = null;

                propertyInfo = response.GetType().GetProperty("header");
                if(propertyInfo != null)
                {
                    header = propertyInfo.GetValue(response, null);
                }
                if(header != null)
                {
                    propertyInfo = header.GetType().GetProperty("errorCode");
                    if(propertyInfo != null)
                    {
                        headerErrorCode = propertyInfo.GetValue(header, null);
                    }
                    propertyInfo = header.GetType().GetProperty("minorErrorCode");
                    if(propertyInfo != null)
                    {
                        headerMinorErrorCode = propertyInfo.GetValue(header, null);
                    }
                }

                StringBuilder builder = new StringBuilder();
                builder.Append(string.Format("response = {0}", (errorCode == null) ? "?" : errorCode.ToString()));
                if(minorErrorCode != null)
                {
                    builder.Append(string.Format("; response minor = '{0}'", minorErrorCode.ToString()));
                }
                builder.Append(string.Format("; header = {0}", (headerErrorCode == null) ? "?" : headerErrorCode.ToString()));
                if(headerMinorErrorCode != null)
                {
                    builder.Append(string.Format("; header minor = '{0}'", headerMinorErrorCode.ToString()));
                }
                return builder.ToString();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return "Cannot format response error";
            }
        }
    }

    public class ExchangeThrottleException : ExchangeException
    {
        public ExchangeThrottleException(string function, object response)
            : base(function, response)
        {
        }

        public static bool WasThrottled(object response)
        {
            try
            {
                System.Reflection.PropertyInfo propertyInfo = null;
                object header = null;
                object headerErrorCode = null;

                propertyInfo = response.GetType().GetProperty("header");
                if(propertyInfo != null)
                {
                    header = propertyInfo.GetValue(response, null);
                }
                if(header != null)
                {
                    propertyInfo = header.GetType().GetProperty("errorCode");
                    if(propertyInfo != null)
                    {
                        headerErrorCode = propertyInfo.GetValue(header, null);
                        return headerErrorCode.ToString() == "EXCEEDED_THROTTLE";
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return false;
        }
    }

    #endregion

    #region Event Types (Sports)

    public static class ExchangeEventTypes
    {
        public const int AMERICAN_FOOTBALL = 6423;
        public const int AUSTRALIAN_RULES = 61420;
        public const int BANDY = 998919;
        public const int BASEBALL = 7511;
        public const int BASKETBALL = 7522;
        public const int BOXING = 6;
        public const int CHESS = 136332;
        public const int COMBAT_SPORTS = 4968929;
        public const int CRICKET = 4;
        public const int DARTS = 3503;
        public const int FINANCIAL_BETS = 6231;
        public const int GAELIC_GAMES = 2152880;
        public const int GOLF = 3;
        public const int GREYHOUND_RACING_CARD = 15;
        public const int GREYHOUND_RACING = 4339;
        public const int HANDBALL = 468328;
        public const int HORSE_RACING_CARD = 13;
        public const int HORSE_RACING = 7;
        public const int ICE_HOCKEY = 7524;
        public const int MOTOR_SPORT = 8;
        public const int PELOTA = 5412697;
        public const int POKER = 315220;
        public const int POLITICS = 2378961;
        public const int RUGBY_LEAGUE = 1477;
        public const int RUGBY_UNION = 5;
        public const int SNOOKER = 6422;
        public const int SOCCER_FIXTURES = 14;
        public const int SOCCER = 1;
        public const int SPECIAL_BETS = 10;
        public const int TENNIS = 2;
        public const int VOLLEYBALL = 998917;
        public const int WATER_POLO = 2901849;
        public const int WINTER_SPORTS = 451485;
        public const int YACHTING = 998916;
    }

    #endregion

    public class Exchange
    {
        public const int EXCHANGE_UK = 1;
        public const int EXCHANGE_AU = 2;
        private const string EXCHANGE_URL_UK = "https://api.betfair.com/exchange/v5/BFExchangeService";
        private const string EXCHANGE_URL_AU = "https://api-au.betfair.com/exchange/v5/BFExchangeService";

        public const decimal MINIMUM_PRICE = 1.01m;
        public const decimal MAXIMUM_PRICE = 1000m;

        #region Implementation

        private BetfairG.BFGlobalService serviceGlobal = null;
        private BetfairE.BFExchangeService serviceExchangeUk = null;
        private BetfairE.BFExchangeService serviceExchangeAu = null;
        private Dictionary<int, BetfairE.BFExchangeService> serviceExchanges = null;
        private Dictionary<int, bool> exchangeLocks = null;

        private BetfairG.APIRequestHeader headerGlobal = null;
        private BetfairE.APIRequestHeader headerExchange = null;
        private string currency = null;

        public Exchange()
        {
            serviceGlobal = new BetfairG.BFGlobalService();
            serviceGlobal.EnableDecompression = true;
            serviceExchangeUk = new BetfairE.BFExchangeService();
            serviceExchangeUk.EnableDecompression = true;
            serviceExchangeUk.Url = EXCHANGE_URL_UK;
            serviceExchangeAu = new BetfairE.BFExchangeService();
            serviceExchangeAu.EnableDecompression = true;
            serviceExchangeAu.Url = EXCHANGE_URL_AU;

            serviceExchanges = new Dictionary<int, BetfairE.BFExchangeService>();
            serviceExchanges.Add(EXCHANGE_UK, serviceExchangeUk);
            serviceExchanges.Add(EXCHANGE_AU, serviceExchangeAu);

            exchangeLocks = new Dictionary<int, bool>();
            exchangeLocks.Add(EXCHANGE_UK, false);
            exchangeLocks.Add(EXCHANGE_AU, false);

            headerGlobal = new BetfairG.APIRequestHeader();
            headerExchange = new BetfairE.APIRequestHeader();
        }

        private void ResetSessionToken(BetfairG.APIResponseHeader header)
        {
            headerGlobal.sessionToken = header.sessionToken;
            headerExchange.sessionToken = header.sessionToken;
        }

        private void ResetSessionToken(BetfairE.APIResponseHeader header)
        {
            headerGlobal.sessionToken = header.sessionToken;
            headerExchange.sessionToken = header.sessionToken;
        }

        #endregion

        #region Locks

        public void LockExchange(int exchangeId)
        {
            exchangeLocks[exchangeId] = true;
        }

        public void UnlockExchange(int exchangeId)
        {
            exchangeLocks[exchangeId] = false;
        }

        public bool IsExchangeLocked(int exchangeId)
        {
            return exchangeLocks[exchangeId];
        }

        #endregion

        #region Account Methods

        public bool IsLoggedIn
        {
            get { return (headerGlobal.sessionToken != null); }
        }

        public string Currency
        {
            get { return currency; }
        }

        public void Login(string username, string password)
        {
            BetfairG.LoginReq loginReq = new BetfairG.LoginReq();
            loginReq.username = username;
            loginReq.password = password;
            loginReq.productId = 82;

            BetfairG.LoginResp loginResp = serviceGlobal.login(loginReq);
            ResetSessionToken(loginResp.header);

            if(loginResp.errorCode == BetfairG.LoginErrorEnum.OK)
            {
                currency = loginResp.currency;
            }
            else if(ExchangeThrottleException.WasThrottled(loginResp))
            {
                throw new ExchangeThrottleException("login", loginResp);
            }
            else
            {
                throw new ExchangeException("login", loginResp);
            }
        }

        public void Logout()
        {
            BetfairG.LogoutReq logoutReq = new BetfairG.LogoutReq();
            logoutReq.header = headerGlobal;

            BetfairG.LogoutResp logoutResp = serviceGlobal.logout(logoutReq);
            ResetSessionToken(logoutResp.header);

            if(logoutResp.errorCode == BetfairG.LogoutErrorEnum.OK)
            {
                headerGlobal.sessionToken = null;
                headerExchange.sessionToken = null;
            }
            else if(ExchangeThrottleException.WasThrottled(logoutResp))
            {
                throw new ExchangeThrottleException("logout", logoutResp);
            }
            else
            {
                throw new ExchangeException("logout", logoutResp);
            }
        }

        public void KeepAlive()
        {
            BetfairG.KeepAliveReq keepAliveReq = new BetfairG.KeepAliveReq();
            keepAliveReq.header = headerGlobal;

            BetfairG.KeepAliveResp keepAliveResp = serviceGlobal.keepAlive(keepAliveReq);
            ResetSessionToken(keepAliveResp.header);
        }

        #endregion

        #region Event and Market Methods

        public IList<BetfairG.EventType> GetActiveEventTypes()
        {
            BetfairG.GetEventTypesReq eventTypesReq = new BetfairG.GetEventTypesReq();
            eventTypesReq.header = headerGlobal;

            BetfairG.GetEventTypesResp eventTypesResp = serviceGlobal.getActiveEventTypes(eventTypesReq);
            ResetSessionToken(eventTypesResp.header);

            if(eventTypesResp.errorCode == BetfairG.GetEventsErrorEnum.OK)
            {
                return eventTypesResp.eventTypeItems;
            }
            else if(eventTypesResp.errorCode == BetfairG.GetEventsErrorEnum.NO_RESULTS)
            {
                return new BetfairG.EventType[0];
            }
            else if(ExchangeThrottleException.WasThrottled(eventTypesResp))
            {
                throw new ExchangeThrottleException("getActiveEventTypes", eventTypesResp);
            }
            else
            {
                throw new ExchangeException("getActiveEventTypes", eventTypesResp);
            }
        }

        public IList<BetfairG.EventType> GetAllEventTypes()
        {
            BetfairG.GetEventTypesReq eventTypesReq = new BetfairG.GetEventTypesReq();
            eventTypesReq.header = headerGlobal;

            BetfairG.GetEventTypesResp eventTypesResp = serviceGlobal.getAllEventTypes(eventTypesReq);
            ResetSessionToken(eventTypesResp.header);

            if(eventTypesResp.errorCode == BetfairG.GetEventsErrorEnum.OK)
            {
                return eventTypesResp.eventTypeItems;
            }
            else if(eventTypesResp.errorCode == BetfairG.GetEventsErrorEnum.NO_RESULTS)
            {
                return new BetfairG.EventType[0];
            }
            else if(ExchangeThrottleException.WasThrottled(eventTypesResp))
            {
                throw new ExchangeThrottleException("getAllEventTypes", eventTypesResp);
            }
            else
            {
                throw new ExchangeException("getAllEventTypes", eventTypesResp);
            }
        }

        public class EventInfo
        {
            public IList<BetfairG.BFEvent> Events = null;
            public IList<BetfairG.MarketSummary> MarketsSummaries = null;
        }
        public EventInfo GetEvents(int eventId)
        {
            EventInfo info = new EventInfo();

            BetfairG.GetEventsReq eventsReq = new BetfairG.GetEventsReq();
            eventsReq.header = headerGlobal;
            eventsReq.eventParentId = eventId;

            BetfairG.GetEventsResp eventsResp = serviceGlobal.getEvents(eventsReq);
            ResetSessionToken(eventsResp.header);

            if(eventsResp.errorCode == BetfairG.GetEventsErrorEnum.OK)
            {
                info.Events = eventsResp.eventItems;
                info.MarketsSummaries = eventsResp.marketItems;
                return info;
            }
            else if(eventsResp.errorCode == BetfairG.GetEventsErrorEnum.NO_RESULTS)
            {
                info.Events = new BetfairG.BFEvent[0];
                info.MarketsSummaries = new BetfairG.MarketSummary[0];
                return info;
            }
            else if(ExchangeThrottleException.WasThrottled(eventsResp))
            {
                throw new ExchangeThrottleException("getEvents", eventsResp);
            }
            else
            {
                throw new ExchangeException("getEvents", eventsResp);
            }
        }

        public BetfairE.Market GetMarket(int exchangeId, int marketId)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetMarketReq marketReq = new BetfairE.GetMarketReq();
            marketReq.header = headerExchange;
            marketReq.marketId = marketId;
            marketReq.locale = string.Empty;
            marketReq.includeCouponLinks = false;

            BetfairE.GetMarketResp marketResp = service.getMarket(marketReq);
            ResetSessionToken(marketResp.header);

            if(marketResp.errorCode == BetfairE.GetMarketErrorEnum.OK)
            {
                return marketResp.market;
            }
            else if(ExchangeThrottleException.WasThrottled(marketResp))
            {
                throw new ExchangeThrottleException("getMarket", marketResp);
            }
            else
            {
                throw new ExchangeException("getMarket", marketResp);
            }
        }

        public static string GetMarketName(BetfairG.MarketSummary marketSummary)
        {
            switch(marketSummary.eventTypeId)
            {
                case ExchangeEventTypes.GREYHOUND_RACING:
                case ExchangeEventTypes.GREYHOUND_RACING_CARD:
                case ExchangeEventTypes.HORSE_RACING:
                case ExchangeEventTypes.HORSE_RACING_CARD:
                    return string.Format("{0:HH:mm} {1}", marketSummary.startTime.ToLocalTime(), marketSummary.marketName);

                default:
                    return marketSummary.marketName;
            }
        }

        public static string GetMarketName(BetfairE.Market market)
        {
            string prefix = string.Empty;
            if(market.menuPath.IndexOf('\\') != -1)
            {
                string[] parts = market.menuPath.Split('\\');
                prefix = parts[parts.Length - 1] + " - ";
            }
            else if(market.menuPath.Length > 0)
            {
                prefix = market.menuPath + " - ";
            }
            if(market.marketDisplayTime > DateTime.MinValue)
            {
                return string.Format("{0}{1:HH:mm} {2}", prefix, market.marketDisplayTime.ToLocalTime(), market.name);
            }
            else
            {
                return string.Format("{0}{1}", prefix, market.name);
            }
        }

        public static BetfairE.Runner FindRunner(BetfairE.Market market, int selectionId)
        {
            if(market == null)
            {
                return null;
            }
            foreach(BetfairE.Runner runner in market.runners)
            {
                if(runner.selectionId == selectionId)
                {
                    return runner;
                }
            }
            return null;
        }

        public BetfairE.MarketPrices GetMarketPrices(int exchangeId, int marketId)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetMarketPricesCompressedReq pricesReq = new BetfairE.GetMarketPricesCompressedReq();
            pricesReq.header = headerExchange;
            pricesReq.currencyCode = currency;
            pricesReq.marketId = marketId;

            BetfairE.GetMarketPricesCompressedResp pricesResp = service.getMarketPricesCompressed(pricesReq);
            ResetSessionToken(pricesResp.header);

            if(pricesResp.errorCode == BetfairE.GetMarketPricesErrorEnum.OK)
            {
                return DecompressMarketPrices(pricesResp.marketPrices);
            }
            else if(ExchangeThrottleException.WasThrottled(pricesResp))
            {
                throw new ExchangeThrottleException("getMarketPricesCompressed", pricesResp);
            }
            else
            {
                throw new ExchangeException("getMarketPricesCompressed", pricesResp);
            }
        }

        public static BetfairE.RunnerPrices FindRunnerPrices(BetfairE.MarketPrices marketPrices, int selectionId)
        {
            if(marketPrices == null)
            {
                return null;
            }
            foreach(BetfairE.RunnerPrices runnerPrices in marketPrices.runnerPrices)
            {
                if(runnerPrices.selectionId == selectionId)
                {
                    return runnerPrices;
                }
            }
            return null;
        }

        public IList<BetfairE.VolumeInfo> GetMarketTradedVolume(int exchangeId, int marketId, int selectionId)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetMarketTradedVolumeReq volumeReq = new BetfairE.GetMarketTradedVolumeReq();
            volumeReq.header = headerExchange;
            volumeReq.currencyCode = currency;
            volumeReq.marketId = marketId;
            volumeReq.selectionId = selectionId;
            volumeReq.asianLineId = 0;

            BetfairE.GetMarketTradedVolumeResp volumeResp = service.getMarketTradedVolume(volumeReq);
            ResetSessionToken(volumeResp.header);

            if(volumeResp.errorCode == BetfairE.GetMarketTradedVolumeErrorEnum.OK)
            {
                return volumeResp.priceItems;
            }
            else if(volumeResp.errorCode == BetfairE.GetMarketTradedVolumeErrorEnum.NO_RESULTS)
            {
                return new BetfairE.VolumeInfo[0];
            }
            else if(ExchangeThrottleException.WasThrottled(volumeResp))
            {
                throw new ExchangeThrottleException("getMarketTradedVolume", volumeResp);
            }
            else
            {
                throw new ExchangeException("getMarketTradedVolume", volumeResp);
            }
        }

        public IList<BetfairE.AvailabilityInfo> GetDetailAvailableMktDepth(int exchangeId, int marketId, int selectionId)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetDetailedAvailableMktDepthReq detailReq = new BetfairE.GetDetailedAvailableMktDepthReq();
            detailReq.header = headerExchange;
            detailReq.marketId = marketId;
            detailReq.selectionId = selectionId;

            BetfairE.GetDetailedAvailableMktDepthResp detailResp = service.getDetailAvailableMktDepth(detailReq);
            ResetSessionToken(detailResp.header);

            if(detailResp.errorCode == BetfairE.GetDetailedAvailMktDepthErrorEnum.OK)
            {
                return detailResp.priceItems;
            }
            else if(detailResp.errorCode == BetfairE.GetDetailedAvailMktDepthErrorEnum.NO_RESULTS)
            {
                return new BetfairE.AvailabilityInfo[0];
            }
            else if(ExchangeThrottleException.WasThrottled(detailResp))
            {
                throw new ExchangeThrottleException("getDetailAvailableMktDepth", detailResp);
            }
            else
            {
                throw new ExchangeException("getDetailAvailableMktDepth", detailResp);
            }
        }

        #endregion

        #region Bet Methods

        public IList<BetfairE.Bet> GetCurrentBets(
            int exchangeId, int marketId, BetfairE.BetStatusEnum status,
            BetfairE.BetsOrderByEnum orderBy, ref int record, int records)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetCurrentBetsReq betsReq = new BetfairE.GetCurrentBetsReq();
            betsReq.header = headerExchange;
            betsReq.marketId = marketId;
            betsReq.betStatus = status;
            betsReq.detailed = true;
            betsReq.orderBy = orderBy;
            betsReq.recordCount = records;
            betsReq.startRecord = record;
            betsReq.noTotalRecordCount = true;

            BetfairE.GetCurrentBetsResp betsResp = service.getCurrentBets(betsReq);
            ResetSessionToken(betsResp.header);

            if(betsResp.errorCode == BetfairE.GetCurrentBetsErrorEnum.OK)
            {
                record = (betsResp.bets.Length < records) ? 0 : (record + records);
                return betsResp.bets;
            }
            else if(betsResp.errorCode == BetfairE.GetCurrentBetsErrorEnum.INVALID_START_RECORD)
            {
                record = 0;
                return new BetfairE.Bet[0];
            }
            else if(betsResp.errorCode == BetfairE.GetCurrentBetsErrorEnum.NO_RESULTS)
            {
                record = 0;
                return new BetfairE.Bet[0];
            }
            else if(ExchangeThrottleException.WasThrottled(betsResp))
            {
                throw new ExchangeThrottleException("getCurrentBets", betsResp);
            }
            else
            {
                record = 0;
                throw new ExchangeException("getCurrentBets", betsResp);
            }
        }

        public IList<BetfairE.Bet> GetBetHistory(
            int exchangeId, int marketId, BetfairE.BetStatusEnum status,
            DateTime from, DateTime to,
            ICollection<int> eventTypeIds, ICollection<BetfairE.MarketTypeEnum> marketTypes,
            BetfairE.BetsOrderByEnum orderBy, ref int record, int records)
        {
            int?[] nullableEventTypeIds = null;
            if(eventTypeIds != null)
            {
                int index = 0;
                nullableEventTypeIds = new int?[eventTypeIds.Count];
                foreach(int eventTypeId in eventTypeIds)
                {
                    nullableEventTypeIds[index++] = eventTypeId;
                }
            }

            BetfairE.MarketTypeEnum?[] nullableMarketTypes = null;
            if(marketTypes != null)
            {
                int index = 0;
                nullableMarketTypes = new BetfairE.MarketTypeEnum?[marketTypes.Count];
                foreach(BetfairE.MarketTypeEnum marketType in marketTypes)
                {
                    nullableMarketTypes[index++] = marketType;
                }
            }

            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.GetBetHistoryReq betsReq = new BetfairE.GetBetHistoryReq();
            betsReq.header = headerExchange;
            betsReq.detailed = true;
            betsReq.marketId = marketId;
            betsReq.betTypesIncluded = status;
            betsReq.placedDateFrom = from;
            betsReq.placedDateTo = to;
            betsReq.eventTypeIds = nullableEventTypeIds;
            betsReq.marketTypesIncluded = nullableMarketTypes;
            betsReq.sortBetsBy = orderBy;
            betsReq.recordCount = records;
            betsReq.startRecord = record;

            BetfairE.GetBetHistoryResp betsResp = service.getBetHistory(betsReq);
            ResetSessionToken(betsResp.header);

            if(betsResp.errorCode == BetfairE.GetBetHistoryErrorEnum.OK)
            {
                record = (betsResp.betHistoryItems.Length < records) ? 0 : (record + records);
                return betsResp.betHistoryItems;
            }
            else if(betsResp.errorCode == BetfairE.GetBetHistoryErrorEnum.INVALID_START_RECORD)
            {
                record = 0;
                return new BetfairE.Bet[0];
            }
            else if(betsResp.errorCode == BetfairE.GetBetHistoryErrorEnum.NO_RESULTS)
            {
                record = 0;
                return new BetfairE.Bet[0];
            }
            else if(ExchangeThrottleException.WasThrottled(betsResp))
            {
                throw new ExchangeThrottleException("getBetHistory", betsResp);
            }
            else
            {
                record = 0;
                throw new ExchangeException("getBetHistory", betsResp);
            }
        }

        public BetfairE.PlaceBetsResult PlaceBet(int exchangeId, BetfairE.PlaceBets bet)
        {
            return PlaceBets(exchangeId, new BetfairE.PlaceBets[] { bet })[0];
        }

        public IList<BetfairE.PlaceBetsResult> PlaceBets(int exchangeId, IEnumerable<BetfairE.PlaceBets> bets)
        {
            if(IsExchangeLocked(exchangeId))
            {
                throw new ExchangeException("placeBets", string.Format("Exchange {0} is locked for placement ({1}.LockExchange has been called)", exchangeId, GetType().FullName), null);
            }
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.PlaceBetsReq placeBetsReq = new BetfairE.PlaceBetsReq();
            placeBetsReq.header = headerExchange;
            placeBetsReq.bets = new List<BetfairE.PlaceBets>(bets).ToArray();

            BetfairE.PlaceBetsResp placeBetsResp = service.placeBets(placeBetsReq);
            ResetSessionToken(placeBetsResp.header);

            if(placeBetsResp.errorCode != BetfairE.PlaceBetsErrorEnum.OK)
            {
                if(ExchangeThrottleException.WasThrottled(placeBetsResp))
                {
                    throw new ExchangeThrottleException("placeBets", placeBetsResp);
                }
                else
                {
                    throw new ExchangeException("placeBets", placeBetsResp);
                }
            }
            return placeBetsResp.betResults;
        }

        public BetfairE.UpdateBetsResult UpdateBet(int exchangeId, BetfairE.UpdateBets bet)
        {
            return UpdateBets(exchangeId, new BetfairE.UpdateBets[] { bet })[0];
        }

        public IList<BetfairE.UpdateBetsResult> UpdateBets(int exchangeId, IEnumerable<BetfairE.UpdateBets> bets)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.UpdateBetsReq updateBetsReq = new BetfairE.UpdateBetsReq();
            updateBetsReq.header = headerExchange;
            updateBetsReq.bets = new List<BetfairE.UpdateBets>(bets).ToArray();

            BetfairE.UpdateBetsResp updateBetsResp = service.updateBets(updateBetsReq);
            ResetSessionToken(updateBetsResp.header);

            if(updateBetsResp.errorCode != BetfairE.UpdateBetsErrorEnum.OK)
            {
                if(ExchangeThrottleException.WasThrottled(updateBetsResp))
                {
                    throw new ExchangeThrottleException("updateBets", updateBetsResp);
                }
                else
                {
                    throw new ExchangeException("updateBets", updateBetsResp);
                }
            }
            return updateBetsResp.betResults;
        }

        public BetfairE.CancelBetsResult CancelBet(int exchangeId, BetfairE.CancelBets bet)
        {
            return CancelBets(exchangeId, new BetfairE.CancelBets[] { bet })[0];
        }

        public IList<BetfairE.CancelBetsResult> CancelBets(int exchangeId, IList<BetfairE.CancelBets> bets)
        {
            BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            BetfairE.CancelBetsReq cancelBetsReq = new BetfairE.CancelBetsReq();
            cancelBetsReq.header = headerExchange;
            cancelBetsReq.bets = new List<BetfairE.CancelBets>(bets).ToArray();

            BetfairE.CancelBetsResp cancelBetsResp = service.cancelBets(cancelBetsReq);
            ResetSessionToken(cancelBetsResp.header);

            if(cancelBetsResp.errorCode != BetfairE.CancelBetsErrorEnum.OK)
            {
                if(ExchangeThrottleException.WasThrottled(cancelBetsResp))
                {
                    throw new ExchangeThrottleException("cancelBets", cancelBetsResp);
                }
                else
                {
                    throw new ExchangeException("cancelBets", cancelBetsResp);
                }
            }
            return cancelBetsResp.betResults;
        }

        #endregion

        #region Rounding

        public static decimal Round(decimal number)
        {
            return decimal.Round(number, 2);
        }

        public static decimal Round(decimal number, int decimals)
        {
            return decimal.Round(number, decimals);
        }

        public static double Round(double number)
        {
            return (double)decimal.Round((decimal)number, 2);
        }

        public static double Round(double number, int decimals)
        {
            return (double)decimal.Round((decimal)number, decimals);
        }

        #endregion

        #region Price Increment/Decrement

        // Acceptable Odds
        //
        // All Betfair bets must be placed at 'acceptable' Odds increments. This
        // ensures that the market remains disciplined. For example, if you would
        // like to leave an order on the system, you can only change the current
        // Odds by the increment, or multiple of the increment, shown below.
        //
        // From   To 	Increment
        // 1      2     0.01
        // 2.02   3     0.02
        // 3.05   4     0.05
        // 4.1    6     0.1
        // 6.2    10    0.2
        // 10.5   20    0.5
        // 21     30    1
        // 32     50    2
        // 55     100   5
        // 110    1000  10
        // 1000+  Not Allowed
        //
        // The odds increment on Asian Handicap markets is 0.01 for all odds ranges.

        public static bool IsValidPrice(decimal price)
        {
            return ((price >= 1.01m) && (price <= 1000.00m));
        }

        public static bool IsPipPrice(decimal price)
        {
            decimal remainder;
            return IsPipPrice(price, out remainder);
        }

        public static bool IsPipPrice(decimal price, out decimal remainder)
        {
            remainder = 0m;
            if(price < 1.01m) return false;
            if(price < 2.00m) return ((remainder = (price % 0.01m)) == 0m);
            if(price < 3.00m) return ((remainder = (price % 0.02m)) == 0m);
            if(price < 4.00m) return ((remainder = (price % 0.05m)) == 0m);
            if(price < 6.00m) return ((remainder = (price % 0.10m)) == 0m);
            if(price < 10.00m) return ((remainder = (price % 0.20m)) == 0m);
            if(price < 20.00m) return ((remainder = (price % 0.50m)) == 0m);
            if(price < 30.00m) return ((remainder = (price % 1.00m)) == 0m);
            if(price < 50.00m) return ((remainder = (price % 2.00m)) == 0m);
            if(price < 100.00m) return ((remainder = (price % 5.00m)) == 0m);
            if(price <= 1000.00m) return ((remainder = (price % 10.00m)) == 0m);
            return false;
        }

        public static decimal ClosestPrice(decimal price)
        {
            decimal remainder;
            if(!IsPipPrice(price, out remainder))
            {
                if(price < 1.01m) return price;
                if(price < 2.00m) return (remainder < 0.005m) ? Exchange.Round(price - remainder, 2) : Exchange.Round(price + 0.01m - remainder, 2);
                if(price < 3.00m) return (remainder < 0.010m) ? Exchange.Round(price - remainder, 2) : Exchange.Round(price + 0.02m - remainder, 2);
                if(price < 4.00m) return (remainder < 0.025m) ? Exchange.Round(price - remainder, 2) : Exchange.Round(price + 0.05m - remainder, 2);
                if(price < 6.00m) return (remainder < 0.050m) ? Exchange.Round(price - remainder, 1) : Exchange.Round(price + 0.10m - remainder, 1);
                if(price < 10.00m) return (remainder < 0.100m) ? Exchange.Round(price - remainder, 1) : Exchange.Round(price + 0.20m - remainder, 1);
                if(price < 20.00m) return (remainder < 0.250m) ? Exchange.Round(price - remainder, 1) : Exchange.Round(price + 0.50m - remainder, 1);
                if(price < 30.00m) return (remainder < 0.500m) ? Exchange.Round(price - remainder, 0) : Exchange.Round(price + 1.00m - remainder, 0);
                if(price < 50.00m) return (remainder < 1.000m) ? Exchange.Round(price - remainder, 0) : Exchange.Round(price + 2.00m - remainder, 0);
                if(price < 100.00m) return (remainder < 2.500m) ? Exchange.Round(price - remainder, 0) : Exchange.Round(price + 5.00m - remainder, 0);
                if(price < 1000.00m) return (remainder < 5.000m) ? Exchange.Round(price - remainder, 0) : Exchange.Round(price + 10.00m - remainder, 0);
            }
            return price;
        }

        public static int PriceDecimals(decimal price)
        {
            if(price < 4.00m) return 2;
            if(price < 20.00m) return 1;
            return 0;
        }

        public static decimal IncrementPrice(decimal price)
        {
            decimal remainder;
            if(!IsPipPrice(price, out remainder))
            {
                price = Exchange.Round(price - remainder, 2);
            }

            if(price < 1.01m) return price;
            if(price < 2.00m) return price + 0.01m;
            if(price < 3.00m) return price + 0.02m;
            if(price < 4.00m) return price + 0.05m;
            if(price < 6.00m) return price + 0.10m;
            if(price < 10.00m) return price + 0.20m;
            if(price < 20.00m) return price + 0.50m;
            if(price < 30.00m) return price + 1.00m;
            if(price < 50.00m) return price + 2.00m;
            if(price < 100.00m) return price + 5.00m;
            if(price < 1000.00m) return price + 10.00m;
            return price;
        }

        public static decimal IncrementPrice(decimal price, int pips)
        {
            if(pips == int.MaxValue)
            {
                return MAXIMUM_PRICE;
            }
            else if(pips == 0)
            {
                return price;
            }
            else if(pips > 1)
            {
                return IncrementPrice(IncrementPrice(price), pips - 1);
            }
            else
            {
                return IncrementPrice(price);
            }
        }

        public static decimal DecrementPrice(decimal price)
        {
            decimal remainder;
            if(!IsPipPrice(price, out remainder))
            {
                return Exchange.Round(price - remainder, 2);
            }

            if(price <= 1.01m) return price;
            if(price <= 2.00m) return price - 0.01m;
            if(price <= 3.00m) return price - 0.02m;
            if(price <= 4.00m) return price - 0.05m;
            if(price <= 6.00m) return price - 0.10m;
            if(price <= 10.00m) return price - 0.20m;
            if(price <= 20.00m) return price - 0.50m;
            if(price <= 30.00m) return price - 1.00m;
            if(price <= 50.00m) return price - 2.00m;
            if(price <= 100.00m) return price - 5.00m;
            if(price <= 1000.00m) return price - 10.00m;
            return price;
        }

        public static decimal DecrementPrice(decimal price, int pips)
        {
            if(pips == int.MaxValue)
            {
                return MINIMUM_PRICE;
            }
            else if(pips == 0)
            {
                return price;
            }
            else if(pips > 1)
            {
                return DecrementPrice(DecrementPrice(price), pips - 1);
            }
            else
            {
                return DecrementPrice(price);
            }
        }

        public static int PricePips(decimal firstPrice, decimal secondPrice)
        {
            if(!IsValidPrice(firstPrice) || !IsValidPrice(secondPrice)) return 0;

            int pips = 0;
            if(firstPrice > secondPrice)
            {
                while(Exchange.Round(firstPrice, 2) > Exchange.Round(secondPrice, 2))
                {
                    pips++;
                    firstPrice = DecrementPrice(firstPrice);
                }
            }
            else
            {
                while(Exchange.Round(firstPrice, 2) < Exchange.Round(secondPrice, 2))
                {
                    pips++;
                    firstPrice = IncrementPrice(firstPrice);
                }
            }
            return pips;
        }

        public static decimal MidpointPrice(decimal firstPrice, decimal secondPrice)
        {
            int pips = PricePips(firstPrice, secondPrice);
            decimal lowerPrice = Math.Min(firstPrice, secondPrice);
            decimal floorPrice = IncrementPrice(lowerPrice, (int)Math.Floor(pips / 2m));
            decimal ceilingPrice = IncrementPrice(lowerPrice, (int)Math.Ceiling(pips / 2m));
            return Exchange.Round((floorPrice + ceilingPrice) / 2m, 4);
        }

        #endregion

        #region Decompression

        private static string DecompressEscapePreParse(string compressed)
        {
            if(compressed.IndexOf(@"\") > -1)
            {
                compressed = compressed.Replace(@"\:", "\x01");
                compressed = compressed.Replace(@"\|", "\x02");
                compressed = compressed.Replace(@"\~", "\x03");
                compressed = compressed.Replace(@"\\", "\x04");
            }
            return compressed;
        }

        private static string DecompressEscapePostParse(string parsed)
        {
            parsed = parsed.Replace("\x01", @":");
            parsed = parsed.Replace("\x02", @"|");
            parsed = parsed.Replace("\x03", @"~");
            parsed = parsed.Replace("\x04", @"\");
            return parsed;
        }
        
        private static string DecompressDefault(string val, string def)
        {
            return (val.Length == 0) ? def : val;
        }

        private static double? DecompressStartingPrice(string compressed)
        {
            double price = 0;
            if(double.TryParse(compressed, out price))
            {
                if(double.IsNaN(price))
                {
                    return null;
                }
                if(double.IsNegativeInfinity(price))
                {
                    return null;
                }
                if(double.IsPositiveInfinity(price))
                {
                    return null;
                }
                return price;
            }
            else
            {
                return null;
            }
        }

        private static BetfairE.MarketPrices DecompressMarketPrices(string compressed)
        {
            compressed = DecompressEscapePreParse(compressed);

            // The compressed format:
            //
            // marketId~currencyCode~marketStatus~delay~numberOfWinners~marketInfo~discountAllowed~marketBaseRate~lastRefresh~removedRunners~bspMarket~:
            // selectionId~sortOrder~totalAmountMatched~lastPriceMatched~handicap~reductionFactor~vacant~farBSP~nearBSP~actualBSP~|
            // price~amountAvailable~betType~depth~|
            // price~amountAvailable~betType~depth~:
            // selectionId~sortOrder~totalAmountMatched~lastPriceMatched~handicap~reductionFactor~vacant~farBSP~nearBSP~actualBSP~|
            // price~amountAvailable~betType~depth~|
            // price~amountAvailable~betType~depth~

            BetfairE.MarketPrices marketPrices = new BetfairE.MarketPrices();
            List<BetfairE.RunnerPrices> runnerPricesList = new List<BetfairE.RunnerPrices>();

            string[] runners = compressed.Split(':');
            for(int r = 0; r < runners.Length; r++)
            {
                if(r == 0)
                {
                    string[] values = runners[r].Split('~');
                    if(values.Length >= 9)
                    {
                        marketPrices.marketId = int.Parse(values[0]);
                        marketPrices.currencyCode = DecompressEscapePostParse(values[1]);
                        marketPrices.marketStatus = (BetfairE.MarketStatusEnum)Enum.Parse(typeof(BetfairE.MarketStatusEnum), values[2]);
                        marketPrices.delay = int.Parse(values[3]);
                        marketPrices.numberOfWinners = int.Parse(values[4]);
                        marketPrices.marketInfo = DecompressEscapePostParse(values[5]);
                        marketPrices.discountAllowed = bool.Parse(values[6]);
                        marketPrices.marketBaseRate = float.Parse(values[7]);
                        marketPrices.lastRefresh = long.Parse(DecompressDefault(values[8], "0"));
                        if(values.Length >= 10)
                        {
                            marketPrices.removedRunners = DecompressEscapePostParse(values[9]);
                        }
                        if(values.Length >= 11)
                        {
                            marketPrices.bspMarket = (values[10] == "Y") || (values[10] == "y");
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("DecompressMarketPrices: too few values for market: {0}", runners[r]));
                    }
                }
                else
                {
                    BetfairE.RunnerPrices runnerPrices = new BetfairE.RunnerPrices();
                    List<BetfairE.Price> bestPricesToBackList = new List<BetfairE.Price>();
                    List<BetfairE.Price> bestPricesToLayList = new List<BetfairE.Price>();

                    string[] prices = runners[r].Split('|');
                    for(int p = 0; p < prices.Length; p++)
                    {
                        if(p == 0)
                        {
                            string[] values = prices[p].Split('~');
                            if(values.Length >= 7)
                            {
                                runnerPrices.selectionId = int.Parse(values[0]);
                                runnerPrices.sortOrder = int.Parse(values[1]);
                                runnerPrices.totalAmountMatched = double.Parse(DecompressDefault(values[2], "0"));
                                runnerPrices.lastPriceMatched = double.Parse(DecompressDefault(values[3], "0"));
                                runnerPrices.handicap = double.Parse(DecompressDefault(values[4], "0"));
                                runnerPrices.reductionFactor = double.Parse(DecompressDefault(values[5], "0"));
                                runnerPrices.vacant = bool.Parse(values[6]);
                                if(values.Length >= 10)
                                {
                                    runnerPrices.farBSP = DecompressStartingPrice(values[7]);
                                    runnerPrices.nearBSP = DecompressStartingPrice(values[8]);
                                    runnerPrices.actualBSP = DecompressStartingPrice(values[9]);
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine(string.Format("DecompressMarketPrices: too few values for runner: {0}", prices[p]));
                            }
                        }
                        else
                        {
                            BetfairE.Price price = null;

                            string[] values = prices[p].Split('~');
                            for(int v = 0; v < values.Length; v++)
                            {
                                if(values[v].Length == 0)
                                {
                                    break;
                                }
                                switch(v % 4)
                                {
                                    case 0:
                                        price = new BetfairE.Price();
                                        price.price = double.Parse(values[v]);
                                        break;
                                    case 1:
                                        price.amountAvailable = double.Parse(values[v]);
                                        break;
                                    case 2:
                                        price.betType = (BetfairE.BetTypeEnum)Enum.Parse(typeof(BetfairE.BetTypeEnum), values[v]);
                                        break;
                                    case 3:
                                        price.depth = int.Parse(values[v]);
                                        if(price.betType == BetfairE.BetTypeEnum.B)
                                        {
                                            bestPricesToLayList.Add(price);
                                        }
                                        else
                                        {
                                            bestPricesToBackList.Add(price);
                                        }
                                        price = null;
                                        break;
                                }
                            }
                        }
                    }

                    runnerPrices.bestPricesToBack = bestPricesToBackList.ToArray();
                    runnerPrices.bestPricesToLay = bestPricesToLayList.ToArray();
                    runnerPricesList.Add(runnerPrices);
                }
            }

            marketPrices.runnerPrices = runnerPricesList.ToArray();
            return marketPrices;
        }

        #endregion
    }
}