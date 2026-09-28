using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class AfterSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_StockId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 51, "UnitedHealth Group", "Healthcare", 2.10m, 530000000000L, 580.20m, "UNH" },
                    { 52, "ServiceNow", "Software", 0.00m, 185000000000L, 890.40m, "NOW" },
                    { 53, "GE Aerospace", "Aerospace", 0.28m, 192000000000L, 175.80m, "GE" },
                    { 54, "Applied Materials", "Semiconductors", 0.40m, 172000000000L, 210.30m, "AMAT" },
                    { 55, "Intuitive Surgical", "Healthcare", 0.00m, 164000000000L, 460.50m, "ISRG" },
                    { 56, "Booking Holdings", "Travel", 8.75m, 145000000000L, 4200.00m, "BKNG" },
                    { 57, "Texas Instruments", "Semiconductors", 1.30m, 188000000000L, 205.10m, "TXN" },
                    { 58, "Lam Research", "Semiconductors", 2.30m, 106000000000L, 820.70m, "LRCX" },
                    { 59, "S&P Global", "Financials", 0.91m, 159000000000L, 510.80m, "SPGI" },
                    { 60, "Stryker", "Healthcare", 0.80m, 139000000000L, 365.40m, "SYK" },
                    { 61, "Palo Alto Networks", "Cybersecurity", 0.00m, 112000000000L, 345.90m, "PANW" },
                    { 62, "Arista Networks", "Networking", 0.00m, 102000000000L, 325.00m, "ANET" },
                    { 63, "Micron Technology", "Semiconductors", 0.11m, 144000000000L, 130.40m, "MU" },
                    { 64, "Automatic Data Processing", "Software", 1.40m, 113000000000L, 275.60m, "ADP" },
                    { 65, "TJX Companies", "Retail", 0.38m, 133000000000L, 118.90m, "TJX" },
                    { 66, "Mondelez International", "Consumer Goods", 0.47m, 97000000000L, 72.30m, "MDLZ" },
                    { 67, "Fiserv", "Financials", 0.00m, 105000000000L, 178.50m, "FI" },
                    { 68, "Charles Schwab", "Financials", 0.25m, 124000000000L, 68.40m, "SCHW" },
                    { 69, "Progressive", "Insurance", 0.10m, 144000000000L, 245.80m, "PGR" },
                    { 70, "Uber Technologies", "Transportation", 0.00m, 163000000000L, 78.90m, "UBER" },
                    { 71, "Eli Lilly & Co", "Healthcare", 1.30m, 860000000000L, 910.00m, "LLY" },
                    { 72, "Chubb Limited", "Insurance", 0.91m, 114000000000L, 280.30m, "CB" },
                    { 73, "John Deere", "Industrials", 1.47m, 109000000000L, 395.20m, "DE" },
                    { 74, "Sempra Energy", "Utilities", 0.62m, 53000000000L, 84.50m, "SRE" },
                    { 75, "Marsh McLennan", "Insurance", 0.81m, 111000000000L, 225.10m, "MMCM" },
                    { 76, "Regeneron Pharmaceuticals", "Healthcare", 0.00m, 123000000000L, 1150.00m, "REGN" },
                    { 77, "Analog Devices", "Semiconductors", 0.92m, 114000000000L, 230.80m, "ADI" },
                    { 78, "KLA Corporation", "Semiconductors", 1.45m, 109000000000L, 815.40m, "KLAC" },
                    { 79, "Boston Scientific", "Healthcare", 0.00m, 121000000000L, 82.60m, "BSX" },
                    { 80, "Waste Management", "Services", 0.75m, 86000000000L, 215.30m, "WM" },
                    { 81, "Sherwin-Williams", "Materials", 0.71m, 90000000000L, 360.20m, "SHW" },
                    { 82, "HCA Healthcare", "Healthcare", 0.66m, 98000000000L, 380.50m, "HCA" },
                    { 83, "Eaton Corporation", "Industrials", 0.94m, 131000000000L, 330.10m, "ETN" },
                    { 84, "CrowdStrike", "Cybersecurity", 0.00m, 68000000000L, 280.40m, "CRWD" },
                    { 85, "Synopsys", "Software", 0.00m, 89000000000L, 580.90m, "SNPS" },
                    { 86, "Cadence Design Systems", "Software", 0.00m, 78000000000L, 290.10m, "CDNS" },
                    { 87, "Medtronic", "Healthcare", 0.70m, 113000000000L, 88.40m, "MDT" },
                    { 88, "The Cigna Group", "Healthcare", 1.40m, 99000000000L, 350.20m, "CI" },
                    { 89, "Ecolab", "Chemicals", 0.57m, 71000000000L, 250.60m, "ECL" },
                    { 90, "Illinois Tool Works", "Industrials", 1.40m, 78000000000L, 260.80m, "ITW" },
                    { 91, "Parker-Hannifin", "Industrials", 1.63m, 75000000000L, 590.20m, "PH" },
                    { 92, "Moody's Corporation", "Financials", 0.85m, 89000000000L, 490.50m, "MCO" },
                    { 93, "CSX Corporation", "Transportation", 0.12m, 68000000000L, 35.10m, "CSX" },
                    { 94, "Norfolk Southern", "Transportation", 1.35m, 54000000000L, 240.60m, "NSC" },
                    { 95, "FedEx", "Logistics", 1.38m, 70000000000L, 285.30m, "FDX" },
                    { 96, "McKesson Corporation", "Healthcare", 0.71m, 76000000000L, 590.80m, "MCK" },
                    { 97, "O'Reilly Automotive", "Retail", 0.00m, 67000000000L, 1150.00m, "ORLY" },
                    { 98, "AutoZone", "Retail", 0.00m, 52000000000L, 3100.00m, "AZO" },
                    { 99, "Marriott International", "Hospitality", 0.63m, 71000000000L, 250.40m, "MAR" },
                    { 100, "Hilton Worldwide", "Hospitality", 0.15m, 55000000000L, 220.10m, "HLT" },
                    { 101, "Shopify", "E-Commerce", 0.00m, 101000000000L, 78.50m, "SHOP" },
                    { 102, "Block Inc", "Fintech", 0.00m, 42000000000L, 68.20m, "SQ" },
                    { 103, "PayPal", "Fintech", 0.00m, 74000000000L, 72.40m, "PYPL" },
                    { 104, "Coinbase", "Fintech", 0.00m, 54000000000L, 220.10m, "COIN" },
                    { 105, "Spotify", "Entertainment", 0.00m, 68000000000L, 340.60m, "SPOT" },
                    { 106, "Snowflake", "Software", 0.00m, 41000000000L, 125.30m, "SNOW" },
                    { 107, "DataDog", "Software", 0.00m, 39000000000L, 118.40m, "DDOG" },
                    { 108, "Cloudflare", "Cybersecurity", 0.00m, 28000000000L, 82.10m, "NET" },
                    { 109, "Zscaler", "Cybersecurity", 0.00m, 29000000000L, 190.50m, "ZS" },
                    { 110, "Twilio", "Software", 0.00m, 10000000000L, 62.80m, "TWLO" },
                    { 111, "Roku", "Entertainment", 0.00m, 11000000000L, 75.20m, "ROKU" },
                    { 112, "UiPath", "Software", 0.00m, 7500000000L, 13.40m, "PATH" },
                    { 113, "MongoDB", "Software", 0.00m, 20000000000L, 280.90m, "MDB" },
                    { 114, "Roblox", "Gaming", 0.00m, 26000000000L, 42.10m, "RBLX" },
                    { 115, "Unity Software", "Software", 0.00m, 7000000000L, 18.50m, "U" },
                    { 116, "The Trade Desk", "Advertising", 0.00m, 50000000000L, 102.30m, "TTD" },
                    { 117, "AppLovin", "Software", 0.00m, 28000000000L, 85.60m, "APP" },
                    { 118, "Affirm Holdings", "Fintech", 0.00m, 12000000000L, 38.40m, "AFRM" },
                    { 119, "SoFi Technologies", "Fintech", 0.00m, 8800000000L, 8.20m, "SOFI" },
                    { 120, "Robinhood", "Fintech", 0.00m, 19000000000L, 22.40m, "HOOD" },
                    { 121, "Pinterest", "Social Media", 0.00m, 21000000000L, 31.50m, "PINS" },
                    { 122, "Snap Inc", "Social Media", 0.00m, 16000000000L, 9.80m, "SNAP" },
                    { 123, "Lyft Inc", "Transportation", 0.00m, 5000000000L, 12.40m, "LYFT" },
                    { 124, "DoorDash", "Services", 0.00m, 52000000000L, 128.50m, "DASH" },
                    { 125, "Airbnb", "Hospitality", 0.00m, 74000000000L, 118.20m, "ABNB" },
                    { 126, "Zoom Video", "Software", 0.00m, 21000000000L, 68.30m, "ZM" },
                    { 127, "DocuSign", "Software", 0.00m, 12000000000L, 58.10m, "DOCU" },
                    { 128, "Okta Inc", "Cybersecurity", 0.00m, 14000000000L, 82.40m, "OKTA" },
                    { 129, "Elastic NV", "Software", 0.00m, 8200000000L, 78.90m, "ESTC" },
                    { 130, "GitLab", "Software", 0.00m, 8400000000L, 52.30m, "GTLB" },
                    { 131, "Arm Holdings", "Semiconductors", 0.00m, 143000000000L, 138.50m, "ARM" },
                    { 132, "Super Micro Computer", "Hardware", 0.00m, 26000000000L, 450.20m, "SMCI" },
                    { 133, "AST Spacemobile", "Telecommunications", 0.00m, 7200000000L, 28.40m, "ASTS" },
                    { 134, "Rocket Lab", "Aerospace", 0.00m, 3400000000L, 6.80m, "RKLB" },
                    { 135, "Intuitive Machines", "Aerospace", 0.00m, 750000000L, 5.20m, "LUNR" },
                    { 136, "Joby Aviation", "Aerospace", 0.00m, 3600000000L, 5.10m, "JOBY" },
                    { 137, "Archer Aviation", "Aerospace", 0.00m, 1200000000L, 3.80m, "ACHR" },
                    { 138, "IonQ Inc", "Computing", 0.00m, 1700000000L, 8.10m, "IONQ" },
                    { 139, "Rigetti Computing", "Computing", 0.00m, 220000000L, 1.15m, "RGTI" },
                    { 140, "SoundHound AI", "Software", 0.00m, 1800000000L, 5.30m, "SOUN" },
                    { 141, "BigBear.ai", "Software", 0.00m, 450000000L, 1.85m, "BBAI" },
                    { 142, "C3.ai", "Software", 0.00m, 3000000000L, 24.10m, "AI" },
                    { 143, "SentinelOne", "Cybersecurity", 0.00m, 7100000000L, 22.80m, "S" },
                    { 144, "Tenable Holdings", "Cybersecurity", 0.00m, 4900000000L, 42.10m, "TENB" },
                    { 145, "Varonis Systems", "Cybersecurity", 0.00m, 6000000000L, 54.30m, "VRNS" },
                    { 146, "Rapid7", "Cybersecurity", 0.00m, 2400000000L, 38.20m, "RPD" },
                    { 147, "Bill Holdings", "Fintech", 0.00m, 5400000000L, 52.40m, "BILL" },
                    { 148, "Toast Inc", "Software", 0.00m, 14800000000L, 26.80m, "TOST" },
                    { 149, "Grab Holdings", "Transportation", 0.00m, 13500000000L, 3.45m, "GRAB" },
                    { 150, "Sea Limited", "E-Commerce", 0.00m, 46000000000L, 81.20m, "SE" },
                    { 151, "Bank of America Corp", "Financials", 0.26m, 310000000000L, 39.80m, "BAC" },
                    { 152, "Wells Fargo", "Financials", 0.35m, 195000000000L, 56.30m, "WFC" },
                    { 153, "Citigroup", "Financials", 0.53m, 116000000000L, 61.20m, "C" },
                    { 154, "Morgan Stanley", "Financials", 0.85m, 160000000000L, 98.40m, "MS" },
                    { 155, "US Bancorp", "Financials", 0.49m, 68000000000L, 44.10m, "USB" },
                    { 156, "PNC Financial", "Financials", 1.55m, 65000000000L, 165.20m, "PNC" },
                    { 157, "Truist Financial", "Financials", 0.52m, 57000000000L, 42.80m, "TFC" },
                    { 158, "BNY Mellon", "Financials", 0.42m, 48000000000L, 64.30m, "BK" },
                    { 159, "State Street", "Financials", 0.69m, 25000000000L, 84.10m, "STT" },
                    { 160, "Fifth Third Bancorp", "Financials", 0.35m, 26000000000L, 38.50m, "FITB" },
                    { 161, "KeyCorp", "Financials", 0.20m, 15000000000L, 15.80m, "KEY" },
                    { 162, "Citizens Financial", "Financials", 0.42m, 17000000000L, 36.20m, "CFG" },
                    { 163, "Regions Financial", "Financials", 0.24m, 19000000000L, 21.40m, "RF" },
                    { 164, "Huntington Bancshares", "Financials", 0.15m, 21000000000L, 14.60m, "HBAN" },
                    { 165, "American International", "Insurance", 0.36m, 49000000000L, 74.20m, "AIG" },
                    { 166, "MetLife", "Insurance", 0.52m, 52000000000L, 72.80m, "MET" },
                    { 167, "Prudential Financial", "Insurance", 1.30m, 43000000000L, 118.50m, "PRU" },
                    { 168, "Allstate", "Insurance", 0.92m, 48000000000L, 182.40m, "ALL" },
                    { 169, "The Travelers Companies", "Insurance", 1.05m, 52000000000L, 230.10m, "TRV" },
                    { 170, "The Hartford", "Insurance", 0.47m, 31000000000L, 105.30m, "HIG" },
                    { 171, "Aflac", "Insurance", 0.50m, 53000000000L, 92.40m, "AFL" },
                    { 172, "Ameriprise Financial", "Financials", 1.48m, 43000000000L, 440.80m, "AMP" },
                    { 173, "Raymond James", "Financials", 0.45m, 25000000000L, 122.50m, "RJF" },
                    { 174, "MSCI Inc", "Financials", 1.60m, 44000000000L, 560.20m, "MSCI" },
                    { 175, "Cboe Global Markets", "Financials", 0.55m, 21000000000L, 205.40m, "CBOE" },
                    { 176, "CME Group", "Financials", 1.15m, 78000000000L, 218.90m, "CME" },
                    { 177, "Intercontinental Exchange", "Financials", 0.45m, 89000000000L, 155.30m, "ICE" },
                    { 178, "Nasdaq Inc", "Financials", 0.24m, 39000000000L, 68.20m, "NDAQ" },
                    { 179, "Aon plc", "Insurance", 0.67m, 74000000000L, 340.50m, "AON" },
                    { 180, "Willis Towers Watson", "Insurance", 0.88m, 28000000000L, 285.10m, "WTW" },
                    { 181, "AT&T", "Telecommunications", 0.27m, 139000000000L, 19.40m, "T" },
                    { 182, "Verizon", "Telecommunications", 0.66m, 175000000000L, 41.80m, "VZ" },
                    { 183, "T-Mobile US", "Telecommunications", 0.65m, 228000000000L, 195.20m, "TMUS" },
                    { 184, "Comcast", "Entertainment", 0.31m, 153000000000L, 39.50m, "CMCSA" },
                    { 185, "Charter Communications", "Telecommunications", 0.00m, 46000000000L, 320.40m, "CHTR" },
                    { 186, "Alliant Energy", "Utilities", 0.48m, 14000000000L, 58.20m, "LNT" },
                    { 187, "American Electric Power", "Utilities", 0.88m, 51000000000L, 98.10m, "AEP" },
                    { 188, "Dominion Energy", "Utilities", 0.66m, 47000000000L, 56.40m, "D" },
                    { 189, "Duke Energy", "Utilities", 1.02m, 86000000000L, 112.30m, "DUK" },
                    { 190, "The Southern Company", "Utilities", 0.72m, 96000000000L, 88.50m, "SO" },
                    { 191, "NextEra Energy", "Utilities", 0.51m, 167000000000L, 81.40m, "NEE" },
                    { 192, "Exelon", "Utilities", 0.38m, 39000000000L, 39.80m, "EXC" },
                    { 193, "Xcel Energy", "Utilities", 0.54m, 35000000000L, 64.20m, "XEL" },
                    { 194, "Consolidated Edison", "Utilities", 0.83m, 34000000000L, 98.60m, "ED" },
                    { 195, "WEC Energy Group", "Utilities", 0.83m, 28000000000L, 89.10m, "WEC" },
                    { 196, "Edison International", "Utilities", 0.78m, 32000000000L, 84.50m, "EIX" },
                    { 197, "American Water Works", "Utilities", 0.76m, 27000000000L, 138.20m, "AWK" },
                    { 198, "Ameren", "Utilities", 0.67m, 21000000000L, 82.40m, "AEE" },
                    { 199, "CMS Energy", "Utilities", 0.51m, 20000000000L, 68.90m, "CMS" },
                    { 200, "DTE Energy", "Utilities", 1.02m, 25000000000L, 125.10m, "DTE" },
                    { 201, "Schlumberger", "Energy", 0.27m, 64000000000L, 45.20m, "SLB" },
                    { 202, "Halliburton", "Energy", 0.17m, 28000000000L, 32.10m, "HAL" },
                    { 203, "Baker Hughes", "Energy", 0.21m, 35000000000L, 35.80m, "BKR" },
                    { 204, "EOG Resources", "Energy", 0.91m, 72000000000L, 125.40m, "EOG" },
                    { 205, "ConocoPhillips", "Energy", 0.58m, 131000000000L, 112.80m, "COP" },
                    { 206, "Pioneer Natural Resources", "Energy", 1.10m, 62000000000L, 268.00m, "PXD" },
                    { 207, "Occidental Petroleum", "Energy", 0.22m, 50000000000L, 56.30m, "OXY" },
                    { 208, "Marathon Petroleum", "Energy", 0.82m, 59000000000L, 172.50m, "MPC" },
                    { 209, "Valero Energy", "Energy", 1.07m, 48000000000L, 148.90m, "VLO" },
                    { 210, "Phillips 66", "Energy", 1.15m, 58000000000L, 138.20m, "PSX" },
                    { 211, "Hess Corporation", "Energy", 0.43m, 43000000000L, 142.10m, "HES" },
                    { 212, "Devon Energy", "Energy", 0.35m, 26000000000L, 41.50m, "DVN" },
                    { 213, "Diamondback Energy", "Energy", 0.90m, 33000000000L, 185.30m, "FANG" },
                    { 214, "Kinder Morgan", "Energy", 0.28m, 48000000000L, 21.80m, "KMI" },
                    { 215, "Williams Companies", "Energy", 0.47m, 53000000000L, 44.20m, "WMB" },
                    { 216, "ONEOK", "Energy", 0.99m, 51000000000L, 88.50m, "OKE" },
                    { 217, "Targa Resources", "Energy", 0.75m, 30000000000L, 135.10m, "TRGP" },
                    { 218, "Freeport-McMoRan", "Materials", 0.15m, 69000000000L, 48.20m, "FCX" },
                    { 219, "Newmont Corporation", "Materials", 0.25m, 56000000000L, 48.90m, "NEM" },
                    { 220, "Southern Copper", "Materials", 0.80m, 83000000000L, 108.50m, "SCCO" },
                    { 221, "Linde plc", "Chemicals", 1.39m, 222000000000L, 465.30m, "LIN" },
                    { 222, "Air Products", "Chemicals", 1.77m, 63000000000L, 285.40m, "APD" },
                    { 223, "DuPont de Nemours", "Chemicals", 0.38m, 34000000000L, 82.10m, "DD" },
                    { 224, "Dow Inc", "Chemicals", 0.70m, 36000000000L, 52.30m, "DOW" },
                    { 225, "PPG Industries", "Chemicals", 0.68m, 31000000000L, 132.80m, "PPG" },
                    { 226, "Albemarle", "Chemicals", 0.40m, 10800000000L, 92.50m, "ALB" },
                    { 227, "Nucor Corporation", "Materials", 0.54m, 37000000000L, 158.40m, "NUE" },
                    { 228, "Steel Dynamics", "Materials", 0.46m, 19000000000L, 125.10m, "STLD" },
                    { 229, "Vulcan Materials", "Materials", 0.46m, 33000000000L, 255.80m, "VMC" },
                    { 230, "Martin Marietta", "Materials", 0.74m, 35000000000L, 580.20m, "MLM" },
                    { 231, "Honeywell", "Industrials", 1.08m, 133000000000L, 205.30m, "HON" },
                    { 232, "General Electric", "Industrials", 0.28m, 188000000000L, 172.40m, "GE" },
                    { 233, "3M Company", "Industrials", 0.70m, 70000000000L, 128.50m, "MMM" },
                    { 234, "RTX Corporation", "Aerospace", 0.63m, 159000000000L, 120.10m, "RTX" },
                    { 235, "Lockheed Martin", "Aerospace", 3.15m, 134000000000L, 560.40m, "LMT" },
                    { 236, "Boeing", "Aerospace", 0.00m, 99000000000L, 162.30m, "BA" },
                    { 237, "Northrop Grumman", "Aerospace", 2.06m, 76000000000L, 520.80m, "NOC" },
                    { 238, "General Dynamics", "Aerospace", 1.42m, 82000000000L, 302.50m, "GD" },
                    { 239, "TransDigm Group", "Aerospace", 0.00m, 74000000000L, 1320.00m, "TDG" },
                    { 240, "Axon Enterprise", "Aerospace", 0.00m, 28000000000L, 380.50m, "AXON" },
                    { 241, "Emerson Electric", "Industrials", 0.52m, 62000000000L, 108.20m, "EMR" },
                    { 242, "Rockwell Automation", "Industrials", 1.25m, 31000000000L, 275.40m, "ROK" },
                    { 243, "AMETEK", "Industrials", 0.28m, 39000000000L, 172.10m, "AME" },
                    { 244, "Trane Technologies", "Industrials", 0.84m, 85000000000L, 380.20m, "TT" },
                    { 245, "Carrier Global", "Industrials", 0.19m, 61000000000L, 68.50m, "CARR" },
                    { 246, "Otis Worldwide", "Industrials", 0.39m, 39000000000L, 98.20m, "OTIS" },
                    { 247, "Fastenal", "Industrials", 0.39m, 40000000000L, 70.40m, "FAST" },
                    { 248, "WW Grainger", "Industrials", 2.05m, 48000000000L, 980.50m, "GWW" },
                    { 249, "Canadian Pacific Kansas", "Transportation", 0.19m, 76000000000L, 82.30m, "CP" },
                    { 250, "Canadian National Railway", "Transportation", 0.84m, 74000000000L, 118.50m, "CNI" },
                    { 251, "SPDR S&P 500 ETF", "ETF", 1.85m, 560000000000L, 560.20m, "SPY" },
                    { 252, "Invesco QQQ Trust", "ETF", 0.68m, 280000000000L, 480.50m, "QQQ" },
                    { 253, "Vanguard S&P 500 ETF", "ETF", 1.70m, 480000000000L, 515.30m, "VOO" },
                    { 254, "Vanguard Total Stock ETF", "ETF", 0.92m, 390000000000L, 272.80m, "VTI" },
                    { 255, "iShares Russell 2000 ETF", "ETF", 0.72m, 68000000008L, 218.40m, "IWM" },
                    { 256, "Schwab US Dividend Equity", "ETF", 0.75m, 58000000000L, 82.50m, "SCHD" },
                    { 257, "JPMorgan Equity Premium", "ETF", 0.38m, 34000000000L, 58.20m, "JEPI" },
                    { 258, "JPMorgan Nasdaq Equity", "ETF", 0.42m, 18000000000L, 54.10m, "JEPQ" },
                    { 259, "VanEck Semiconductor ETF", "ETF", 0.45m, 24000000000L, 245.80m, "SMH" },
                    { 260, "Energy Select Sector SPDR", "ETF", 0.82m, 38000000000L, 88.20m, "XLE" },
                    { 261, "Financial Select Sector SPDR", "ETF", 0.22m, 42000000000L, 44.50m, "XLF" },
                    { 262, "Technology Select Sector", "ETF", 0.48m, 72000000000L, 225.10m, "XLK" },
                    { 263, "Health Care Select SPDR", "ETF", 0.58m, 40000000000L, 148.90m, "XLV" },
                    { 264, "Consumer Discretionary SPDR", "ETF", 0.45m, 22000000000L, 185.30m, "XLY" },
                    { 265, "Consumer Staples SPDR", "ETF", 0.52m, 17000000000L, 78.40m, "XLP" },
                    { 266, "Industrial Select Sector", "ETF", 0.48m, 21000000000L, 128.50m, "XLI" },
                    { 267, "Utilities Select Sector", "ETF", 0.58m, 16000000000L, 72.10m, "XLU" },
                    { 268, "Materials Select Sector", "ETF", 0.42m, 6200000000L, 89.40m, "XLB" },
                    { 269, "Vanguard Real Estate ETF", "Real Estate", 0.82m, 33000000000L, 88.50m, "VNQ" },
                    { 270, "Prologis Inc", "Real Estate", 0.96m, 113000000000L, 122.40m, "PLD" },
                    { 271, "American Tower", "Real Estate", 1.62m, 105000000000L, 225.80m, "AMT" },
                    { 272, "Equinix Inc", "Real Estate", 4.26m, 84000000000L, 880.50m, "EQIX" },
                    { 273, "Realty Income", "Real Estate", 0.26m, 54000000000L, 62.40m, "O" },
                    { 274, "Welltower Inc", "Real Estate", 0.67m, 71000000000L, 118.20m, "WELL" },
                    { 275, "Simon Property Group", "Real Estate", 2.00m, 54000000000L, 165.40m, "SPG" },
                    { 276, "Public Storage", "Real Estate", 3.00m, 57000000000L, 325.10m, "PSA" },
                    { 277, "Digital Realty Trust", "Real Estate", 1.22m, 50000000000L, 158.90m, "DLR" },
                    { 278, "VICI Properties", "Real Estate", 0.41m, 34000000000L, 32.50m, "VICI" },
                    { 279, "CBRE Group", "Real Estate", 0.00m, 35000000000L, 115.20m, "CBRE" },
                    { 280, "Weyerhaeuser Co", "Real Estate", 0.20m, 23000000000L, 31.80m, "WY" },
                    { 281, "AvalonBay Communities", "Real Estate", 1.70m, 30000000000L, 215.40m, "AVB" },
                    { 282, "Equity Residential", "Real Estate", 0.67m, 27000000000L, 72.80m, "EQR" },
                    { 283, "SBA Communications", "Real Estate", 0.98m, 25000000000L, 235.10m, "SBAC" },
                    { 284, "Invitation Homes", "Real Estate", 0.28m, 21000000000L, 35.20m, "INVH" },
                    { 285, "Alexandria Real Estate", "Real Estate", 1.27m, 21000000000L, 122.50m, "ARE" },
                    { 286, "Mid-America Apartment", "Real Estate", 1.47m, 18000000000L, 158.40m, "MAA" },
                    { 287, "Essex Property Trust", "Real Estate", 2.45m, 19000000000L, 295.10m, "ESS" },
                    { 288, "UDR Inc", "Real Estate", 0.42m, 14000000000L, 44.20m, "UDR" },
                    { 289, "Host Hotels & Resorts", "Real Estate", 0.20m, 13000000000L, 18.50m, "HST" },
                    { 290, "Camden Property Trust", "Real Estate", 1.03m, 13000000000L, 120.80m, "CPT" },
                    { 291, "Kimco Realty", "Real Estate", 0.24m, 15000000000L, 22.40m, "KIM" },
                    { 292, "Boston Properties", "Real Estate", 0.98m, 12000000000L, 78.50m, "BXP" },
                    { 293, "Regency Centers", "Real Estate", 0.67m, 13000000000L, 71.20m, "REG" },
                    { 294, "Federal Realty Investment", "Real Estate", 1.09m, 9500000000L, 112.40m, "FRT" },
                    { 295, "NNN REIT Inc", "Real Estate", 0.58m, 8800000000L, 48.20m, "NNN" },
                    { 296, "Agree Realty", "Real Estate", 0.25m, 7500000000L, 74.50m, "ADC" },
                    { 297, "STAG Industrial", "Real Estate", 0.12m, 7100000000L, 38.90m, "STAG" },
                    { 298, "EPR Properties", "Real Estate", 0.28m, 3600000000L, 48.10m, "EPR" },
                    { 299, "Omega Healthcare Investors", "Real Estate", 0.67m, 9800000000L, 38.40m, "OHI" },
                    { 300, "Medical Properties Trust", "Real Estate", 0.15m, 3100000000L, 5.20m, "MPW" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AppUserId", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 114, null, "Analog chips are in everything. High capital spending now will pay off later.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 51, "Analog Giant" },
                    { 115, null, "TI's management has historically been top-tier at returning capital to shareholders.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 51, "Capital Allocation" },
                    { 116, null, "Industrial demand weakness looks close to bottoming out.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 51, "Cyclical Trough" },
                    { 117, null, "QuickBooks and TurboTax create an incredible ecosystem with pricing power.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 52, "Sticky Platform" },
                    { 118, null, "Consumer finance segment is expanding despite macro headwinds.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 52, "Credit Karma Synergies" },
                    { 119, null, "ServiceNow is essential for IT workflows across Fortune 500 companies.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 53, "Enterprise Standard" },
                    { 120, null, "Pro Plus AI tiers are driving average contract value up significantly.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 53, "GenAI Monetization" },
                    { 121, null, "Renewal rate staying above 98% is practically unheard of in SaaS.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 53, "Retention Beast" },
                    { 122, null, "You can't manufacture advanced nodes without Applied Materials tools.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 54, "Semiconductor Backbone" },
                    { 123, null, "Wafer fab equipment demand will spike as new fabs open worldwide.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 54, "WFE Spending" },
                    { 124, null, "Booking Holdings controls online travel booking with supreme margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 55, "Travel Dominance" },
                    { 125, null, "Share reduction over time has been an incredible compounding engine.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 55, "Aggressive Buybacks" },
                    { 126, null, "Surgeon training and switching costs make Intuitive Surgical unbeatable.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 56, "da Vinci Moat" },
                    { 127, null, "Procedure volumes continue to grow strongly worldwide.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 56, "Procedure Growth" },
                    { 128, null, "The next-gen system rollout will drive system placements for years.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 56, "da Vinci 5 Launch" },
                    { 129, null, "Uber went from burning money to a cash generation powerhouse.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 57, "Free Cash Flow Pivot" },
                    { 130, null, "Dual platform creates cross-selling advantages competitors lack.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 57, "Eats & Mobility" },
                    { 131, null, "Robotaxis could disrupt their model long-term if they don't partner right.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 57, "Autonomous Threat" },
                    { 132, null, "Post-spinoff GE Aerospace is a high-margin, pure aviation engine powerhouse.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 58, "Aerospace Pure Play" },
                    { 133, null, "Commercial flight demand keeps maintenance and spares revenue surging.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 58, "Aftermarket Demand" },
                    { 134, null, "Optum + UnitedHealthcare creates an unparalleled healthcare footprint.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 59, "Healthcare Titan" },
                    { 135, null, "Rising care utilization is exerting short-term pressure on MLR.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 59, "Medical Loss Ratio" },
                    { 136, null, "Change Healthcare incident caused pain, but structural dominance remains intact.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 59, "Cyberattack Recovery" },
                    { 137, null, "One of the best long-term total return stocks in modern history.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 59, "Long-term Compounder" },
                    { 138, null, "IQOS and ZYN are driving a successful transformation away from cigarettes.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 60, "Smoke-Free Transition" },
                    { 139, null, "Dependable dividend yield backed by resilient smoke-free growth.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 60, "High Yield" },
                    { 140, null, "Lowe's PPI improvements are helping close the margin gap with Home Depot.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 61, "Retail Rival" },
                    { 141, null, "Low existing home sales drag DIY spending, but pent-up demand is building.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 61, "Housing Lock-in" },
                    { 142, null, "Corporate debt issuance is an essential tollbooth for S&P Global.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 62, "Ratings Tollbooth" },
                    { 143, null, "Financial data subscriptions provide recurring high-margin cash flow.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 62, "Data Moat" },
                    { 144, null, "Upcoming debt maturities will accelerate credit rating revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 62, "Refinancing Wave" },
                    { 145, null, "Consolidating security vendors into Palo Alto's platform is working.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 63, "Platformization" },
                    { 146, null, "Cybersecurity budgets remain resilient even during economic slowdowns.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 63, "Cyber Essential" },
                    { 147, null, "Free promotional offers to win market share create temporary revenue noise.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 63, "Short-term Friction" },
                    { 148, null, "Lam Research is indispensable for 3D NAND and advanced DRAM scaling.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 64, "Etch & Deposition" },
                    { 149, null, "Memory market rebound will benefit Lam Research faster than peers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 64, "Memory Recovery" },
                    { 150, null, "Mako robotic arm system is winning orthopedic market share globally.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 65, "Robotic Surgery" },
                    { 151, null, "Consistent hip and knee replacement volumes support stable earnings.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 65, "Elective Procedures" },
                    { 152, null, "Cash sorting headwinds are finally abating as client sweep cash stabilizes.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 66, "Cash Sorting Relief" },
                    { 153, null, "Integration synergies are unlocking operating leverage for Schwab.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 66, "TD Ameritrade Integration" },
                    { 154, null, "Morgan Stanley's pivot to wealth management created steady fee revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 67, "Wealth Machine" },
                    { 155, null, "Net new asset inflows continue to prove their franchise strength.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 67, "AUM Inflows" },
                    { 156, null, "Advisory and underwriting fees are ramping back up nicely.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 67, "Capital Markets Rebound" },
                    { 157, null, "Process control and yield management is 100% vital as chip nodes shrink.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 68, "Process Control Leader" },
                    { 158, null, "KLA enjoys virtually no direct competition in high-end optical inspection.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 68, "Pricing Dominance" },
                    { 159, null, "Target has cleared bad inventory and margins are recovering.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 69, "Inventory Management" },
                    { 160, null, "Higher mix of apparel and home goods leaves it exposed to consumer pullbacks.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 69, "Discretionary Pressures" },
                    { 161, null, "Deere's tech stack in autonomous tractors gives it a huge advantage.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 70, "Precision Ag" },
                    { 162, null, "Lower crop prices are impacting short-term equipment replacement cycles.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 70, "Farm Income Cycle" },
                    { 163, null, "Recurring software revenue from precision farming will smooth out cycles.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 70, "Software Subscriptions" },
                    { 164, null, "Global brand awareness lets Airbnb spend far less on performance marketing.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 71, "Network Effects" },
                    { 165, null, "City-level restrictions (like NYC) remain a regional risk factor.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 71, "Regulatory Pushback" },
                    { 166, null, "Remote work trends continue to support stays of 28 days or longer.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 71, "Long-term Stays" },
                    { 167, null, "Customer Relationship Management software remains core to business ops.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 72, "Enterprise Standard" },
                    { 168, null, "Data Cloud is turning into their fastest-growing product segment.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 72, "Data Cloud Push" },
                    { 169, null, "Consumption-based pricing means immediate upside when usage spikes.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 73, "Consumption Model" },
                    { 170, null, "Multi-cloud capability makes Snowflake the neutral data platform choice.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 73, "Data Cloud Leader" },
                    { 171, null, "Multiples are rich, leaving little room for execution missteps.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 73, "High Valuation" },
                    { 172, null, "MongoDB Atlas is the default choice for modern application developers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 74, "Document Database Standard" },
                    { 173, null, "Integrated vector search makes MDB a key player in GenAI application stacks.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 74, "Vector Search AI" },
                    { 174, null, "Shopify is the underlying infrastructure for modern independent DTC brands.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 75, "E-Commerce OS" },
                    { 175, null, "Selling off Deliverr restored margin expansion and focus to core software.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 75, "Logistics Exit" },
                    { 176, null, "Shopify Plus is successfully winning larger enterprise retailers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 75, "Enterprise Penetration" },
                    { 177, null, "Cash App continues to gain market share as a primary banking option for Gen Z.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 76, "Cash App Monetization" },
                    { 178, null, "Block management is finally prioritizing disciplined operating expenses.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 76, "Gross Profit Focus" },
                    { 179, null, "Square point-of-sale hardware and software integration keeps merchant churn low.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 76, "Seller Ecosystem" },
                    { 180, null, "Trading at historically low multiples despite massive transaction volume.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 77, "Value Play" },
                    { 181, null, "Unbranded processing volume is booming, though at lower margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 77, "Braintree Growth" },
                    { 182, null, "Fastlane checkout could help defend branded button market share.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 77, "Fast Checkout Turnaround" },
                    { 183, null, "Cloudflare Workers gives them a massive edge in running AI at the edge.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 78, "Edge Computing Leader" },
                    { 184, null, "Winning enterprise market share away from traditional legacy security players.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 78, "Zero Trust Push" },
                    { 185, null, "Go-to-market execution needs improvement to drive faster profitability.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 78, "High Sales Overhead" },
                    { 186, null, "Falcon single-agent architecture makes module adoption effortless.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 79, "Falcon Platform" },
                    { 187, null, "Operational hiccups cause temporary volatility, but fundamental tech is superior.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 79, "Outage Incident Recovery" },
                    { 188, null, "Annual recurring revenue growth remains near the top of pure-play cybersecurity.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 79, "ARR Compounder" },
                    { 189, null, "Zscaler is a leader in cloud security and secure access service edge (SASE).", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 80, "Zero Trust Pioneer" },
                    { 190, null, "Upselling existing clients to full platform protection continues to succeed.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 80, "Enterprise Expansion" },
                    { 191, null, "Datadog is the preferred monitoring solution for modern cloud applications.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 81, "Observability Standard" },
                    { 192, null, "New AI integration monitoring features create fresh upsell opportunities.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 81, "LLM Monitoring" },
                    { 193, null, "Customers are done cutting cloud usage, shifting back to growth spend.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 81, "Cloud Optimization Bottoming" },
                    { 194, null, "Coinbase serving as custodian for major Bitcoin ETFs gives immense credibility.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 82, "Institutional Gateway" },
                    { 195, null, "Base network adoption creates a new high-margin revenue lever beyond trading fees.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 82, "Base L2 Growth" },
                    { 196, null, "Improving regulatory frameworks will reduce long-term valuation overhang.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 82, "Regulatory Clarity" },
                    { 197, null, "Crypto and options trading activity resurgence boosts Robinhood revenues.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 83, "Retail Active Revival" },
                    { 198, null, "5% yield on uninvested cash is bringing substantial net deposits to the platform.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 83, "Gold Membership Value" },
                    { 199, null, "UK and EU launches broaden the addressable market outside the US.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 83, "International Expansion" },
                    { 200, null, "Disciplined headcount control is finally letting top-line gains drop to the bottom line.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 83, "Operating Leverage" },
                    { 201, null, "Affirm is consolidating its position as the premier buy-now-pay-later provider for enterprise checkouts.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 84, "BNPL Pioneer" },
                    { 202, null, "Key checkout integrations provide massive volume growth without high acquisition costs.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 84, "Shopify & Amazon Deals" },
                    { 203, null, "Underwriting algorithms are holding up well despite higher baseline interest rates.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 84, "Credit Performance" },
                    { 204, null, "Artificial Intelligence Platform (AIP) bootcamps are driving unprecedented commercial growth in the US.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 85, "AIP Demand Boom" },
                    { 205, null, "Unshakeable monopoly in defense and intelligence sector government contracts.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 85, "Defense Moat" },
                    { 206, null, "S&P 500 inclusion unlock institutional capital inflows and legitimizes profitability.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 85, "S&P 500 Catalyst" },
                    { 207, null, "Multiples are priced for perfection; any growth deceleration could trigger short-term pullback.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 85, "Valuation Overhang" },
                    { 208, null, "UiPath remains the clear gold standard in Robotic Process Automation.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 86, "RPA Dominance" },
                    { 209, null, "Integrating AI agents with business processes significantly increases software utility.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 86, "Agentic AI Synergy" },
                    { 210, null, "Management changes created temporary uncertainty, but core fundamentals remain sound.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 86, "Leadership Transition" },
                    { 211, null, "Unity controls the underlying game engine for over half of all mobile games globally.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 87, "Mobile Engine Power" },
                    { 212, null, "Canceling the controversial runtime fee has restored vital trust with indie developers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 87, "Runtime Fee Reset" },
                    { 213, null, "Vectoring back toward core engine and advertising monetizations will take time.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 87, "Ad Network Turnaround" },
                    { 214, null, "Roblox is the only consumer platform successfully delivering real metaverse scale.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 88, "Metaverse Standard" },
                    { 215, null, "Over-13 user cohort is expanding rapidly, driving higher average spend per booking.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 88, "Aging-Up Demographic" },
                    { 216, null, "In-game brand partnerships offer a brand-new monetization avenue with huge potential.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 88, "Immersive Advertising" },
                    { 217, null, "Arm v9 architecture adoption yields nearly double the royalty rate of previous generations.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 89, "Architecture Royalty" },
                    { 218, null, "Windows on Arm and custom hyperscaler chips are breaking x86 legacy control.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 89, "PC & Data Center Shift" },
                    { 219, null, "Virtually impossible for mobile chip designers to switch away from Arm IP.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 89, "High Lock-in" },
                    { 220, null, "Super Micro leads the market in direct liquid cooling for dense GPU cluster deployments.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 90, "Liquid Cooling Tech" },
                    { 221, null, "Hyperscaler custom build demand brings high sales volume but lower gross margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 90, "Margin Pressure" },
                    { 222, null, "Internal control reviews and delayed filings have introduced noticeable stock volatility.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 90, "Governance & Filing" },
                    { 223, null, "Arista Networks continues capturing market share from Cisco in cloud data centers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 91, "Data Center Switching" },
                    { 224, null, "Ultra-Ethernet Consortium push favors Arista over proprietary InfiniBand in the long run.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 91, "Ethernet for AI" },
                    { 225, null, "Extensible Operating System (EOS) gives clients unprecedented network programmability.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 91, "EOS Advantage" },
                    { 226, null, "Dell PowerEdge AI servers are benefiting from massive enterprise backlog orders.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 92, "AI Server Surge" },
                    { 227, null, "AI PC upgrades and Windows 10 end-of-life will stimulate commercial hardware refresh.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 92, "PC Refresh Cycle" },
                    { 228, null, "Aggressive buybacks and growing dividend payout yield reliable cash return.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 92, "Shareholder Return" },
                    { 229, null, "HP Inc generates resilient free cash flow from printing supplies and enterprise PCs.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 93, "Steady Cash Generator" },
                    { 230, null, "Poly acquisition strengthens position in conference room and peripheral ecosystems.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 93, "Hybrid Work Solutions" },
                    { 231, null, "Attractive low valuation multiple supported by consistent share repurchases.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 93, "Value & Dividend" },
                    { 232, null, "Heat-Assisted Magnetic Recording (HAMR) enables Seagate to ship 30TB+ drives.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 94, "HAMR Technology" },
                    { 233, null, "Hyperscale AI training requires vast cold storage HDD arrays.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 94, "Mass Capacity Storage" },
                    { 234, null, "Cloud storage inventory digestion is over, leading to volume and pricing growth.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 94, "Cyclical Upswing" },
                    { 235, null, "Splitting Flash Memory and HDD businesses unlocks latent shareholder value.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 95, "Business Separation" },
                    { 236, null, "Production cuts across memory makers restored NAND flash pricing power.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 95, "NAND Price Recovery" },
                    { 237, null, "High-performance enterprise SSD demand is surging due to AI server deployments.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 95, "Enterprise SSD Shift" },
                    { 238, null, "Micron's High Bandwidth Memory is locked into top-tier AI accelerator builds.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 96, "HBM3E Dominance" },
                    { 239, null, "Tight supply and surge in AI RAM requirements create structural pricing tailwinds.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 96, "Memory Supercycle" },
                    { 240, null, "Memory is inherently cyclical, requiring precise timing over the holding period.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 96, "Cyclical Volatility" },
                    { 241, null, "TSMC manufactures over 90% of the world's most advanced semiconductor logic chips.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 97, "Foundry Monopoly" },
                    { 242, null, "GAAFET transition at 2nm maintains TSMC's multi-year lead over Intel and Samsung.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 97, "2nm N2 Node Leadership" },
                    { 243, null, "Taiwan risk remains the sole discount factor on an otherwise flawless technology monopoly.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 97, "Geopolitical Premium" },
                    { 244, null, "ASML holds a absolute 100% market share in EUV lithography systems.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 98, "EUV Monopoly" },
                    { 245, null, "Next-generation High NA EUV systems priced at $350M+ each secure future revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 98, "High NA EUV" },
                    { 246, null, "Limits on deep ultraviolet (DUV) shipments to China pose near-term headwinds.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 98, "Export Restrictions" },
                    { 247, null, "Massive cash pile and share repurchases provide strong downside protection.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 99, "Value Realization" },
                    { 248, null, "Alibaba Cloud remains China's dominant public cloud provider.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 99, "Cloud Intelligence" },
                    { 249, null, "PDD Holdings and Douyin continue to pressure core Taobao and Tmall market share.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 99, "Domestic Competition" },
                    { 250, null, "Temu is disrupting global cross-border value retail with direct manufacturer shipping.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 100, "Temu Expansion" },
                    { 251, null, "Pinduoduo domestic market monetization and take-rate keep beating expectations.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 100, "Domestic Efficiency" },
                    { 252, null, "Regulatory scrutiny on de minimis customs exemptions could impact Temu margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 100, "Tariff Risks" },
                    { 253, null, "JD's self-owned fulfillment network guarantees superior delivery service quality.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 101, "Logistics Moat" },
                    { 254, null, "Remains the go-to platform for Chinese home appliance and electronics consumer spend.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 101, "Electronics Retail" },
                    { 255, null, "Generous annual dividend payout offers high total return potential for value investors.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 101, "Dividend Yield" },
                    { 256, null, "Baidu leads Chinese generative AI deployment and LLM integration.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 102, "ERNIE Bot & AI" },
                    { 257, null, "Apollo Go robotaxi scale in Wuhan shows commercial viability of fully autonomous fleets.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 102, "Apollo Go Robotaxi" },
                    { 258, null, "Core ad search engine business faces macro softness and video platform competition.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 102, "Search Ad Drag" },
                    { 259, null, "Tencent Music is successfully executing a Spotify-style shift to paid subscriber monetization.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 103, "Music Subscription Growth" },
                    { 260, null, "Average revenue per user is compounding steady year-over-year gains.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 103, "ARPU Expansion" },
                    { 261, null, "Lower user acquisition costs drive rapid operating margin improvements.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 103, "Margin Expansion" },
                    { 262, null, "Bilibili commands unmatched user stickiness among China's youth demographic.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 104, "Gen Z Engagement" },
                    { 263, null, "Exclusive mobile game publishing releases are turning operating losses into profits.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 104, "Gaming Monetization" },
                    { 264, null, "Performance advertising tools are enabling higher ad density without user churn.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 104, "Ad Revenue Scaling" },
                    { 265, null, "Battery swapping network provides a unique competitive differentiator against Tesla.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 105, "Battery Swap Moat" },
                    { 266, null, "Sub-brand ONVO expands NIO's addressable market into mainstream vehicle buyers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 105, "ONVO Mass Market" },
                    { 267, null, "Heavy infrastructure and R&D spending require disciplined balance sheet management.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 105, "Cash Burn Concerns" },
                    { 268, null, "XPeng is recognized as a technical leader in mapless urban autonomous driving in China.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 106, "XNGP Autonomous Lead" },
                    { 269, null, "Joint platform development with Volkswagen provides balance sheet and technical validation.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 106, "Volkswagen Partnership" },
                    { 270, null, "Aggressive discounting across Chinese EV makers limits gross margin expansion.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 106, "Price War Heat" },
                    { 271, null, "Extended-Range Electric Vehicles (EREV) solved range anxiety and powered early profitability.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 107, "EREV Cash Machine" },
                    { 272, null, "MEGA and upcoming pure electric SUV models mark the next phase of growth.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 107, "Pure EV Rollout" },
                    { 273, null, "Li Auto leads Chinese EV startups in unit economics and operating cash flow generation.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 107, "Best-in-Class Margins" },
                    { 274, null, "Upcoming mass-market R2 platform will unlock broader consumer adoption.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 108, "R2 Platform Hype" },
                    { 275, null, "Up to $5B capital injection from VW derisks Rivian's balance sheet long-term.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 108, "Volkswagen Joint Venture" },
                    { 276, null, "Re-engineering the R1 line is crucial for reaching positive gross margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 108, "Gross Margin Turnaround" },
                    { 277, null, "Lucid builds the single most energy-efficient electric powertrain in the market.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 109, "Efficiency Engineering" },
                    { 278, null, "Lucid Gravity opens up the lucrative premium 3-row SUV segment.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 109, "Gravity SUV Launch" },
                    { 279, null, "Saudi Arabia Public Investment Fund funding guarantees liquid runway despite heavy burn.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 109, "PIF Backing" },
                    { 280, null, "Ford Pro commercial division produces high margins and reliable software-fleet revenue.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 110, "Ford Pro Dominance" },
                    { 281, null, "First-gen EV division losses are being offset by strong Ford Blue ICE vehicle earnings.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 110, "Model e Losses" },
                    { 282, null, "Supplemental dividends keep total payout yield highly attractive for dividend investors.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 110, "Capital Return" },
                    { 283, null, "GM is aggressively buying back shares, drastically reducing share count.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 111, "Massive Share Shrink" },
                    { 284, null, "Battery production issues are resolving, paving the way for profitable EV volume.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 111, "Ultium Scaling" },
                    { 285, null, "Cruise safety pauses hurt momentum, but long-term driverless tech value remains intact.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 111, "Cruise Autonomous Restructing" },
                    { 286, null, "Stellantis maintains some of the highest operating profit margins among traditional automakers.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 112, "Cost Control Discipline" },
                    { 287, null, "North American light truck and SUV sales generate the bulk of group profit.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 112, "Jeep & Ram Power" },
                    { 288, null, "US dealer inventory overhang required pricing adjustments and production slowdowns.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 112, "Inventory Headwinds" },
                    { 289, null, "Honda hybrid models are enjoying massive consumer demand during the transition phase.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 113, "Hybrid Demand Sweet Spot" },
                    { 290, null, "Dominant global motorcycle business yields stable cash flows through all economic cycles.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 113, "Motorcycle Cash Flow" },
                    { 291, null, "0 Series EV launch marks Honda's dedicated attempt to modernize its electric platform.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 113, "EV Software Strategy" },
                    { 292, null, "Toyota's long-term bet on hybrid vehicles proved to be an absolute masterclass in strategy.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Hybrid King" },
                    { 293, null, "Record global production numbers continue to produce record operating margins.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Record Earnings" },
                    { 294, null, "Massive investments in solid-state batteries could give Toyota a late-stage EV advantage.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Solid State Battery R&D" },
                    { 295, null, "Toyota Production System ensures smooth supply chain execution where others struggle.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Supply Chain Resilience" },
                    { 296, null, "Unrivaled global consumer trust drives high resale values and customer retention.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Branded Reliability" },
                    { 297, null, "Favorable Japanese Yen exchange rates boost exported earnings significantly.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Yen Currency Tailwinds" },
                    { 298, null, "Combining ICE, Hybrid, BEV, and Hydrogen spreads operational risk effectively.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Multi-Pathway Strategy" },
                    { 299, null, "Domestic vehicle certification scandals caused minor operational delays, but long-term brand is intact.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Certification Testing Governance" },
                    { 300, null, "Toyota represents the safest long-term core holding in the entire global auto sector.", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), 114, "Ultimate Automotive Anchor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Symbol",
                table: "Stocks",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId_CreatedOn",
                table: "Comments",
                columns: new[] { "StockId", "CreatedOn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_Symbol",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Comments_StockId_CreatedOn",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StockId",
                table: "Comments",
                column: "StockId");
        }
    }
}
