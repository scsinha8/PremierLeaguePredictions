namespace PremierLeaguePredictions.Models
{
    public class PremierLeague
    {
        public class Competition
        {
            public string displayText { get; set; }
            public bool selectedValue { get; set; }
            public string value { get; set; }
        }

        public class CompetitionDetails
        {
            public int optaId { get; set; }
            public string title { get; set; }
            public Logo logo { get; set; }
        }

        public class Details
        {
            public int size { get; set; }
            public string transformations { get; set; }
            public Image image { get; set; }
        }

        public class File
        {
            public string fileName { get; set; }
            public string contentType { get; set; }
            public string type { get; set; }
            public string format { get; set; }
            public string url { get; set; }
            public UrlObject urlObject { get; set; }
            public Details details { get; set; }
        }

        public class Image
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Item
        {
            public CompetitionDetails competitionDetails { get; set; }
            public Standings standings { get; set; }
            public List<Knockout> knockout { get; set; }
        }

        public class Knockout
        {
            public string id { get; set; }
            public string title { get; set; }
            public bool currentStage { get; set; }
            public List<Result> results { get; set; }
        }

        public class Logo
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string credit { get; set; }
            public File file { get; set; }
            public List<object> coordinates { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public List<Row> rows { get; set; }
        }

        public class Root
        {
            public List<Season> seasons { get; set; }
            public List<Competition> competitions { get; set; }
            public List<Item> items { get; set; }
        }

        public class Row
        {
            public int points { get; set; }
            public int position { get; set; }
            public int played { get; set; }
            public int won { get; set; }
            public int drawn { get; set; }
            public int lost { get; set; }
            public int goalsFor { get; set; }
            public int goalsAgainst { get; set; }
            public string positionChange { get; set; }
            public string goalDifference { get; set; }
            public List<string> recentForm { get; set; }
            public string crestUrl { get; set; }
            public int clubId { get; set; }
            public string clubName { get; set; }
            public string clubShortName { get; set; }
            public bool featuredTeam { get; set; }
            public bool? cutLine { get; set; }
            public int? legOne { get; set; }
            public int? penalties { get; set; }
        }

        public class Season
        {
            public string displayText { get; set; }
            public string value { get; set; }
            public bool selectedValue { get; set; }
        }

        public class Standings
        {
            public string id { get; set; }
            public List<Table> tables { get; set; }
        }

        public class Table
        {
            public string id { get; set; }
            public List<Row> rows { get; set; }
        }

        public class UrlObject
        {
            public string baseUrl { get; set; }
            public string cloudName { get; set; }
            public string resourceType { get; set; }
            public string type { get; set; }
            public string publicId { get; set; }
        }
    }
}
